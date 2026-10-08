using System.Diagnostics;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using CrapFixer.Services;

namespace CrapFixer.Features.Extensions;

// owns the downloaded extension scripts
internal sealed class ExtensionService
{
    private static readonly HttpClient Client = new() { Timeout = TimeSpan.FromSeconds(30) };

    internal static string AppFolder => Path.GetDirectoryName(typeof(ExtensionService).Assembly.Location)
        ?? AppContext.BaseDirectory;

    public string ExtensionFolder => Path.Combine(AppFolder, "Extensions");

    public bool IsInstalled(ExtensionInfo extension) => File.Exists(GetScriptPath(extension));

    public string GetInstalledVersion(ExtensionInfo extension)
    {
        var path = GetScriptPath(extension) + ".version";
        return File.Exists(path) ? File.ReadAllText(path).Trim() : "";
    }

    // download first, then verify the optional catalog hash
    public async Task InstallAsync(ExtensionInfo extension)
    {
        var data = await Client.GetByteArrayAsync(extension.Url);
        if (extension.Sha256.Length > 0 && !HashMatches(data, extension.Sha256))
            throw new InvalidDataException(Loc.Get("Extensions_HashMismatch"));

        Directory.CreateDirectory(ExtensionFolder);
        var path = GetScriptPath(extension);
        File.WriteAllBytes(path, data);
        File.WriteAllText(path + ".version", extension.Version);
    }

    public void Remove(ExtensionInfo extension)
    {
        var path = GetScriptPath(extension);
        if (File.Exists(path)) File.Delete(path);
        if (File.Exists(path + ".version")) File.Delete(path + ".version");
    }

    // scripts run only after the page asked the user
    public async Task<ExtensionRunResult> RunAsync(ExtensionInfo extension)
    {
        var path = GetScriptPath(extension);
        if (!File.Exists(path)) throw new FileNotFoundException(Loc.Get("Extensions_InstallFirst"), path);

        var info = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            Arguments = "-NoProfile -NonInteractive -ExecutionPolicy Bypass -File \"" + path + "\"",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        using var process = Process.Start(info);
        if (process == null) throw new InvalidOperationException(Loc.Get("AppRemover_PowerShellStartFailed"));
        var output = process.StandardOutput.ReadToEndAsync();
        var error = process.StandardError.ReadToEndAsync();
        await Task.WhenAll(output, error, Task.Run(() => process.WaitForExit()));

        var text = new StringBuilder(output.Result.Trim());
        if (error.Result.Trim().Length > 0)
        {
            if (text.Length > 0) text.AppendLine().AppendLine();
            text.Append(error.Result.Trim());
        }
        return new ExtensionRunResult { ExitCode = process.ExitCode, Output = text.ToString() };
    }

    public static bool IsAdministrator()
    {
        using var identity = WindowsIdentity.GetCurrent();
        return new WindowsPrincipal(identity).IsInRole(WindowsBuiltInRole.Administrator);
    }

    // filename comes from the catalog url, never from a full local path
    private string GetScriptPath(ExtensionInfo extension)
    {
        if (!Uri.TryCreate(extension.Url, UriKind.Absolute, out var uri))
            throw new InvalidDataException(Loc.Get("Extensions_InvalidUrl"));
        var file = Uri.UnescapeDataString(Path.GetFileName(uri.AbsolutePath));
        if (!file.EndsWith(".ps1", StringComparison.OrdinalIgnoreCase) || file.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
            throw new InvalidDataException(Loc.Get("Extensions_InvalidFilename"));
        return Path.Combine(ExtensionFolder, file);
    }

    private static bool HashMatches(byte[] data, string expected)
    {
        using var sha = SHA256.Create();
        var actual = BitConverter.ToString(sha.ComputeHash(data)).Replace("-", "");
        return actual.Equals(expected.Replace(" ", "").Replace("-", ""), StringComparison.OrdinalIgnoreCase);
    }
}
