using CrapFixer.Models;
using CrapFixer.Services;

namespace CrapFixer.Views.Tools;

// scan first, only installed packages get listed
public partial class AppRemoverView : UserControl
{
    private readonly WinappxParser _parser = new();
    private readonly AppxService _appx = new();
    private bool _busy;

    public AppRemoverView()
    {
        InitializeComponent();
        ApplyLocalization();
    }

    private void ApplyLocalization()
    {
        lblStatus.Text = Loc.Get("AppRemover_Initial");
        colName.Text = Loc.Get("AppRemover_App");
        colCategory.Text = Loc.Get("AppRemover_Category");
        colPackage.Text = Loc.Get("AppRemover_Package");
        btnScan.Text = Loc.Get("AppRemover_Scan");
        btnRemove.Text = Loc.Get("AppRemover_Remove");
    }

    // compares Winappx.ini with the installed app packages
    private async void BtnScan_Click(object? sender, EventArgs e)
    {
        if (_busy) return;
        await ScanAsync();
    }

    // CrapCheckThis handoff start - package names limit this scan, never start removal
    internal Task<List<string>> AnalyzeCrapCheckThisHandoffAsync(HashSet<string> packages) =>
        ScanAsync(packages);
    // handoff ends here; the regular Scan button still uses all local signatures

    // same scan for both entry points; a handoff narrows the list to its package names
    private async Task<List<string>> ScanAsync(HashSet<string>? packages = null)
    {
        if (_busy) throw new InvalidOperationException(Loc.Get("Handoff_NotReady"));
        var skipped = new HashSet<string>(packages ?? Enumerable.Empty<string>(), StringComparer.OrdinalIgnoreCase);
        SetBusy(true, Loc.Get("AppRemover_Scanning"));
        lvApps.Items.Clear();
        try
        {
            var apps = await _parser.ParseFileAsync(DatabaseUpdateService.WinappxLocalPath);
            var error = await _appx.ScanAllAsync(apps);
            if (IsDisposed) return skipped.ToList();
            if (error != null) throw new InvalidOperationException(error);

            foreach (var app in apps.Where(item => item.Status == AppxStatus.Installed))
            {
                // full IDs come from our fresh scan; incoming names aren't patterns or commands
                if (packages != null)
                {
                    // package IDs start with name_ followed by version and architecture
                    var package = app.FullPackageName?.Split('_')[0];
                    if (package == null || !skipped.Remove(package)) continue;
                }
                var row = new ListViewItem(app.Name) { Tag = app, Checked = packages != null || app.DefaultSelected };
                row.SubItems.Add(app.Category);
                row.SubItems.Add(app.FullPackageName ?? app.PackageName);
                lvApps.Items.Add(row);
            }
            lblStatus.Text = packages != null
                ? Loc.Format("Handoff_AppsReceived", lvApps.Items.Count)
                : lvApps.Items.Count == 0
                ? Loc.Get("AppRemover_NoneFound")
                : Loc.Format("AppRemover_Found", lvApps.Items.Count);
        }
        catch (Exception ex)
        {
            if (!IsDisposed) lblStatus.Text = Loc.Format("AppRemover_ScanFailed", ex.Message);
            if (packages != null) throw;
        }
        finally { if (!IsDisposed) SetBusy(false); }
        return skipped.ToList();
    }

    // removes only checked rows, nothing else from the ini
    private async void BtnRemove_Click(object? sender, EventArgs e)
    {
        if (_busy) return;
        var selected = lvApps.CheckedItems.Cast<ListViewItem>()
            .Select(row => row.Tag).OfType<AppxItem>().ToList();
        if (selected.Count == 0)
        {
            lblStatus.Text = Loc.Get("AppRemover_SelectFirst");
            return;
        }

        if (AppSettings.Instance.ConfirmActions && MessageBox.Show(this,
            Loc.Format("AppRemover_Confirm", selected.Count), Loc.Get("Tools_AppRemover"),
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

        SetBusy(true, Loc.Get("AppRemover_Removing"));
        var removed = 0;
        var failed = 0;
        foreach (var app in selected)
        {
            lblStatus.Text = Loc.Format("AppRemover_RemovingItem", app.Name, removed + failed + 1, selected.Count);
            var error = await _appx.RemoveAsync(app);
            var row = lvApps.Items.Cast<ListViewItem>().FirstOrDefault(item => ReferenceEquals(item.Tag, app));
            if (error == null)
            {
                removed++;
                if (row != null) lvApps.Items.Remove(row);
            }
            else
            {
                failed++;
                if (row != null)
                {
                    row.ForeColor = Color.Firebrick;
                    row.SubItems[2].Text = error;
                    row.Checked = false;
                }
            }
        }
        lblStatus.Text = Loc.Format("AppRemover_Done", removed, failed);
        SetBusy(false);
    }

    private void SetBusy(bool busy, string? text = null)
    {
        _busy = busy;
        btnScan.Enabled = !busy;
        btnRemove.Enabled = !busy && lvApps.Items.Count > 0;
        lvApps.Enabled = !busy;
        progressBar.Visible = busy;
        if (text != null) lblStatus.Text = text;
    }

    // keep package name wide when the page gets resized
    private void LvApps_Resize(object? sender, EventArgs e)
    {
        if (lvApps.ClientSize.Width < 250) return;
        colName.Width = Math.Max(130, (int)(lvApps.ClientSize.Width * .32));
        colCategory.Width = 95;
        colPackage.Width = Math.Max(150, lvApps.ClientSize.Width - colName.Width - colCategory.Width - 5);
    }
}
