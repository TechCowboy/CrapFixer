using CrapFixer.Models;
using Microsoft.Win32;
using System.Globalization;
using System.Text;

namespace CrapFixer.Services;

internal sealed class RegistryService
{
    // read failures mean "not set" for a scan, writes report their error later
    public string? ReadValue(string hive, string key, string valueName)
    {
        try
        {
            using var regKey = OpenKey(hive, key, false);
            if (regKey == null) return null;
            var name = valueName == "(Default)" ? "" : valueName;
            var value = regKey.GetValue(name);
            if (value == null) return null;

            if (regKey.GetValueKind(name) == RegistryValueKind.DWord && value is int dword)
                return unchecked((uint)dword).ToString(CultureInfo.InvariantCulture);
            if (regKey.GetValueKind(name) == RegistryValueKind.QWord && value is long qword)
                return unchecked((ulong)qword).ToString(CultureInfo.InvariantCulture);
            if (value is byte[] bytes)
                return BitConverter.ToString(bytes).Replace("-", "");
            return value.ToString();
        }
        catch { return null; }
    }

    public bool IsEntryApplied(TweakRegistryEntry entry, out string? current)
    {
        current = ReadValue(entry.Hive, entry.Key, entry.ValueName);
        if (current == null) return false;

        // numeric rules may already be stricter than our recommended value
        long now, recommended, windowsDefault;
        if (TryLong(current, out now) && TryLong(entry.RecommendedValue, out recommended) &&
            TryLong(entry.DefaultValue, out windowsDefault) && recommended != windowsDefault)
            return recommended < windowsDefault ? now <= recommended : now >= recommended;

        return ValuesEqual(current, entry.RecommendedValue, entry.ValueType);
    }

    public string? Apply(TweakItem tweak)
    {
        //stop on first bad write, don't hide a half applied tweak
        foreach (var entry in tweak.AllEntries())
        {
            if (!WriteValue(entry, entry.RecommendedValue))
                return Loc.Format("Registry_WriteFailed", entry.Hive + "\\" + entry.Key + "\\" + entry.ValueName);
        }
        return null;
    }

    public string? Reset(TweakItem tweak)
    {
        foreach (var entry in tweak.AllEntries())
        {
            if (string.IsNullOrWhiteSpace(entry.DefaultValue)) continue;

            //special values come straight from Wintweak2.ini
            if (entry.DefaultValue.Equals("<delete>", StringComparison.OrdinalIgnoreCase))
            {
                if (!DeleteKey(entry.Hive, entry.Key)) return Loc.Format("Registry_DeleteKeyFailed", entry.Hive + "\\" + entry.Key);
            }
            else if (entry.DefaultValue.Equals("<deletevalue>", StringComparison.OrdinalIgnoreCase))
            {
                if (!DeleteValue(entry.Hive, entry.Key, entry.ValueName))
                    return Loc.Format("Registry_DeleteValueFailed", entry.Hive + "\\" + entry.Key + "\\" + entry.ValueName);
            }
            else if (!WriteValue(entry, entry.DefaultValue))
                return Loc.Format("Registry_ResetFailed", entry.Hive + "\\" + entry.Key + "\\" + entry.ValueName);
        }
        return null;
    }

    private static bool WriteValue(TweakRegistryEntry entry, string value)
    {
        try
        {
            using var key = CreateKey(entry.Hive, entry.Key);
            if (key == null) return false;
            var name = entry.ValueName == "(Default)" ? "" : entry.ValueName;

            switch (entry.ValueType.ToUpperInvariant())
            {
                case "DWORD":
                    ulong dword;
                    if (!TryUnsigned(value, out dword)) return false;
                    key.SetValue(name, unchecked((int)(uint)dword), RegistryValueKind.DWord);
                    break;
                case "QWORD":
                    ulong qword;
                    if (!TryUnsigned(value, out qword)) return false;
                    key.SetValue(name, unchecked((long)qword), RegistryValueKind.QWord);
                    break;
                case "EXPANDSTRING":
                    key.SetValue(name, value, RegistryValueKind.ExpandString);
                    break;
                case "BINARY":
                    key.SetValue(name, ParseBytes(value), RegistryValueKind.Binary);
                    break;
                default:
                    key.SetValue(name, value, RegistryValueKind.String);
                    break;
            }
            return true;
        }
        catch { return false; }
    }

