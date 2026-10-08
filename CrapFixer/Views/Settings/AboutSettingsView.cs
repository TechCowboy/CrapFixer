using System.Diagnostics;
using CrapFixer.Services;

namespace CrapFixer.Views.Settings;

// static info page, kept separate like the other settings views
public partial class AboutSettingsView : UserControl
{
    public event EventHandler? SettingsImported;

    public AboutSettingsView()
    {
        InitializeComponent();
        ApplyLocalization();
        lblVersion.Text = Loc.Format("About_Version", AppInfo.DisplayVersion);
        lblPortableMode.Left = lblVersion.Right;
        lblPortableMode.Visible = AppSettings.IsPortable;

        var iconPath = Path.Combine(AppContext.BaseDirectory, "Assets", "AppIcon.png");
        if (File.Exists(iconPath)) picIcon.Image = Image.FromFile(iconPath);
    }

    private void ApplyLocalization()
    {
        lblPortableMode.Text = Loc.Get("About_Portable");
        lblDescription.Text = Loc.Get("About_Description");
        lnkIssues.Text = Loc.Get("About_ReportIssue");
        lnkHelp.Text = Loc.Get("About_Help");
        lblSettingsBackupDesc.Text = Loc.Get("About_SettingsBackup");
        btnExport.Text = Loc.Get("About_Export");
        btnImport.Text = Loc.Get("About_Import");
        lnkTranslator.Text = Loc.Format("About_TranslationBy", Loc.TranslatorName);
        lnkTranslator.Visible = Loc.TranslatorName.Length > 0;
    }

    private void LnkGitHub_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e) =>
        OpenUrl("https://github.com/builtbybel/CrapFixer");

    private void LnkIssues_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e) =>
        OpenUrl("https://github.com/builtbybel/CrapFixer/issues");

    private void LnkHelp_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e) =>
        OpenUrl("https://github.com/builtbybel/CrapFixer");

    private void LnkTranslator_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        if (Loc.TranslatorUrl.Length > 0) OpenUrl(Loc.TranslatorUrl);
    }

    private void BtnExport_Click(object? sender, EventArgs e)
    {
        using var dialog = new SaveFileDialog
        {
            Filter = Loc.Get("Common_JsonFilter"),
            Title = Loc.Get("About_ExportTitle"),
            FileName = "settings.json",
            DefaultExt = "json",
            AddExtension = true
        };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;

        try
        {
            AppSettings.ExportTo(dialog.FileName);
            ShowSettingsStatus(Loc.Format("About_Exported", Path.GetFileName(dialog.FileName)), false);
        }
        catch (Exception ex) { ShowSettingsStatus(Loc.Format("About_ExportFailed", ex.Message), true); }
    }

    private void BtnImport_Click(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Filter = Loc.Get("Common_JsonFilter"),
            Title = Loc.Get("About_ImportTitle"),
            CheckFileExists = true
        };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;

        try
        {
            AppSettings.ImportFrom(dialog.FileName);
            SettingsImported?.Invoke(this, EventArgs.Empty);
            ShowSettingsStatus(Loc.Get("About_Imported"), false);
        }
        catch (Exception ex) { ShowSettingsStatus(Loc.Format("About_ImportFailed", ex.Message), true); }
    }

    private void ShowSettingsStatus(string text, bool error)
    {
        lblSettingsStatus.ForeColor = error ? Color.Firebrick : Color.SeaGreen;
        lblSettingsStatus.Text = text;
    }

    private static void OpenUrl(string url)
    {
        try { Process.Start(new ProcessStartInfo(url) { UseShellExecute = true }); }
        catch { }
    }

    protected override void OnHandleDestroyed(EventArgs e)
    {
        if (Disposing) picIcon.Image?.Dispose();
        base.OnHandleDestroyed(e);
    }
}
