using System.Text;
using CrapFixer.Models;

namespace CrapFixer.Features.AI;

//builds the safe tweak data sent to the selected provider
internal static class TweakPromptBuilder
{
    public static string Build(TweakItem tweak)
    {
        var text = new StringBuilder();
        text.AppendLine($"Explain the Windows registry tweak \"{tweak.Name}\".");
        if (tweak.Description.Length > 0) text.AppendLine("Database description: " + tweak.Description);

        text.AppendLine("Registry changes:");
        foreach (var entry in tweak.AllEntries())
        {
            text.AppendLine($"- {entry.Hive}\\{entry.Key}\\{entry.ValueName}");
            text.AppendLine($"  type={entry.ValueType}, recommended={entry.RecommendedValue}, Windows default={entry.DefaultValue}");
        }

        if (tweak.RequiresAdmin) text.AppendLine("Administrator rights are required.");
        if (tweak.RestartExplorer) text.AppendLine("Windows Explorer must be restarted.");
        if (tweak.RestartRequired) text.AppendLine("Windows must be restarted.");
        text.AppendLine("Explain what it changes, the practical benefit and possible trade-offs in 3-5 short sentences.");
        return text.ToString();
    }
}