    // .reg text for values which exist right now
    public string ExportBackup(TweakItem tweak)
    {
        var text = new StringBuilder();
        foreach (var entry in tweak.AllEntries())
        {
            var current = ReadValue(entry.Hive, entry.Key, entry.ValueName);
            if (current == null) continue;
            text.AppendLine($"[{ExpandHive(entry.Hive)}\\{entry.Key}]");
            text.AppendLine(RegLine(entry.ValueName, current, entry.ValueType));
            text.AppendLine();
        }
        return text.ToString();
    }

    private static string RegLine(string valueName, string value, string type)
    {
        var name = valueName == "(Default)" ? "@" : $"\"{valueName.Replace("\"", "\\\"")}\"";
        ulong number;
        if (type.Equals("DWORD", StringComparison.OrdinalIgnoreCase) && TryUnsigned(value, out number))
            return $"{name}=dword:{(uint)number:x8}";
        if (type.Equals("QWORD", StringComparison.OrdinalIgnoreCase) && TryUnsigned(value, out number))
            return $"{name}=hex(b):{string.Join(",", BitConverter.GetBytes(number).Select(b => b.ToString("x2")))}";
        if (type.Equals("BINARY", StringComparison.OrdinalIgnoreCase))
            return $"{name}=hex:{string.Join(",", ParseBytes(value).Select(b => b.ToString("x2")))}";
        return $"{name}=\"{value.Replace("\\", "\\\\").Replace("\"", "\\\"")}\"";
    }

    private static bool DeleteValue(string hive, string path, string valueName)
    {
        try
        {
            using var key = OpenKey(hive, path, true);
            if (key == null) return true;
            key.DeleteValue(valueName == "(Default)" ? "" : valueName, false);
            return true;
        }
        catch { return false; }
    }

    private static bool DeleteKey(string hive, string path)
    {
        try { GetRoot(hive)?.DeleteSubKeyTree(path, false); return true; }
        catch { return false; }
    }

    private static bool ValuesEqual(string current, string expected, string type)
    {
        if (type.Equals("DWORD", StringComparison.OrdinalIgnoreCase) ||
            type.Equals("QWORD", StringComparison.OrdinalIgnoreCase))
        {
            ulong left, right;
            if (TryUnsigned(current, out left) && TryUnsigned(expected, out right)) return left == right;
        }
        return string.Equals(current, expected, StringComparison.OrdinalIgnoreCase);
    }

    private static bool TryLong(string value, out long result)
    {
        ulong parsed;
        if (TryUnsigned(value, out parsed) && parsed <= long.MaxValue)
        {
            result = (long)parsed;
            return true;
        }
        return long.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
    }

    private static bool TryUnsigned(string value, out ulong result)
    {
        if (value.StartsWith("0x", StringComparison.OrdinalIgnoreCase))
            return ulong.TryParse(value.Substring(2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out result);
        return ulong.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out result);
    }

    private static byte[] ParseBytes(string value)
    {
        var clean = value.Replace(" ", "").Replace(",", "").Replace("-", "");
        if (clean.Length == 0) return new byte[0];
        if (clean.Length % 2 != 0) throw new FormatException(Loc.Get("Registry_InvalidBinary"));
        var bytes = new byte[clean.Length / 2];
        for (var i = 0; i < bytes.Length; i++)
            bytes[i] = byte.Parse(clean.Substring(i * 2, 2), NumberStyles.HexNumber, CultureInfo.InvariantCulture);
        return bytes;
    }

    private static RegistryKey? OpenKey(string hive, string key, bool writable) => GetRoot(hive)?.OpenSubKey(key, writable);
    private static RegistryKey? CreateKey(string hive, string key) => GetRoot(hive)?.CreateSubKey(key, true);
    private static RegistryKey? GetRoot(string hive)
    {
        switch (hive.ToUpperInvariant())
        {
            case "HKCU": case "HKEY_CURRENT_USER": return Registry.CurrentUser;
            case "HKLM": case "HKEY_LOCAL_MACHINE": return Registry.LocalMachine;
            case "HKCR": case "HKEY_CLASSES_ROOT": return Registry.ClassesRoot;
            case "HKU": case "HKEY_USERS": return Registry.Users;
            default: return null;
        }
    }

    private static string ExpandHive(string hive)
    {
        switch (hive.ToUpperInvariant())
        {
            case "HKCU": return "HKEY_CURRENT_USER";
            case "HKLM": return "HKEY_LOCAL_MACHINE";
            case "HKCR": return "HKEY_CLASSES_ROOT";
            case "HKU": return "HKEY_USERS";
            default: return hive;
        }
    }
}
