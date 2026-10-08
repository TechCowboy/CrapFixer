namespace CrapFixer;

using CrapFixer.Services;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        Loc.Init(AppSettings.Instance.UiLanguage);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}
