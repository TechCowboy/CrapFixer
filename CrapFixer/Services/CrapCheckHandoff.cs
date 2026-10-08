using System.Text.Json;
using CrapFixer.Views;
using CrapFixer.Views.Tools;

namespace CrapFixer.Services;

/*
 * crapcheckthis handoff lives here: JSON names in, a fresh local scan out.
 * Windows goes to TweakerView, packages go to App Remover. no apply or remove.
 * UAC restarts get their own temp selection so the first process can safely close.
 */
internal static class CrapCheckHandoff
{
    private const string Switch = "/FROMCRAPCHECK";
    private const string AppsSwitch = "/FROMCRAPCHECK-APPS";

    private static bool IsRequested(IEnumerable<string> args, string flag = Switch) =>
        args.Any(arg => arg.Equals(flag, StringComparison.OrdinalIgnoreCase));

    internal static bool IsAppRequest(IEnumerable<string> args) => IsRequested(args, AppsSwitch);

    // called once by MainForm.OnShown; ordinary launches skip the entire handoff
    public static Task ReceiveAsync(TweakerView view, string[] args) =>
        ReceiveAsync(view, args, Switch, view.AnalyzeCrapCheckThisHandoffAsync, "Handoff_Skipped");

    public static Task ReceiveAppsAsync(AppRemoverView view, string[] args) =>
        ReceiveAsync(view, args, AppsSwitch, view.AnalyzeCrapCheckThisHandoffAsync, "Handoff_AppsSkipped");

    // both pages share the same small file reader and error messages
    private static async Task ReceiveAsync(Control view, string[] args, string flag,
        Func<HashSet<string>, Task<List<string>>> scan, string skippedKey)
    {
        if (!IsRequested(args, flag)) return;
        try
        {
            var skipped = await scan(ReadSelection(args, flag));
            if (view.IsDisposed || skipped.Count == 0) return;
            MessageBox.Show(view, Loc.Format(skippedKey, skipped.Count,
                    string.Join(Environment.NewLine, skipped.Take(8))), Loc.Get("Handoff_Title"),
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            if (!view.IsDisposed)
                MessageBox.Show(view, Loc.Format("Handoff_Failed", ex.Message), Loc.Get("Handoff_Title"),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    // bounded names only; incoming registry paths, values and commands aren't supported
    internal static HashSet<string> ReadSelection(string[] args, string flag = Switch)
    {
        var index = Array.FindIndex(args, arg => arg.Equals(flag, StringComparison.OrdinalIgnoreCase));
        if (index < 0 || index + 1 >= args.Length ||
            args.Count(arg => arg.Equals(Switch, StringComparison.OrdinalIgnoreCase) ||
                              arg.Equals(AppsSwitch, StringComparison.OrdinalIgnoreCase)) != 1 ||
            args.Any(arg => arg.Equals("/AUTO", StringComparison.OrdinalIgnoreCase) ||
                            arg.Equals("/SHUTDOWN", StringComparison.OrdinalIgnoreCase)))
            throw new InvalidDataException(Loc.Get("Handoff_Invalid"));

        using var stream = File.OpenRead(args[index + 1]);
        if (stream.Length == 0 || stream.Length > 1024 * 1024)
            throw new InvalidDataException(Loc.Get("Handoff_Invalid"));
        var names = JsonSerializer.Deserialize<string[]>(stream);
        if (names == null || names.Length == 0 || names.Length > 5000 ||
            names.Any(name => string.IsNullOrWhiteSpace(name) || name.Length > 512 ||
                              name.IndexOfAny(new[] { '\r', '\n', '\0' }) >= 0))
            throw new InvalidDataException(Loc.Get("Handoff_Invalid"));
        return new HashSet<string>(names, StringComparer.OrdinalIgnoreCase);
    }

    // keep this action's scope through UAC, without saving it as the user's defaults
    internal static string GetAdministratorRestartArguments(IEnumerable<string> names)
    {
        if (!IsRequested(Environment.GetCommandLineArgs())) return "";
        var folder = Path.Combine(Path.GetTempPath(), "CrapFixer");
        Directory.CreateDirectory(folder);
        var path = Path.Combine(folder, "handoff-" + Guid.NewGuid().ToString("N") + ".json");
        using (var stream = new FileStream(path, FileMode.CreateNew, FileAccess.Write))
            JsonSerializer.Serialize(stream, names.Distinct(StringComparer.OrdinalIgnoreCase).ToArray());
        // stays in Temp: the old process must not delete it while the new one loads
        return Switch + " \"" + path + "\"";
    }
}
