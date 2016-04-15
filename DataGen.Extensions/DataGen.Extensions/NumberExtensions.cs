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
            return ((long)value).IsInRange((long)begin, (long)end);
        }
        

        public static bool IsInRange(this short value, short begin, short end)
        {
            return ((long)value).IsInRange((long)begin, (long)end);
        }

        public static bool IsInRange(this long value, long begin, long end)
        {
            if (begin > end)
            {
                throw new ArgumentException(NumberExtensions.IsInRangeArgumentExceptionMessage, NumberExtensions.IsInRangeArgumentExceptionParamName);
            }

            return value >= begin && value <= end;
        }

        public static bool IsInRange(this decimal value, decimal begin, decimal end)
        {
            if (begin > end)
            {
                throw new ArgumentException(NumberExtensions.IsInRangeArgumentExceptionMessage, NumberExtensions.IsInRangeArgumentExceptionParamName);
            }

            return value >= begin && value <= end;
        }

        public static bool IsInRange(this float value, float begin, float end)
        {
            return ((double)value).IsInRange((double)begin, (double)end);
        }

        public static bool IsInRange(this double value, double begin, double end)
        {
            if (begin > end)
            {
                throw new ArgumentException(NumberExtensions.IsInRangeArgumentExceptionMessage, NumberExtensions.IsInRangeArgumentExceptionParamName);
            }

            return value >= begin && value <= end;
        }
    }
}
