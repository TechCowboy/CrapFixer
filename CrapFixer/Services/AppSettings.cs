using System.Text.Json;
using System.Text.Json.Serialization;

namespace CrapFixer.Services;

//one json for window, behavior and checked tweaks
public sealed class AppSettings
{
    public static AppSettings Instance { get; private set; } = null!;

    private static readonly string PortablePath = Path.Combine(AppContext.BaseDirectory, "settings.json");
    private static readonly string RoamingPath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
        "CrapFixer", "settings.json");
    private static readonly string SettingsFile = File.Exists(PortablePath) ? PortablePath : RoamingPath;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };

    static AppSettings() => Instance = Load();

    [JsonIgnore]
    public static bool IsPortable => SettingsFile == PortablePath;

    public int WindowWidth { get; set; } = 889;
    public int WindowHeight { get; set; } = 547;
    public int WindowX { get; set; } = -1;
    public int WindowY { get; set; } = -1;
    public int WindowState { get; set; }
    public bool BackupBeforeApply { get; set; } = true;
    public bool ConfirmActions { get; set; } = true;
    public string UiLanguage { get; set; } = "";
    public bool EnableBuiltInDatabase { get; set; } = true;
    public string? CustomDbPath { get; set; }
    public bool SelectionInitialized { get; set; }
    public string AiProvider { get; set; } = "Groq";
    public string? GroqApiKey { get; set; }
    public string? OpenAiApiKey { get; set; }
    public string? AnthropicApiKey { get; set; }
    public string? OpenAiCompatibleApiKey { get; set; }
    public string OpenAiCompatibleEndpoint { get; set; } = "https://openrouter.ai/api/v1/chat/completions";
    public string OpenAiCompatibleModel { get; set; } = "";

    public HashSet<string> SelectedTweaks { get; set; } = new();

    //writes the complete model, no second selection file
    public void Save()
    {
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(SettingsFile)!);
            File.WriteAllText(SettingsFile, JsonSerializer.Serialize(this, JsonOptions));
        }
        catch { }
    }

    private static AppSettings Load()
    {
        try
        {
            if (!File.Exists(SettingsFile)) return new AppSettings();
            var settings = JsonSerializer.Deserialize<AppSettings>(File.ReadAllText(SettingsFile), JsonOptions)
                ?? new AppSettings();
            settings.CustomDbPath = NormalizeFile(settings.CustomDbPath);
            return settings;
        }
        catch { return new AppSettings(); }
    }

    //writes a settings copy selected in the About page
    public static void ExportTo(string path) =>
        File.WriteAllText(path, JsonSerializer.Serialize(Instance, JsonOptions));

    //makes the selected json file the current settings
    public static void ImportFrom(string path)
    {
        var settings = JsonSerializer.Deserialize<AppSettings>(File.ReadAllText(path), JsonOptions)
            ?? new AppSettings();
        settings.CustomDbPath = NormalizeFile(settings.CustomDbPath);
        Instance = settings;
        Instance.Save();
    }

    private static string? NormalizeFile(string? path)
    {
        if (string.IsNullOrWhiteSpace(path)) return null;
        try { return Path.GetFullPath(Environment.ExpandEnvironmentVariables(path!.Trim().Trim('"'))); }
        catch { return path; }
    }
}
