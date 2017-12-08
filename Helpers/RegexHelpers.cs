using System;
using System.Text.RegularExpressions;

namespace DarkSorter.Helpers
{
	static class RegexHelpers
	{
		public static bool IfMatch(this Regex regex, string input, Action<Match> callback)
		{
			Match m = regex.Match(input);

			if (m.Success) {
				callback(m);

				return true;
			}

			return false;
		}
	}
}
