using CrapFixer.Services;
using CrapFixer.Views.Settings;
using System.Diagnostics;

namespace CrapFixer.Views;

// only the settings shell, pages stay in Views/Settings
public partial class OptionsView : UserControl
{
    private readonly BasicSettingsView _basic = new();
    private readonly AdvancedSettingsView _advanced = new();
    private readonly AiSettingsView _ai = new();
    private readonly AboutSettingsView _about = new();
    private readonly NavigationManager _subNav;
    private Control? _currentPage;

    public event EventHandler? DatabaseChanged;

    public OptionsView()
    {
        InitializeComponent();
        ApplyLocalization();
        cboDonationAmount.SelectedIndex = 2;
        cboDonationCurrency.SelectedIndex = 0;
        _basic.DatabaseChanged += (_, _) => DatabaseChanged?.Invoke(this, EventArgs.Empty);
        _about.SettingsImported += (_, _) =>
        {
            LoadFromSettings();
            DatabaseChanged?.Invoke(this, EventArgs.Empty);
        };
        _subNav = new NavigationManager(pnlSubContent);
        SelectSubNavButton(btnNavBasic);
        ShowPage(_basic, Loc.Get("Options_Basic"), Loc.Get("Options_BasicSubtitle"));
    }

    private void ApplyLocalization()
    {
        btnNavBasic.Text = Loc.Get("Options_Basic");
        btnNavAdvanced.Text = Loc.Get("Options_Advanced");
        btnNavAi.Text = Loc.Get("Options_AI");
        btnNavAbout.Text = Loc.Get("Options_About");
        lblDonationTitle.Text = Loc.Get("Options_DonationTitle");
        lblDonationMessage.Text = Loc.Get("Options_DonationMessage");
        btnDonate.Text = Loc.Get("Options_Donate");
    }

    // MainForm also calls this when Options is left
    public void SaveCurrentPage()
    {
        if (!(_currentPage is ISettingsPage savable)) return;
        savable.Save();
        AppSettings.Instance.Save();
    }

    public void LoadFromSettings()
    {
        _basic.LoadFromSettings();
        _advanced.LoadFromSettings();
        _ai.LoadFromSettings();
    }

    private void NavBasic_Click(object? sender, EventArgs e)
    {
        SelectSubNavButton(btnNavBasic);
        ShowPage(_basic, Loc.Get("Options_Basic"), Loc.Get("Options_BasicSubtitle"));
    }

    private void NavAbout_Click(object? sender, EventArgs e)
    {
        SelectSubNavButton(btnNavAbout);
        ShowPage(_about, Loc.Get("Options_About"));
    }

    private void NavAdvanced_Click(object? sender, EventArgs e)
    {
        SelectSubNavButton(btnNavAdvanced);
        ShowPage(_advanced, Loc.Get("Options_Advanced"), Loc.Get("Options_AdvancedSubtitle"));
    }

    private void NavAi_Click(object? sender, EventArgs e)
    {
        SelectSubNavButton(btnNavAi);
        ShowPage(_ai, Loc.Get("Options_AI"), Loc.Get("Options_AiSubtitle"));
    }

    //opens the original CrapFixer PayPal donation with the chosen values
    private void BtnDonate_Click(object? sender, EventArgs e)
    {
        var amount = cboDonationAmount.SelectedItem?.ToString();
        var currency = cboDonationCurrency.SelectedItem?.ToString();
        if (string.IsNullOrEmpty(amount) || string.IsNullOrEmpty(currency)) return;

        var url = "https://www.paypal.com/cgi-bin/webscr?cmd=_donations" +
            "&business=" + Uri.EscapeDataString("belim@builtbybel.com") +
            "&amount=" + Uri.EscapeDataString(amount) +
            "&currency_code=" + Uri.EscapeDataString(currency) +
            "&item_name=" + Uri.EscapeDataString("Support development of CrapFixer") +
            "&return=" + Uri.EscapeDataString("https://github.com/Belim/support") +
            "&cancel_return=" + Uri.EscapeDataString("https://github.com/builtbybel/CrapFixer");
        try { Process.Start(new ProcessStartInfo(url) { UseShellExecute = true }); }
        catch { }
    }

    //hidden only until CrapFixer is started again
    private void BtnDonationClose_Click(object? sender, EventArgs e) => pnlDonation.Visible = false;

    private void ShowPage(Control page, string title, string subtitle = "")
    {
        SaveCurrentPage();
        lblPageTitle.Text = title;
        lblPageSubtitle.Text = subtitle;
        lblPageSubtitle.Visible = subtitle.Length > 0;
        _subNav.SwitchView(page);
        _currentPage = page;
    }

    //same fake selection as the main nav
    private void SelectSubNavButton(Button selected)
    {
        foreach (var button in new[] { btnNavBasic, btnNavAdvanced, btnNavAi, btnNavAbout })
            button.BackColor = button == selected ? Color.FromArgb(193, 210, 238) : Color.White;
    }
}
