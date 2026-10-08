using System.Globalization;
using System.Text.Json;

namespace CrapFixer.Services;

//loads loose json files so translations dont need a new build
internal static class Loc
{
    private const string FallbackLocale = "en";
    private static readonly string Folder = Path.Combine(AppContext.BaseDirectory, "Localization");
    private static Dictionary<string, string> _fallback = new(StringComparer.OrdinalIgnoreCase);
    private static Dictionary<string, string> _current = new(StringComparer.OrdinalIgnoreCase);

    public static string CurrentLocale { get; private set; } = FallbackLocale;
    public static string TranslatorName => GetMeta("_Meta_TranslatorName");
    public static string TranslatorUrl => GetMeta("_Meta_TranslatorUrl");

    //empty locale follows the Windows display language
    public static void Init(string? locale)
    {
        _fallback = ReadLanguage(FallbackLocale);
        var requested = string.IsNullOrWhiteSpace(locale)
            ? CultureInfo.CurrentUICulture.Name : locale!.Trim();
        CurrentLocale = FindLocale(requested);
        _current = CurrentLocale.Equals(FallbackLocale, StringComparison.OrdinalIgnoreCase)
            ? _fallback : ReadLanguage(CurrentLocale);

        try
        {
            var culture = CultureInfo.GetCultureInfo(CurrentLocale);
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
        }
        catch { }
    }

    public static string Get(string key)
    {
        if (_current.TryGetValue(key, out var value) && value.Length > 0) return value;
        if (_fallback.TryGetValue(key, out value) && value.Length > 0) return value;
        return key;
    }

    public static string Format(string key, params object[] args) =>
        string.Format(CultureInfo.CurrentCulture, Get(key), args);

    //name shown in the UI, raw name still works as the id
    public static string TweakName(string name) => GetOrOriginal("Tweak_Name_" + name, name);

    //same small override for tooltips and details
    public static string TweakDescription(string name, string description) =>
        GetOrOriginal("Tweak_Description_" + name, description);

    //category header can be translated too
    public static string TweakCategory(string category) =>
        GetOrOriginal("Tweak_Category_" + category, category);

    //the combo box is built from whatever json files are in the folder
    public static IReadOnlyList<LanguageInfo> GetAvailableLanguages()
    {
        var result = new List<LanguageInfo>();
        if (!Directory.Exists(Folder)) return result;

        foreach (var path in Directory.GetFiles(Folder, "*.json").OrderBy(path => path))
        {
            var locale = Path.GetFileNameWithoutExtension(path);
            var values = ReadFile(path);
            var name = values.TryGetValue("_Meta_LanguageDisplayName", out var display) && display.Length > 0
                ? display : locale;
            result.Add(new LanguageInfo(locale, name));
        }
        return result;
    }

    public static string LocalizationFolder => Folder;

    private static string GetMeta(string key) =>
        _current.TryGetValue(key, out var value) ? value : "";

    //new database entries just fall back to their ini text
    private static string GetOrOriginal(string key, string original)
    {
        if (_current.TryGetValue(key, out var value) && value.Length > 0) return value;
        if (_fallback.TryGetValue(key, out value) && value.Length > 0) return value;
        return original;
    }

    private static string FindLocale(string requested)
    {
        var files = GetAvailableLanguages();
        var exact = files.FirstOrDefault(item => item.Locale.Equals(requested, StringComparison.OrdinalIgnoreCase));
        if (exact != null) return exact.Locale;

        var dash = requested.IndexOf('-');
        var neutral = dash > 0 ? requested.Substring(0, dash) : requested;
        var close = files.FirstOrDefault(item => item.Locale.Equals(neutral, StringComparison.OrdinalIgnoreCase));
        return close?.Locale ?? FallbackLocale;
    }

    private static Dictionary<string, string> ReadLanguage(string locale) =>
        ReadFile(Path.Combine(Folder, locale + ".json"));

    private static Dictionary<string, string> ReadFile(string path)
    {
        try
        {
            if (!File.Exists(path)) return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var values = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(path));
            return values == null
                ? new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                : new Dictionary<string, string>(values, StringComparer.OrdinalIgnoreCase);
        }
        catch { return new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase); }
    }
}

internal sealed class LanguageInfo
{
    public LanguageInfo(string locale, string displayName)
    {
        Locale = locale;
        DisplayName = displayName;
    }

    public string Locale { get; }
    public string DisplayName { get; }
    public override string ToString() => DisplayName;
}
