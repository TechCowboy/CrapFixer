namespace CrapFixer.Features.Extensions;

internal sealed class ExtensionInfo
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public string Url { get; set; } = "";
    public string Version { get; set; } = "";
    public string Sha256 { get; set; } = "";
    public bool RequiresAdmin { get; set; }
}

internal sealed class ExtensionRunResult
{
    public int ExitCode { get; set; }
    public string Output { get; set; } = "";
}
