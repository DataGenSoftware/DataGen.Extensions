using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DataGen.Extensions
{
	public static class NumberExtensions
	{
        private const string IsInRangeArgumentExceptionMessage = "The begining value of the range cannot be greater that the end value of the range.";
        private const string IsInRangeArgumentExceptionParamName = "begin";

        public static bool IsInRange(this int value, int begin, int end)
        {
            return value.IsInRange<int>(begin, end);
        }

        public static bool IsInRange(this short value, short begin, short end)
        {
            return value.IsInRange<short>(begin, end);
        }

        public static bool IsInRange(this long value, long begin, long end)
        {
            return value.IsInRange<long>(begin, end);
        }

        public static bool IsInRange(this decimal value, decimal begin, decimal end)
        {
            return value.IsInRange<decimal>(begin, end);
        }

        public static bool IsInRange(this float value, float begin, float end)
        {
            return value.IsInRange<float>(begin, end);
        }

        public static bool IsInRange(this double value, double begin, double end)
        {
            return value.IsInRange<double>(begin, end);
        }

        public static bool IsInRange<T>(this T value, T begin, T end)
            where T :IComparable
        {
            if (begin.CompareTo(end) > 0)
            {
                throw new ArgumentException(NumberExtensions.IsInRangeArgumentExceptionMessage, NumberExtensions.IsInRangeArgumentExceptionParamName);
            }

            return value.CompareTo(begin) >= 0 && value.CompareTo(end) <= 0;
        }
    }
}