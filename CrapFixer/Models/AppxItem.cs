namespace CrapFixer.Models;

internal enum AppxStatus { Unknown, Installed, Removed }

internal sealed class AppxItem
{
    public string Name { get; set; } = "";
    public string Category { get; set; } = "";
    public string PackageName { get; set; } = "";
    public bool DefaultSelected { get; set; }
    public AppxStatus Status { get; set; } = AppxStatus.Unknown;
    public string? FullPackageName { get; set; }
}
