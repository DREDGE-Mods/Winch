using System.Text.RegularExpressions;
using UnityEngine;

namespace System.Collections.Generic;

public class AlphanumComparer : IComparer<string>
{
    private static readonly AlphanumComparer instance = new AlphanumComparer();
    public static AlphanumComparer Instance => instance;

    /// <summary>
    /// Regular expression to match word and number at the end of the string
    /// </summary>
    private static readonly string pattern = @"^([a-zA-Z]+)(\d+)$";

    public int Compare(string str1, string str2)
    {
        if (TryGetWordAndNumber(str1, out string word1, out int number1) && TryGetWordAndNumber(str2, out string word2, out int number2))
        {
            // First compare the word part
            int wordComparison = string.Compare(word1, word2, StringComparison.Ordinal);

            // If the word parts are the same, compare the numbers
            if (wordComparison == 0) return number1.CompareTo(number2);

            // Return the comparison result of the word parts
            return wordComparison;
        }
        else
            return string.Compare(str1, str2, StringComparison.Ordinal);
    }

    public bool TryGetWordAndNumber(string str, out string word, out int number)
    {
        word = string.Empty;
        if (int.TryParse(str, out number)) return true;

        // Use Regex to capture the word and number parts
        var match = Regex.Match(str, pattern);

        // Ensure string matches the pattern
        if (!match.Success)
            return false;

        word = match.Groups[1].Value;
        number = int.Parse(match.Groups[2].Value);
        return true;
    }
}