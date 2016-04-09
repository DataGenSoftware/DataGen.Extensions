using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DataGen.Extensions.NumberInRomans
{
    public static class RomanNumeralsExtensions
    {
        private static IRomanNumeralsRepository RomanNumeralsRepository { get; set; }

        static RomanNumeralsExtensions()
        {
            RomanNumeralsRepository = new RomanNumeralsRepository();
        }

        public static string ToRomans(this short value)
        {
            return ((int)value).ToRomans();
        }

        public static string ToRomans(this long value)
        {
            return ((int)value).ToRomans();
        }

        public static string ToRomans(this int value)
        {
            if (value < 0 || value > 4999)
            {
                throw new ArgumentOutOfRangeException("value");
            }

            string result = string.Empty;

            while (value > 0)
            {
                int operatorValue = RomanNumeralsRepository.Dictionary.OrderByDescending(x => x.Key).First(x => value >= x.Key).Key;
                result += RomanNumeralsRepository.Get(operatorValue);
                value -= operatorValue;
            }

            return result;
        }
    }
}
