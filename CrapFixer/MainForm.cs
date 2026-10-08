using CrapFixer.Services;
using CrapFixer.Views;
using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace CrapFixer;

public partial class MainForm : Form
{
    private const int NavIconSize = 40;
    private const int NavIconTop = 10;
    private const int NavButtonDesignWidth = 84;

    private static readonly Color NavColor = Color.FromArgb(103, 103, 103);
    private static readonly Color SelectedColor = Color.FromArgb(140, 140, 140);
    private readonly NavigationManager _navigation;
    private readonly TweakerView _tweakerView = new TweakerView();
    private ToolsView? _toolsView;
    private OptionsView? _optionsView;

    public MainForm()
    {
        InitializeComponent();
        ApplyLocalization();
        Icon = LoadIcon();
        lblHeaderVersion.Text = "v" + AppInfo.DisplayVersion;
        LoadHeaderLogo();
        LoadNavIcon(btnNavTweaker, "fixer.png");
        LoadNavIcon(btnNavTools, "tools.png");
        LoadNavIcon(btnNavOptions, "options.png");

        _navigation = new NavigationManager(pnlViewHost);
        SelectNavigation(btnNavTweaker);
        _navigation.SwitchView(_tweakerView);
        RestoreWindowState();
    }

    //main shell text comes from the loose language file
    private void ApplyLocalization()
    {
        btnNavTweaker.Text = Loc.Get("Main_Fixer");
        btnNavTools.Text = Loc.Get("Main_Tools");
        btnNavOptions.Text = Loc.Get("Main_Options");
        lnkOnlineHelp.Text = Loc.Get("Main_OnlineHelp");
        lnkCheckUpdates.Text = Loc.Get("Main_CheckUpdates");
        lblHeaderInfo.Text = Loc.Get("Main_GatheringSystem");
    }

    protected override async void OnShown(EventArgs e)
    {
        base.OnShown(e);
        _ = LoadHeaderAsync();
        // CrapCheckThis handoff start - names can only be matched after loading the database
        await _tweakerView.LoadDatabasesAsync();
        if (IsDisposed) return;
        var args = Environment.GetCommandLineArgs();
        if (CrapCheckHandoff.IsAppRequest(args))
        {
            Navigation_Click(btnNavTools, EventArgs.Empty);
            await CrapCheckHandoff.ReceiveAppsAsync(_toolsView!.ShowAppRemover(), args);
        }
        else
            await CrapCheckHandoff.ReceiveAsync(_tweakerView, args);
        // handoff ends here; ordinary launches only load their normal view
    }

    private void Navigation_Click(object? sender, EventArgs e)
    {
        if (!(sender is Button button)) return;
        if (button != btnNavOptions && _optionsView != null)
        {
            _optionsView.SaveCurrentPage();
            _ = _tweakerView.ReloadDatabasesAsync();
        }
        SelectNavigation(button);

        if (button == btnNavTweaker)
            _navigation.SwitchView(_tweakerView);
        else if (button == btnNavTools)
        {
            if (_toolsView == null)
            {
                _toolsView = new ToolsView();
                _toolsView.CustomTweaksChanged += ToolsView_CustomTweaksChanged;
            }
            _toolsView.LoadEntries();
            _navigation.SwitchView(_toolsView);
        }
        else
        {
            if (_optionsView == null)
            {
                _optionsView = new OptionsView();
                _optionsView.DatabaseChanged += OptionsView_DatabaseChanged;
            }
            _optionsView.LoadFromSettings();
            _navigation.SwitchView(_optionsView);
        }
    }

    private async void ToolsView_CustomTweaksChanged(object? sender, EventArgs e) =>
        await _tweakerView.ReloadDatabasesAsync();

    private async void OptionsView_DatabaseChanged(object? sender, EventArgs e) =>
        await _tweakerView.ReloadDatabasesAsync();

    private void SelectNavigation(Button selected)
    {
        foreach (var button in new[] { btnNavTweaker, btnNavTools, btnNavOptions })
            button.BackColor = button == selected ? SelectedColor : NavColor;
    }

