using CrapFixer.Models;
using System.Diagnostics;

namespace CrapFixer.Services;

internal sealed class AppxService
{
    public async Task<string?> ScanAllAsync(IEnumerable<AppxItem> items)
    {
        //query once; starting powershell for every ini entry would be painfully slow
        var result = await RunPowerShellAsync("Get-AppxPackage | ForEach-Object { $_.Name + '|' + $_.PackageFullName }");
        if (string.IsNullOrWhiteSpace(result.Item1) && !string.IsNullOrWhiteSpace(result.Item2))
            return Loc.Format("AppRemover_PowerShellError", result.Item2.Trim());

        var installed = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var raw in result.Item1.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
        {
            var line = raw.Trim();
            var pipe = line.IndexOf('|');
            if (pipe > 0) installed[line.Substring(0, pipe)] = line.Substring(pipe + 1);
        }

        foreach (var item in items)
        {
            var match = installed.FirstOrDefault(pair =>
                pair.Key.IndexOf(item.PackageName, StringComparison.OrdinalIgnoreCase) >= 0);
            if (!string.IsNullOrEmpty(match.Key))
            {
                item.Status = AppxStatus.Installed;
                item.FullPackageName = match.Value;
            }
            else
            {
                item.Status = AppxStatus.Removed;
                item.FullPackageName = null;
            }
        }
        return null;
    }

    public async Task<string?> RemoveAsync(AppxItem item)
    {
        var fullPackageName = item.FullPackageName;
        if (fullPackageName == null || fullPackageName.Trim().Length == 0) return Loc.Get("AppRemover_NotInstalled");
        var package = fullPackageName.Replace("'", "''"); //powershell single quote escaping
        var result = await RunPowerShellAsync($"Remove-AppxPackage -Package '{package}'");
        if (!string.IsNullOrWhiteSpace(result.Item2)) return result.Item2.Trim();
        item.Status = AppxStatus.Removed;
        item.FullPackageName = null;
        return null;
    }

    private static async Task<Tuple<string, string>> RunPowerShellAsync(string command)
    {
        var info = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            Arguments = "-NoProfile -NonInteractive -",
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = Process.Start(info);
        if (process == null) return Tuple.Create("", Loc.Get("AppRemover_PowerShellStartFailed"));
        process.StandardInput.WriteLine(command);
        process.StandardInput.Close();
        var outputTask = process.StandardOutput.ReadToEndAsync();
        var errorTask = process.StandardError.ReadToEndAsync();
        await Task.WhenAll(outputTask, errorTask);
        process.WaitForExit();
        return Tuple.Create(outputTask.Result, errorTask.Result);
    }
}
