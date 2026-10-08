using CrapFixer.Services;
using System.Diagnostics;

namespace CrapFixer.Views.Settings;

//first settings page, language plus database sources
public partial class BasicSettingsView : UserControl, ISettingsPage
{
    private bool _loadingLanguage;
    public event EventHandler? DatabaseChanged;

    public BasicSettingsView()
    {
        InitializeComponent();
        ApplyLocalization();
        LoadLanguages();
        LoadFromSettings();
    }

    //sets the designer texts from the active json file
    private void ApplyLocalization()
    {
        lblLanguage.Text = Loc.Get("Basic_Language");
        lnkOpenLocalization.Text = Loc.Get("Basic_OpenLocalization");
        lblDatabases.Text = Loc.Get("Basic_Databases");
        chkBuiltInDb.Text = Loc.Get("Basic_BuiltIn");
        lblWintweak2Desc.Text = Loc.Get("Basic_WintweakDesc");
        lblWinappxDesc.Text = Loc.Get("Basic_WinappxDesc");
        btnUpdateWintweak2.Text = btnUpdateWinappx.Text = Loc.Get("Basic_Update");
        chkCustomDb.Text = Loc.Get("Basic_CustomDb");
        btnBrowse.Text = Loc.Get("Basic_Browse");
        btnReload.Text = Loc.Get("Basic_Reload");
    }

    //loose json files appear here automatically
    private void LoadLanguages()
    {
        _loadingLanguage = true;
        cboLanguage.Items.Clear();
        cboLanguage.Items.Add(new LanguageChoice("", Loc.Get("Basic_SystemDefault")));
        foreach (var language in Loc.GetAvailableLanguages())
            cboLanguage.Items.Add(new LanguageChoice(language.Locale, language.DisplayName));

        SelectSavedLanguage();
        _loadingLanguage = false;
    }

    public void LoadFromSettings()
    {
        var settings = AppSettings.Instance;
        SelectSavedLanguage();
        chkBuiltInDb.Checked = settings.EnableBuiltInDatabase;
        chkCustomDb.Checked = !string.IsNullOrWhiteSpace(settings.CustomDbPath);
        txtCustomPath.Text = settings.CustomDbPath ?? "";
        UpdateCustomControls();
        RefreshDatabaseInfo();
    }

    private void SelectSavedLanguage()
    {
        if (cboLanguage.Items.Count == 0) return;
        _loadingLanguage = true;
        var saved = AppSettings.Instance.UiLanguage ?? "";
        cboLanguage.SelectedItem = cboLanguage.Items.Cast<LanguageChoice>()
            .FirstOrDefault(item => item.Locale.Equals(saved, StringComparison.OrdinalIgnoreCase));
        if (cboLanguage.SelectedIndex < 0) cboLanguage.SelectedIndex = 0;
        _loadingLanguage = false;
    }

    public void Save()
    {
        var settings = AppSettings.Instance;
        settings.EnableBuiltInDatabase = chkBuiltInDb.Checked;
        settings.CustomDbPath = chkCustomDb.Checked && txtCustomPath.Text.Trim().Length > 0
            ? txtCustomPath.Text.Trim() : null;
    }

    private void ChkCustomDb_CheckedChanged(object? sender, EventArgs e) => UpdateCustomControls();

    private void UpdateCustomControls()
    {
        txtCustomPath.Enabled = chkCustomDb.Checked;
        btnBrowse.Enabled = chkCustomDb.Checked;
    }

    private void BtnBrowse_Click(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Filter = Loc.Get("Common_IniFilter"),
            Title = Loc.Get("Basic_SelectDatabase"),
            CheckFileExists = true
        };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        txtCustomPath.Text = dialog.FileName;
        chkCustomDb.Checked = true;
    }

    private void BtnReload_Click(object? sender, EventArgs e)
    {
        if (chkCustomDb.Checked && !File.Exists(txtCustomPath.Text.Trim()))
        {
            ShowStatus(Loc.Get("Basic_CustomMissing"), true);
            return;
        }
        Save();
        AppSettings.Instance.Save();
        DatabaseChanged?.Invoke(this, EventArgs.Empty);
        RefreshDatabaseInfo();
        ShowStatus(Loc.Get("Basic_Reloaded"), false);
    }

    private async void BtnUpdateWintweak2_Click(object? sender, EventArgs e)
    {
        btnUpdateWintweak2.Enabled = false;
        try
        {
            await DatabaseUpdateService.UpdateWintweak2Async();
            chkBuiltInDb.Checked = true;
            Save();
            AppSettings.Instance.Save();
            RefreshDatabaseInfo();
            DatabaseChanged?.Invoke(this, EventArgs.Empty);
            ShowStatus(Loc.Get("Basic_WintweakUpdated"), false);
        }
        catch (Exception ex) { ShowStatus(Loc.Format("Basic_WintweakUpdateFailed", ex.Message), true); }
        finally { btnUpdateWintweak2.Enabled = true; }
    }

    private async void BtnUpdateWinappx_Click(object? sender, EventArgs e)
    {
        btnUpdateWinappx.Enabled = false;
        try
        {
            await DatabaseUpdateService.UpdateWinappxAsync();
            RefreshDatabaseInfo();
            ShowStatus(Loc.Get("Basic_WinappxUpdated"), false);
        }
        catch (Exception ex) { ShowStatus(Loc.Format("Basic_WinappxUpdateFailed", ex.Message), true); }
        finally { btnUpdateWinappx.Enabled = true; }
    }

    private void RefreshDatabaseInfo()
    {
        SetFileInfo(lblWintweak2Info, DatabaseUpdateService.Wintweak2LocalPath);
        SetFileInfo(lblWinappxInfo, DatabaseUpdateService.WinappxLocalPath);
    }

    private static void SetFileInfo(Label label, string path)
    {
        label.Text = File.Exists(path)
            ? Loc.Format("Basic_LastUpdated", File.GetLastWriteTime(path).ToString("g"))
            : Loc.Get("Basic_FileNotFound");
    }

    private void LnkOpenLocalization_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        Directory.CreateDirectory(Loc.LocalizationFolder);
        try { Process.Start("explorer.exe", Loc.LocalizationFolder); }
        catch { }
    }

    //language is saved now and loaded once on the next start
    private void CboLanguage_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_loadingLanguage || !(cboLanguage.SelectedItem is LanguageChoice selected)) return;
        if (selected.Locale.Equals(AppSettings.Instance.UiLanguage ?? "", StringComparison.OrdinalIgnoreCase)) return;
        AppSettings.Instance.UiLanguage = selected.Locale;
        AppSettings.Instance.Save();

        if (MessageBox.Show(this, Loc.Get("Basic_LanguageRestart"), Loc.Get("Basic_LanguageRestartTitle"),
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        try
        {
            Process.Start(new ProcessStartInfo(Application.ExecutablePath)
            {
                WorkingDirectory = AppContext.BaseDirectory,
                UseShellExecute = true
            });
            FindForm()?.Close();
        }
        catch { }
    }

    private void ShowStatus(string text, bool error)
    {
        lblDatabaseStatus.ForeColor = error ? Color.Firebrick : Color.SeaGreen;
        lblDatabaseStatus.Text = text;
    }

    private sealed class LanguageChoice
    {
        public LanguageChoice(string locale, string name) { Locale = locale; Name = name; }
        public string Locale { get; }
        public string Name { get; }
        public override string ToString() => Name;
    }
}
