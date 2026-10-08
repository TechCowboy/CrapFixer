using System.Net.Http;

namespace CrapFixer.Features.Extensions;

// reads only the small extension catalog, not tweak ini files
internal sealed class ExtensionCatalog
{
    internal const string CatalogUrl =
        "https://raw.githubusercontent.com/builtbybel/CrapFixer/main/docs/extensions.ini";

    private static readonly HttpClient Client = new() { Timeout = TimeSpan.FromSeconds(20) };

    private static string CachePath => Path.Combine(ExtensionService.AppFolder, "Extensions", "catalog.ini");

    public async Task<List<ExtensionInfo>> DownloadAsync()
    {
        try
        {
            var text = await Client.GetStringAsync(CatalogUrl);
            Directory.CreateDirectory(Path.GetDirectoryName(CachePath)!);
            File.WriteAllText(CachePath, text);
            return Parse(text);
        }
        catch
        {
            if (File.Exists(CachePath)) return Parse(File.ReadAllText(CachePath));
            var bundled = Path.Combine(ExtensionService.AppFolder, "Extensions", "extensions.ini");
            if (File.Exists(bundled)) return Parse(File.ReadAllText(bundled));
            throw;
        }
    }

    // turns the small ini catalog into extension entries
    internal static List<ExtensionInfo> Parse(string text)
    {
        var result = new List<ExtensionInfo>();
        ExtensionInfo? current = null;

        void AddCurrent()
        {
            if (current == null || !IsScript(current.Url)) return;
            result.Add(current);
        }

        foreach (var raw in text.Replace("\r", "").Split('\n'))
        {
            var line = raw.Trim();
            if (line.Length == 0 || line.StartsWith(";", StringComparison.Ordinal)) continue;
            if (line.StartsWith("[", StringComparison.Ordinal) && line.EndsWith("]", StringComparison.Ordinal))
            {
                AddCurrent();
                current = new ExtensionInfo { Name = line.Substring(1, line.Length - 2).Trim() };
                continue;
            }
            if (current == null) continue;

            var equals = line.IndexOf('=');
            if (equals < 1)
            {
                current.Description = JoinDescription(current.Description, line);
                continue;
            }

            var key = line.Substring(0, equals).Trim();
            var value = line.Substring(equals + 1).Trim();
            if (key.Equals("description", StringComparison.OrdinalIgnoreCase)) current.Description = value;
            else if (key.Equals("url", StringComparison.OrdinalIgnoreCase)) current.Url = value;
            else if (key.Equals("version", StringComparison.OrdinalIgnoreCase)) current.Version = value;
            else if (key.Equals("sha256", StringComparison.OrdinalIgnoreCase)) current.Sha256 = value;
            else if (key.Equals("requiresAdmin", StringComparison.OrdinalIgnoreCase))
                current.RequiresAdmin = value.Equals("true", StringComparison.OrdinalIgnoreCase);
        }
        AddCurrent();
        return result.OrderBy(item => item.Name, StringComparer.OrdinalIgnoreCase).ToList();
    }

    private static bool IsScript(string url) =>
        Uri.TryCreate(url, UriKind.Absolute, out var uri) && uri.AbsolutePath.EndsWith(".ps1", StringComparison.OrdinalIgnoreCase);

    private static string JoinDescription(string current, string line) =>
        current.Length == 0 ? line : current + " " + line;
}
