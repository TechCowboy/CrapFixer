using CrapFixer.Models;

namespace CrapFixer.Services;

internal sealed class WinappxParser
{
    public Task<List<AppxItem>> ParseFileAsync(string path) => Task.Run(() => Parse(path));

    private static List<AppxItem> Parse(string path)
    {
        var items = new List<AppxItem>();
        if (!File.Exists(path)) return items;
        AppxItem? current = null;

        foreach (var raw in File.ReadLines(path))
        {
            var line = raw.Trim();
            if (line.Length == 0 || line.StartsWith(";")) continue;

            if (line.StartsWith("[") && line.EndsWith("]"))
            {
                AddCurrent(items, current);
                current = new AppxItem { Name = line.Substring(1, line.Length - 2).Trim() };
                continue;
            }

            if (current == null) continue;
            var eq = line.IndexOf('=');
            if (eq < 1) continue;
            var key = line.Substring(0, eq).Trim();
            var value = line.Substring(eq + 1).Trim();
            var comment = value.IndexOf(" ;", StringComparison.Ordinal);
            if (comment >= 0) value = value.Substring(0, comment).Trim();

            if (key.Equals("Category", StringComparison.OrdinalIgnoreCase)) current.Category = value;
            else if (key.Equals("PackageName", StringComparison.OrdinalIgnoreCase)) current.PackageName = value;
            else if (key.Equals("DefaultSelected", StringComparison.OrdinalIgnoreCase))
                current.DefaultSelected = value.Equals("true", StringComparison.OrdinalIgnoreCase);
        }

        AddCurrent(items, current);
        return items;
    }

    private static void AddCurrent(List<AppxItem> items, AppxItem? item)
    {
        if (item != null && !string.IsNullOrWhiteSpace(item.PackageName)) items.Add(item);
    }
}
