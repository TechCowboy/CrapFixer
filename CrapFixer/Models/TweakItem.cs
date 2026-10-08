namespace CrapFixer.Models;

internal enum TweakStatus { Applied, NotApplied }

internal sealed class TweakRegistryEntry
{
    public string Hive { get; set; } = "";
    public string Key { get; set; } = "";
    public string ValueName { get; set; } = "";
    public string ValueType { get; set; } = "DWORD";
    public string RecommendedValue { get; set; } = "";
    public string DefaultValue { get; set; } = "";
}

internal sealed class TweakItem
{
    public string Name { get; set; } = "";
    public string Category { get; set; } = "";
    public string Description { get; set; } = "";
    public string Hive { get; set; } = "";
    public string Key { get; set; } = "";
    public string ValueName { get; set; } = "";
    public string ValueType { get; set; } = "DWORD";
    public string RecommendedValue { get; set; } = "";
    public string DefaultValue { get; set; } = "";
    public List<TweakRegistryEntry> AdditionalEntries { get; } = new List<TweakRegistryEntry>();
    public bool RestartRequired { get; set; }
    public bool RestartExplorer { get; set; }
    public bool RequiresAdmin { get; set; }
    public bool DefaultSelected { get; set; }
    public string? OsVersion { get; set; }
    public TweakStatus? Status { get; set; }
    public string? CurrentValue { get; set; }

    public IEnumerable<TweakRegistryEntry> AllEntries()
    {
        yield return new TweakRegistryEntry
        {
            Hive = Hive,
            Key = Key,
            ValueName = ValueName,
            ValueType = ValueType,
            RecommendedValue = RecommendedValue,
            DefaultValue = DefaultValue
        };

        foreach (var entry in AdditionalEntries)
            yield return entry;
    }
}