    private async Task LoadHeaderAsync()
    {
        var values = await Task.Run(() => Tuple.Create(HeaderSpec.OsSummary, HeaderSpec.HardwareSummary));
        if (IsDisposed) return;
        lblHeaderInfo.Text = values.Item1;
        lblHeaderHardware.Text = values.Item2;
    }

    private static void LoadNavIcon(Button button, string fileName)
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Assets", fileName);
        if (File.Exists(path)) button.Tag = Image.FromFile(path);
        button.Paint += DrawNavIcon;
    }

    private void LoadHeaderLogo()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Assets", "AppIcon.png");
        if (File.Exists(path)) picHeaderIcon.Image = Image.FromFile(path);
    }

    private static void DrawNavIcon(object? sender, PaintEventArgs e)
    {
        if (!(sender is Button button) || !(button.Tag is Image icon)) return;

        //button width follows DPI, so the painted icon follows it too
        var scale = button.Width / (float)NavButtonDesignWidth;
        var size = (int)(NavIconSize * scale);
        var top = (int)(NavIconTop * scale);

        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        e.Graphics.DrawImage(icon, (button.Width - size) / 2, top, size, size);
    }

    private void PnlHeader_Paint(object? sender, PaintEventArgs e)
    {
        if (!(sender is Panel panel)) return;
        using var light = new Pen(Color.FromArgb(88, 88, 88));
        using var dark = new Pen(Color.FromArgb(55, 55, 55));
        e.Graphics.DrawLine(light, 0, panel.Height - 2, panel.Width, panel.Height - 2);
        e.Graphics.DrawLine(dark, 0, panel.Height - 1, panel.Width, panel.Height - 1);
    }

    private void RestoreWindowState()
    {
        var settings = AppSettings.Instance;
        Size = new Size(Math.Max(settings.WindowWidth, MinimumSize.Width),
            Math.Max(settings.WindowHeight, MinimumSize.Height));
        var bounds = new Rectangle(settings.WindowX, settings.WindowY, Width, Height);
        if (settings.WindowX >= 0 && settings.WindowY >= 0 &&
            Screen.AllScreens.Any(screen => screen.WorkingArea.IntersectsWith(bounds)))
        {
            StartPosition = FormStartPosition.Manual;
            Location = new Point(settings.WindowX, settings.WindowY);
        }
        if (settings.WindowState == (int)FormWindowState.Maximized)
            WindowState = FormWindowState.Maximized;
    }

    private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        _optionsView?.SaveCurrentPage();
        var bounds = WindowState == FormWindowState.Normal ? Bounds : RestoreBounds;
        var settings = AppSettings.Instance;
        settings.WindowWidth = bounds.Width;
        settings.WindowHeight = bounds.Height;
        settings.WindowX = bounds.X;
        settings.WindowY = bounds.Y;
        settings.WindowState = WindowState == FormWindowState.Maximized
            ? (int)FormWindowState.Maximized : (int)FormWindowState.Normal;
        settings.Save();
    }

    private void LnkOnlineHelp_Click(object? sender, EventArgs e) =>
        OpenUrl("https://github.com/builtbybel/CrapFixer");

    private void LnkCheckUpdates_Click(object? sender, EventArgs e) =>
        OpenUrl("https://builtbybel.github.io/CrapFixer/update-check.html?version=" +
            Uri.EscapeDataString(AppInfo.DisplayVersion));

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        foreach (var button in new[] { btnNavTweaker, btnNavTools, btnNavOptions })
            if (button.Tag is Image image) image.Dispose();
        picHeaderIcon.Image?.Dispose();
        base.OnFormClosed(e);
    }

    private static Icon? LoadIcon()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Assets", "AppIcon.ico");
        return File.Exists(path) ? new Icon(path) : null;
    }

    private static void OpenUrl(string url)
    {
        try { Process.Start(new ProcessStartInfo(url) { UseShellExecute = true }); }
        catch { }
    }
}
