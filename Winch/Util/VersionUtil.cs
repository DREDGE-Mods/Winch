using System;
using System.Linq;
using System.Text.RegularExpressions;
using Winch.Core;

namespace Winch.Util;

internal static class VersionUtil
{
    private static readonly string[] ValidPrefixes = new string[] { "alpha", "" };
    private static Regex VersionRegex = new Regex(@"(?:([a-z]+)-)?(\d+)\.(\d+)(?:\.(\d+))?", RegexOptions.Compiled);

    internal static string GetVersion()
    {
        return WinchCore.Version;
    }

    internal static bool ValidateVersion(string version)
    {
        Match match = VersionRegex.Match(version);
        if (!match.Success)
            return false;

        string prefix = match.Groups[1].Value;
        if(!ValidPrefixes.Contains(prefix))
            return false;
        return true;
    }

    internal static bool IsSameOrNewer(string installedVersion, string minVersion)
    {
        if (!ValidateVersion(installedVersion) || !ValidateVersion(minVersion))
            throw new ArgumentException($"Invalid version comparison: {installedVersion} - {minVersion}");

        GroupCollection installedParts = VersionRegex.Match(installedVersion).Groups;
        GroupCollection minParts = VersionRegex.Match(minVersion).Groups;

        int prefixIndexDiff = Array.IndexOf(ValidPrefixes, installedParts[1].Value) - Array.IndexOf(ValidPrefixes, minParts[1].Value);
        int majorDiff = int.Parse(installedParts[2].Value) - int.Parse(minParts[2].Value);
        int minorDiff = int.Parse(installedParts[3].Value) - int.Parse(minParts[3].Value);
        // Old versions had no patch diff in the version
        int patchDiff = string.IsNullOrEmpty(minParts[4].Value) ? 0 : int.Parse(installedParts[4].Value) - int.Parse(minParts[4].Value);

        if (prefixIndexDiff < 0) return false;
        else if(prefixIndexDiff > 0) return true;
        else
        {
            if(majorDiff < 0) return false;
            else if(majorDiff > 0) return true;
            else
            {
                if (minorDiff < 0) return false;
                else if (minorDiff > 0) return true;
                else
                {
                    if (patchDiff < 0) return false;
                    else return true;
                }
            }
        }
    }
}