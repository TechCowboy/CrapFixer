namespace CrapFixer.Services;

//Custom tweaks are small ini files, disabled ones only get another suffix
internal static class CustomTweakService
{
    public static string CustomDir => Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "CrapFixer", "CustomTweaks");

    internal sealed class Entry
    {
        public string Name { get; set; } = "";
        public string FilePath { get; set; } = "";
        public bool Enabled { get; set; }
    }

    public static List<Entry> ListAll()
    {
        var result = new List<Entry>();
        if (!Directory.Exists(CustomDir)) return result;

        foreach (var path in Directory.GetFiles(CustomDir, "*.ini*"))
        {
            var file = Path.GetFileName(path);
            var disabled = file.EndsWith(".ini.disabled", StringComparison.OrdinalIgnoreCase);
            if (!disabled && !file.EndsWith(".ini", StringComparison.OrdinalIgnoreCase)) continue;

            var suffix = disabled ? ".ini.disabled" : ".ini";
            result.Add(new Entry
            {
                Name = file.Substring(0, file.Length - suffix.Length),
                FilePath = path,
                Enabled = !disabled
            });
        }
        return result.OrderBy(entry => entry.Name, StringComparer.OrdinalIgnoreCase).ToList();
    }

    public static IEnumerable<string> EnabledFiles() => ListAll()
        .Where(entry => entry.Enabled).Select(entry => entry.FilePath);

    public static string ReadBody(string path)
    {
        var text = File.ReadAllText(path).Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", "\r\n");
        var newline = text.IndexOf('\n');
        return newline < 0 ? "" : text.Substring(newline + 1).TrimStart('\r', '\n');
    }

    public static void Save(string name, string body, string? replacingPath, bool enabled)
    {
        Directory.CreateDirectory(CustomDir);
        if (replacingPath != null && File.Exists(replacingPath)) File.Delete(replacingPath);

        var safeName = string.Concat(name.Split(Path.GetInvalidFileNameChars()));
        var suffix = enabled ? ".ini" : ".ini.disabled";
        File.WriteAllText(Path.Combine(CustomDir, safeName + suffix),
            $"[{name}]{Environment.NewLine}{body.TrimStart()}");
    }

    public static void SetEnabled(Entry entry, bool enabled)
    {
        if (entry.Enabled == enabled) return;
        var target = enabled
            ? entry.FilePath.Substring(0, entry.FilePath.Length - ".disabled".Length)
            : entry.FilePath + ".disabled";
        File.Move(entry.FilePath, target);
        entry.FilePath = target;
        entry.Enabled = enabled;
    }

    public static void Delete(Entry entry)
    {
        if (File.Exists(entry.FilePath)) File.Delete(entry.FilePath);
    }

    public const string Template =
        "Category=Custom\r\n" +
        "Description=Describe what this tweak changes.\r\n" +
        "Path=HKEY_CURRENT_USER\\Software\\MyApp\r\n" +
        "ValueName=Enabled\r\n" +
        "ValueType=DWORD\r\n" +
        "RecommendedValue=1\r\n" +
        "DefaultValue=0\r\n" +
        "DefaultSelected=false\r\n";
}
