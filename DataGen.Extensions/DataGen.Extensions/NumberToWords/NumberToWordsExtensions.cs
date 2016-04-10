using DataGen.Extensions.NumberToWords.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions.NumberToWords
{
    public static class NumberToWordsExtensions
    {
        private static NumberToWordsService NumberToWordsService { get; set; }

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
                throw ex;
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
