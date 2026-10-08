using CrapFixer.Features.Extensions;
using CrapFixer.Services;

namespace CrapFixer.Views.Tools.Extensions;

public partial class ExtensionsView : UserControl
{
    private readonly ExtensionCatalog _catalog = new();
    private readonly ExtensionService _service = new();
    private bool _busy;

    public ExtensionsView()
    {
        InitializeComponent();
        ApplyLocalization();
    }

    private void ApplyLocalization()
    {
        lblInfo.Text = Loc.Get("Extensions_Initial");
        colName.Text = Loc.Get("Extensions_Extension");
        colStatus.Text = Loc.Get("Extensions_Status");
        colVersion.Text = Loc.Get("Extensions_Version");
        lblDescription.Text = Loc.Get("Extensions_Select");
        btnRun.Text = Loc.Get("Extensions_Run");
        btnRemove.Text = Loc.Get("Extensions_Remove");
        btnInstall.Text = Loc.Get("Extensions_Install");
        btnRefresh.Text = Loc.Get("Extensions_Refresh");
    }

    // gets the small online list, scripts are not downloaded here
    public async Task RefreshCatalogAsync()
    {
        if (_busy) return;
        var selectedName = SelectedExtension?.Name;
        SetBusy(true, Loc.Get("Extensions_Loading"));
        try
        {
            var entries = await _catalog.DownloadAsync();
            lvExtensions.Items.Clear();
            foreach (var extension in entries)
            {
                var installedVersion = _service.GetInstalledVersion(extension);
                var installed = _service.IsInstalled(extension);
                var update = installed && extension.Version.Length > 0 &&
                    !installedVersion.Equals(extension.Version, StringComparison.OrdinalIgnoreCase);
                var row = new ListViewItem(extension.Name) { Tag = extension };
                row.SubItems.Add(update ? Loc.Get("Extensions_UpdateAvailable") : installed
                    ? Loc.Get("Extensions_Installed") : Loc.Get("Extensions_Available"));
                row.SubItems.Add(extension.Version.Length > 0 ? extension.Version : "-");
                lvExtensions.Items.Add(row);
                if (extension.Name.Equals(selectedName, StringComparison.OrdinalIgnoreCase)) row.Selected = true;
            }
            lblInfo.Text = entries.Count == 0 ? Loc.Get("Extensions_None") :
                Loc.Format("Extensions_Found", entries.Count);
        }
        catch (Exception ex)
        {
            lblInfo.Text = Loc.Format("Extensions_LoadFailed", ex.Message);
        }
        finally
        {
            SetBusy(false);
            UpdateSelection();
        }
    }

    private async void BtnRefresh_Click(object? sender, EventArgs e) => await RefreshCatalogAsync();

    private void LvExtensions_SelectedIndexChanged(object? sender, EventArgs e) => UpdateSelection();

    // shows what the selected script is for
    private void UpdateSelection()
    {
        var extension = SelectedExtension;
        if (extension == null)
        {
            lblDescription.Text = Loc.Get("Extensions_Select");
            btnInstall.Enabled = btnRemove.Enabled = btnRun.Enabled = false;
            return;
        }

        var installed = _service.IsInstalled(extension);
        var installedVersion = _service.GetInstalledVersion(extension);
        var update = installed && extension.Version.Length > 0 &&
            !installedVersion.Equals(extension.Version, StringComparison.OrdinalIgnoreCase);
        lblDescription.Text = extension.Description;
        btnInstall.Text = update ? Loc.Get("Extensions_Update") : Loc.Get("Extensions_Install");
        btnInstall.Enabled = !_busy && (!installed || update);
        btnRemove.Enabled = !_busy && installed;
        btnRun.Enabled = !_busy && installed;
    }

    private async void BtnInstall_Click(object? sender, EventArgs e)
    {
        var extension = SelectedExtension;
        if (extension == null || _busy) return;
        SetBusy(true, Loc.Format("Extensions_Downloading", extension.Name));
        try
        {
            await _service.InstallAsync(extension);
            txtOutput.Text = Loc.Format("Extensions_InstalledMessage", extension.Name);
            RefreshRowAfterWork(extension.Name);
        }
        catch (Exception ex) { txtOutput.Text = Loc.Format("Extensions_InstallFailed", ex.Message); }
        finally { SetBusy(false); UpdateSelection(); }
    }

    private void BtnRemove_Click(object? sender, EventArgs e)
    {
        var extension = SelectedExtension;
        if (extension == null || _busy) return;
        if (MessageBox.Show(this, Loc.Format("Extensions_ConfirmRemove", extension.Name), Loc.Get("Tools_Extensions"),
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        try
        {
            _service.Remove(extension);
            txtOutput.Text = Loc.Format("Extensions_RemovedMessage", extension.Name);
            SetRowStatus(extension, Loc.Get("Extensions_Available"));
        }
        catch (Exception ex) { txtOutput.Text = Loc.Format("Extensions_RemoveFailed", ex.Message); }
        UpdateSelection();
    }

    // external scripts always need one clear confirmation
    private async void BtnRun_Click(object? sender, EventArgs e)
    {
        var extension = SelectedExtension;
        if (extension == null || _busy) return;
        if (extension.RequiresAdmin && !ExtensionService.IsAdministrator())
        {
            MessageBox.Show(this, Loc.Get("Extensions_AdminNeeded"), Loc.Get("Tools_Extensions"),
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }
        if (MessageBox.Show(this,
            Loc.Format("Extensions_ConfirmRun", extension.Name, extension.Url),
            Loc.Get("Extensions_RunTitle"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

        SetBusy(true, Loc.Format("Extensions_Running", extension.Name));
        try
        {
            var result = await _service.RunAsync(extension);
            txtOutput.Text = result.Output.Length > 0 ? result.Output : Loc.Format("Extensions_ExitCode", result.ExitCode);
        }
        catch (Exception ex) { txtOutput.Text = Loc.Format("Extensions_RunFailed", ex.Message); }
        finally { SetBusy(false); UpdateSelection(); }
    }

    private ExtensionInfo? SelectedExtension => lvExtensions.SelectedItems.Count == 0
        ? null : lvExtensions.SelectedItems[0].Tag as ExtensionInfo;

    private void SetBusy(bool busy, string? text = null)
    {
        _busy = busy;
        progressBar.Visible = busy;
        btnRefresh.Enabled = !busy;
        lvExtensions.Enabled = !busy;
        if (text != null) lblInfo.Text = text;
        if (busy) btnInstall.Enabled = btnRemove.Enabled = btnRun.Enabled = false;
    }

    private void SetRowStatus(ExtensionInfo extension, string status)
    {
        var row = lvExtensions.Items.Cast<ListViewItem>()
            .FirstOrDefault(item => ReferenceEquals(item.Tag, extension));
        if (row != null) row.SubItems[1].Text = status;
    }

    // no second network request after install
    private void RefreshRowAfterWork(string name)
    {
        foreach (ListViewItem row in lvExtensions.Items)
        {
            if (!(row.Tag is ExtensionInfo extension)) continue;
            if (!extension.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) continue;
            row.SubItems[1].Text = Loc.Get("Extensions_Installed");
            row.Selected = true;
            break;
        }
    }
}
