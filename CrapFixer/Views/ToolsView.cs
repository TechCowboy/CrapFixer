using CrapFixer.Views.Tools;
using CrapFixer.Views.Tools.Extensions;
using CrapFixer.Services;

namespace CrapFixer.Views;

// holds the three little tools pages
public partial class ToolsView : UserControl
{
    private readonly CustomTweaksView _customTweaks = new();
    private readonly AppRemoverView _appRemover = new();
    private readonly ExtensionsView _extensions = new();
    private readonly NavigationManager _subNav;

    public event EventHandler? CustomTweaksChanged;

    public ToolsView()
    {
        InitializeComponent();
        ApplyLocalization();
        _customTweaks.CustomTweaksChanged += (_, _) => CustomTweaksChanged?.Invoke(this, EventArgs.Empty);
        _subNav = new NavigationManager(pnlSubContent);
        SelectSubNavButton(btnNavCustom);
        ShowPage(_customTweaks, Loc.Get("Tools_Custom"), Loc.Get("Tools_CustomSubtitle"));
    }

    private void ApplyLocalization()
    {
        lblPageTitle.Text = Loc.Get("Tools_Title");
        btnNavCustom.Text = Loc.Get("Tools_Custom");
        btnNavAppRemover.Text = Loc.Get("Tools_AppRemover");
        btnNavExtensions.Text = Loc.Get("Tools_Extensions");
    }

    // refresh when MainForm comes back to Tools
    public void LoadEntries() => _customTweaks.LoadEntries();

    private void NavCustom_Click(object? sender, EventArgs e)
    {
        SelectSubNavButton(btnNavCustom);
        ShowPage(_customTweaks, Loc.Get("Tools_Custom"), Loc.Get("Tools_CustomSubtitle"));
    }

    private void NavAppRemover_Click(object? sender, EventArgs e) => ShowAppRemover();

    // CrapCheckThis uses the same page as a normal click on App Remover
    internal AppRemoverView ShowAppRemover()
    {
        SelectSubNavButton(btnNavAppRemover);
        ShowPage(_appRemover, Loc.Get("Tools_AppRemover"), Loc.Get("Tools_AppRemoverSubtitle"));
        return _appRemover;
    }

    private async void NavExtensions_Click(object? sender, EventArgs e)
    {
        SelectSubNavButton(btnNavExtensions);
        ShowPage(_extensions, Loc.Get("Tools_Extensions"), Loc.Get("Tools_ExtensionsSubtitle"));
        await _extensions.RefreshCatalogAsync();
    }

    // swaps only the white tools page
    private void ShowPage(Control page, string title, string subtitle)
    {
        lblPageTitle.Text = title;
        lblPageSubtitle.Text = subtitle;
        _subNav.SwitchView(page);
    }

    // same selection color as Options
    private void SelectSubNavButton(Button selected)
    {
        foreach (var button in new[] { btnNavCustom, btnNavAppRemover, btnNavExtensions })
            button.BackColor = button == selected ? Color.FromArgb(193, 210, 238) : Color.White;
    }
}
