using System;

namespace DarkSorter.Helpers
{
    static class RangeHelpers
    {
        public static bool InRange<T>(this T val, T min, T max)
            where T : IComparable<T>
        {
            return val.CompareTo(min) >= 0
                && val.CompareTo(max) <= 0;
        }

        public static bool InRange<T>(this T val, IRange<T> range)
                    where T : IComparable<T>
        {
            return val.CompareTo(range.Minimum) >= 0
                && val.CompareTo(range.Maximum) <= 0;
        }

        public static bool InRange<T>(this T? val, T min, T max)
            where T : struct, IComparable<T>
        {
            if (val.HasValue)
            {
                return val.Value.CompareTo(min) >= 0
                    && val.Value.CompareTo(max) <= 0;
            }
            return false;
        }

        public static bool InRange<T>(this T? val, IRange<T> range)
                    where T : struct, IComparable<T>
        {
            if (val.HasValue)
            {
                return val.Value.CompareTo(range.Maximum) >= 0
                    && val.Value.CompareTo(range.Maximum) <= 0;
            }
            return false;
        }
    }
}
