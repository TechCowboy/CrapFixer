using System.Net.Http;

namespace CrapFixer.Services;

//downloads the two official databases used by Classic
internal static class DatabaseUpdateService
{
    private const string Wintweak2Url = "https://raw.githubusercontent.com/builtbybel/CrapFixer/main/wintweak2.ini";
    private const string WinappxUrl = "https://raw.githubusercontent.com/builtbybel/CrapFixer/main/winappx.ini";

    public static string Wintweak2LocalPath => Path.Combine(AppContext.BaseDirectory, "Wintweak2.ini");
    public static string WinappxLocalPath => Path.Combine(AppContext.BaseDirectory, "Winappx.ini");

    public static Task UpdateWintweak2Async() => DownloadAsync(Wintweak2Url, Wintweak2LocalPath, "RecommendedValue=");
    public static Task UpdateWinappxAsync() => DownloadAsync(WinappxUrl, WinappxLocalPath, "PackageName=");

    //get everything first, a failed request leaves the current ini untouched
    private static async Task DownloadAsync(string url, string destination, string requiredKey)
    {
        using var http = new HttpClient { Timeout = TimeSpan.FromSeconds(30) };
        var content = await http.GetStringAsync(url);
        if (content.IndexOf(requiredKey, StringComparison.OrdinalIgnoreCase) < 0 ||
            content.IndexOf('[') < 0)
            throw new InvalidDataException(Loc.Get("Database_InvalidDownload"));

        await Task.Run(() => File.WriteAllText(destination, content));
    }
}
