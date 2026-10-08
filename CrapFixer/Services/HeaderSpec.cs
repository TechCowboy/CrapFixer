using Microsoft.Win32;
using System.Management;
using System.Runtime.InteropServices;

namespace CrapFixer.Services;

internal static class HeaderSpec
{
    public static string OsSummary => ReadWindowsVersion();

    public static string HardwareSummary
    {
        get
        {
            return string.Join(", ", new[] { ReadCpu(), ReadRam(), ReadGpu() }
                .Where(value => !string.IsNullOrWhiteSpace(value)));
        }
    }

    private static string ReadWindowsVersion()
    {
        try
        {
            using var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            var product = key?.GetValue("ProductName") as string ?? "Windows";
            int build;
            if (int.TryParse(key?.GetValue("CurrentBuildNumber") as string, out build) && build >= 22000)
                product = product.Replace("Windows 10", "Windows 11");
            return $"{product}, {(Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit")}";
        }
        catch { return "Windows"; }
    }

    private static string ReadCpu()
    {
        try
        {
            using var key = Registry.LocalMachine.OpenSubKey(@"HARDWARE\DESCRIPTION\System\CentralProcessor\0");
            return (key?.GetValue("ProcessorNameString") as string)?.Trim() ?? "";
        }
        catch { return ""; }
    }

    private static string ReadRam()
    {
        try
        {
            ulong kb;
            return GetPhysicallyInstalledSystemMemory(out kb) ? $"{(double)kb / (1024 * 1024):0.0}GB RAM" : "";
        }
        catch { return ""; }
    }

    private static string ReadGpu()
    {
        try
        {
            using var searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_VideoController");
            foreach (ManagementObject item in searcher.Get())
                if (item["Name"] is string name && name.Length > 0) return name;
        }
        catch { }
        return "";
    }

    [DllImport("kernel32.dll")]
    private static extern bool GetPhysicallyInstalledSystemMemory(out ulong totalMemoryInKilobytes);
}
