using CrapFixer.Models;
using System.Text;

namespace CrapFixer.Services;

internal sealed class TweakerService
{
    private readonly RegistryService _registry = new RegistryService();

    public Task ScanAsync(TweakItem tweak)
    {
        return Task.Run(() =>
        {
            //all entries must match, not just Path/ValueName number one
            var applied = true;
            var first = true;
            foreach (var entry in tweak.AllEntries())
            {
                string? current;
                var matches = _registry.IsEntryApplied(entry, out current);
                if (first) tweak.CurrentValue = current;
                first = false;
                if (!matches) applied = false;
            }
            tweak.Status = applied ? TweakStatus.Applied : TweakStatus.NotApplied;
        });
    }

    public Task<string?> ApplyAsync(TweakItem tweak) => Task.Run(() => _registry.Apply(tweak));
    public Task<string?> ResetAsync(TweakItem tweak) => Task.Run(() => _registry.Reset(tweak));

    //one timestamped backup per run
    public Task<string?> BackupAsync(IEnumerable<TweakItem> tweaks)
    {
        return Task.Run(() =>
        {
            try
            {
                var data = new StringBuilder("Windows Registry Editor Version 5.00\r\n\r\n");
                data.AppendLine($"; CrapFixer backup - {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                data.AppendLine();
                foreach (var tweak in tweaks) data.Append(_registry.ExportBackup(tweak));
                if (data.Length < 100) return null;

                var folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "CrapFixer", "Backups");
                Directory.CreateDirectory(folder);
                var path = Path.Combine(folder, $"backup_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.reg");
                File.WriteAllText(path, data.ToString(), Encoding.Unicode);
                return path;
            }
            catch { return null; }
        });
    }
}
