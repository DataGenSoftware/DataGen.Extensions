using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DataGen.Extensions.RomanNumerals
{
    public static class RomanNumeralsExtensions
    {
        private static INumeralsRomansRepository NumeralsRomansRepository { get; set; }

        private static IRomansNumeralsRepository RomansNumeralsRepository { get; set; }

        static RomanNumeralsExtensions()
        {
            NumeralsRomansRepository = new NumeralsRomansRepository();
            RomansNumeralsRepository = new RomansNumeralsRepository();
        }

        [Obsolete("Moved to DataGen.RomanNumerals.")]
        public static string ToRomans(this short value)
        {
            return ((int)value).ToRomans();
        }

        [Obsolete("Moved to DataGen.RomanNumerals.")]
        public static string ToRomans(this long value)
        {
            return ((int)value).ToRomans();
        }

        [Obsolete("Moved to DataGen.RomanNumerals.")]
        public static string ToRomans(this int value)
        {
            if (value < 0 || value > 4999)
            {
                throw new ArgumentOutOfRangeException("value");
            }

            string result = string.Empty;

            while (value > 0)
            {
                int operatorValue = NumeralsRomansRepository.Dictionary.OrderByDescending(x => x.Key).First(x => value >= x.Key).Key;
                result += NumeralsRomansRepository.Get(operatorValue);
                value -= operatorValue;
            }

            return result;
        }

        [Obsolete("Moved to DataGen.RomanNumerals.")]
        public static int ParseRomans(this string value)
        {
            var result = 0;

            for (int i = 0; i < value.Length; i++)
            {
                if (!RomansNumeralsRepository.Dictionary.ContainsKey(value[i]))
                {
                    throw new ArgumentException();
                }

                if (i < value.Length - 1 && RomansNumeralsRepository.Dictionary[value[i]] < RomansNumeralsRepository.Dictionary[value[i + 1]])
                    result -= RomansNumeralsRepository.Dictionary[value[i]];
                else
                    result += RomansNumeralsRepository.Dictionary[value[i]];
            }

            return result;
        }
    }
}
