using DataGen.Extensions.NumberToWords.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DataGen.Extensions.NumberToWords
{
    public static class NumberToWordsExtensions
    {
        private static NumberToWordsService NumberToWordsService { get; set; }

        [Obsolete("Moved to DataGen.NumberToWords.")]
        public static string ToWords(this short value, CultureInfo culture)
        {
            return ((int)value).ToWords(culture.Name);
        }

        [Obsolete("Moved to DataGen.NumberToWords.")]
        public static string ToWords(this short value, string culture)
        {
            return ((int)value).ToWords(culture);
        }

        [Obsolete("Moved to DataGen.NumberToWords.")]
        public static string ToWords(this long value, CultureInfo culture)
        {
            return ((int)value).ToWords(culture.Name);
        }

        [Obsolete("Moved to DataGen.NumberToWords.")]
        public static string ToWords(this long value, string culture)
        {
            return ((int)value).ToWords(culture);
        }

        [Obsolete("Moved to DataGen.NumberToWords.")]
        public static string ToWords(this int value, CultureInfo culture)
        {
            return ((int)value).ToWords(culture.Name);
        }

        [Obsolete("Moved to DataGen.NumberToWords.")]
        public static string ToWords(this int value, string culture)
        {
            try
            {
                NumberToWordsExtensions.NumberToWordsService = NumberToWordsExtensions.CreateNumberToWordsService(culture);
                return NumberToWordsExtensions.NumberToWordsService.InWords(value);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static NumberToWordsService CreateNumberToWordsService(string cultureName)
        {
            var NumberToWordsFactoryCreator = new NumberToWordsFactoryCreator();
            var NumberToWordsFactory = NumberToWordsFactoryCreator.CreateFactory(cultureName);
            var numeralsRepository = NumberToWordsFactory.CreateNumeralsRepository();
            return NumberToWordsFactory.CreateNumberToWordsService(numeralsRepository);
        }
    }
}
