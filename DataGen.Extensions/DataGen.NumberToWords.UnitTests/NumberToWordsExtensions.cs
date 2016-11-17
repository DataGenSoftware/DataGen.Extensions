using DataGen.NumberToWords.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DataGen.NumberToWords
{
    public static class NumberToWordsExtensions
    {
        private static NumberInWordsService NumberToWordsService { get; set; }

        public static string ToWords(this short value, CultureInfo culture)
        {
            return ((int)value).ToWords(culture.Name);
        }

        public static string ToWords(this short value, string culture)
        {
            return ((int)value).ToWords(culture);
        }

        public static string ToWords(this long value, CultureInfo culture)
        {
            return ((int)value).ToWords(culture.Name);
        }

        public static string ToWords(this long value, string culture)
        {
            return ((int)value).ToWords(culture);
        }

        public static string ToWords(this int value, CultureInfo culture)
        {
            return ((int)value).ToWords(culture.Name);
        }

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

        private static NumberInWordsService CreateNumberToWordsService(string cultureName)
        {
            var numberToWordsFactoryCreator = NumberToWordsFactoryCreator.Instance;
            var numberToWordsFactory = numberToWordsFactoryCreator.CreateFactory(cultureName);
            var numeralsRepository = numberToWordsFactory.CreateNumeralsRepository();
            return numberToWordsFactory.CreateNumberToWordsService(numeralsRepository, numberToWordsFactory);
        }
    }
}
