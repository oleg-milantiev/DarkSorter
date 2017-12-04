using System;
using System.Text.RegularExpressions;

namespace DarkSorter.Helpers
{
    static class RegexHelpers
    {
        public static bool IfMatch(this Regex regex, string input, Action<Match> todo)
        {
            Match m = regex.Match(input);
            if (m.Success)
            {
                todo(m);
                return true;
            }
            return false;
        }
    }
}
