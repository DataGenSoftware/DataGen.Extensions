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