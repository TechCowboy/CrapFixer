using CrapFixer.Models;

namespace CrapFixer.Services;

// reads the same database as the modern app
internal sealed class Wintweak2Parser
{
    public Task<List<TweakItem>> ParseFileAsync(string path) => Task.Run(() => Parse(path));

    private static List<TweakItem> Parse(string path)
    {
        var result = new List<TweakItem>();
        if (!File.Exists(path)) return result;

        TweakItem? current = null;
        var adminExplicit = false;

        foreach (var raw in File.ReadLines(path))
        {
            var line = raw.Trim();
            if (line.Length == 0 || line.StartsWith(";")) continue;

            if (line.StartsWith("[") && line.EndsWith("]"))
            {
                Finish(result, current, adminExplicit);
                current = new TweakItem { Name = line.Substring(1, line.Length - 2).Trim() };
                adminExplicit = false;
                continue;
            }

            if (current == null) continue;
            var eq = line.IndexOf('=');
            if (eq < 1) continue;

            var key = line.Substring(0, eq).Trim();
            var value = StripComment(line.Substring(eq + 1).Trim());
            if (key.Equals("REQUIRESADMIN", StringComparison.OrdinalIgnoreCase)) adminExplicit = true;
            AssignKey(current, key, value);
        }

        Finish(result, current, adminExplicit);
        return result;
    }

    //finish previous section when a new [name] begins
    private static void Finish(List<TweakItem> result, TweakItem? item, bool adminExplicit)
    {
        if (item == null) return;
        if (!adminExplicit) item.RequiresAdmin = InferRequiresAdmin(item);
        if (!string.IsNullOrWhiteSpace(item.Key)) result.Add(item);
    }

    private static string StripComment(string value)
    {
        var pos = value.IndexOf(" ;", StringComparison.Ordinal);
        return pos < 0 ? value : value.Substring(0, pos).Trim();
    }

    private static void AssignKey(TweakItem item, string key, string value)
    {
        switch (key.ToUpperInvariant())
        {
            case "CATEGORY": item.Category = value; break;
            case "DESCRIPTION": item.Description = value; break;
            case "VALUENAME": item.ValueName = value; break;
            case "VALUETYPE": item.ValueType = value; break;
            case "RECOMMENDEDVALUE": item.RecommendedValue = value; break;
            case "DEFAULTVALUE": item.DefaultValue = value; break;
            case "OSVERSION": item.OsVersion = value; break;
            case "REQUIRESADMIN": item.RequiresAdmin = ParseBool(value); break;
            case "DEFAULTSELECTED": item.DefaultSelected = ParseBool(value); break;
            case "RESTART":
                item.RestartRequired = value.Equals("system", StringComparison.OrdinalIgnoreCase);
                item.RestartExplorer = value.Equals("explorer", StringComparison.OrdinalIgnoreCase);
                break;
            case "PATH":
                var primary = SplitPath(value);
                item.Hive = primary.Item1;
                item.Key = primary.Item2;
                break;
            default:
                if (SetNumbered(item, key, "PATH", value)) break;
                if (SetNumbered(item, key, "VALUENAME", value)) break;
                if (SetNumbered(item, key, "VALUETYPE", value)) break;
                if (SetNumbered(item, key, "RECOMMENDEDVALUE", value)) break;
                SetNumbered(item, key, "DEFAULTVALUE", value);
                break;
        }
    }

    //Path2, ValueName2 and friends belong to the same tweak
    private static bool SetNumbered(TweakItem item, string key, string prefix, string value)
    {
        if (!key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)) return false;
        int index;
        if (!int.TryParse(key.Substring(prefix.Length), out index) || index < 2) return false;

        while (item.AdditionalEntries.Count < index - 1)
            item.AdditionalEntries.Add(new TweakRegistryEntry());

        var entry = item.AdditionalEntries[index - 2];
        switch (prefix)
        {
            case "PATH":
                var path = SplitPath(value);
                entry.Hive = path.Item1;
                entry.Key = path.Item2;
                break;
            case "VALUENAME": entry.ValueName = value; break;
            case "VALUETYPE": entry.ValueType = value; break;
            case "RECOMMENDEDVALUE": entry.RecommendedValue = value; break;
            case "DEFAULTVALUE": entry.DefaultValue = value; break;
        }
        return true;
    }

    private static Tuple<string, string> SplitPath(string path)
    {
        var sep = path.IndexOf('\\');
        if (sep <= 0) return Tuple.Create(path.TrimEnd(':'), "");
        return Tuple.Create(path.Substring(0, sep).TrimEnd(':'), path.Substring(sep + 1));
    }

    private static bool InferRequiresAdmin(TweakItem item)
    {
        return item.AllEntries().Any(entry =>
            entry.Hive.Equals("HKLM", StringComparison.OrdinalIgnoreCase) ||
            entry.Hive.Equals("HKEY_LOCAL_MACHINE", StringComparison.OrdinalIgnoreCase) ||
            entry.Hive.Equals("HKCR", StringComparison.OrdinalIgnoreCase) ||
            entry.Hive.Equals("HKEY_CLASSES_ROOT", StringComparison.OrdinalIgnoreCase) ||
            entry.Key.IndexOf("\\Policies\\", StringComparison.OrdinalIgnoreCase) >= 0 ||
            entry.Key.StartsWith("Policies\\", StringComparison.OrdinalIgnoreCase));
    }

    private static bool ParseBool(string value) =>
        value.Equals("true", StringComparison.OrdinalIgnoreCase) || value == "1";
}
