using CrapFixer.Services;

namespace CrapFixer.Views.Settings;

//backup and confirmation options stay away from the database page
public partial class AdvancedSettingsView : UserControl, ISettingsPage
{
    public AdvancedSettingsView()
    {
        InitializeComponent();
        ApplyLocalization();
        LoadFromSettings();
    }

    private void ApplyLocalization()
    {
        chkBackup.Text = Loc.Get("Advanced_Backup");
        chkConfirm.Text = Loc.Get("Advanced_Confirm");
        btnOpenBackup.Text = Loc.Get("Advanced_OpenBackup");
    }

    public void LoadFromSettings()
    {
        chkBackup.Checked = AppSettings.Instance.BackupBeforeApply;
        chkConfirm.Checked = AppSettings.Instance.ConfirmActions;
    }

    public void Save()
    {
        AppSettings.Instance.BackupBeforeApply = chkBackup.Checked;
        AppSettings.Instance.ConfirmActions = chkConfirm.Checked;
    }

    private void BtnOpenBackup_Click(object? sender, EventArgs e)
    {
        var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "CrapFixer", "Backups");
        Directory.CreateDirectory(path);
        try { System.Diagnostics.Process.Start("explorer.exe", path); }
        catch { }
    }
}
