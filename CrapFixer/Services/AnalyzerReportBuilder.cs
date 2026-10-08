using CrapFixer.Models;
using System.Text;

namespace CrapFixer.Services;

// turns the visible result rows into text for the online analyzer
internal static class AnalyzerReportBuilder
{
    // creates the text copied from CrapFixer to the web page
    public static string Build(IEnumerable<ListViewItem> source)
    {
        var rows = source.ToList();
        var problems = rows.Count(IsProblem);
        var text = new StringBuilder();

        text.AppendLine("CRAPFIXER_RESULTS_V1");
        text.AppendLine("META\tVersion\t" + AppInfo.DisplayVersion);
        text.AppendLine("META\tGenerated\t" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        text.AppendLine($"SUMMARY\t{rows.Count}\t{problems}\t{rows.Count - problems}");

        foreach (var row in rows)
        {
            var status = row.SubItems[1].Text;
            var current = row.SubItems.Count > 2 ? row.SubItems[2].Text : "";
            //reports keep the stable ini name, not its translated list text
            var originalName = row.Tag is TweakItem tagged ? tagged.Name : row.Text;
            text.AppendLine(string.Join("\t", "RESULT", IsProblem(row) ? "ISSUE" : "OK",
                Clean(originalName), Clean(status), Clean(current)));

            if (!(row.Tag is TweakItem tweak)) continue;
            foreach (var entry in tweak.AllEntries())
            {
                var path = entry.Hive + "\\" + entry.Key + "\\" + entry.ValueName;
                text.AppendLine(string.Join("\t", "REGISTRY", Clean(tweak.Name),
                    Clean(path), Clean(entry.RecommendedValue)));
            }
        }

        return text.ToString();
    }

    // tabs are separators in the report, so remove them from values
    private static string Clean(string value) =>
        (value ?? "").Replace('\t', ' ').Replace('\r', ' ').Replace('\n', ' ').Trim();

    private static bool IsProblem(ListViewItem row) => row.ForeColor == Color.Firebrick;
}
