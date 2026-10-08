using System.Reflection;

namespace CrapFixer;

internal static class AppInfo
{
    //keep the same digits used by release tags, .NET drops leading zeroes
    public static string DisplayVersion
    {
        get
        {
            var v = Assembly.GetExecutingAssembly().GetName().Version;
            return v == null ? "0.00.00" : $"{v.Major}.{v.Minor:D2}.{v.Build:D2}";
        }
    }
}
