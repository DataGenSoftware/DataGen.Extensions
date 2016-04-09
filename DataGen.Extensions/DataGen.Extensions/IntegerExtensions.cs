using DataGen.Extensions.NumberInWords;
using DataGen.Extensions.NumberInWords.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DataGen.Extensions
{
	public static class IntegerExtensions
	{
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
                var service = IntegerExtensions.MakeNumberInWordsService(culture);
                return service.InWords(value);
            }
            catch(Exception ex)
            {
                throw ex;
            }
		}

        private static NumberInWordsService MakeNumberInWordsService(string cultureName)
        {
            var numberInWordsFactoryCreator = new NumberInWordsFactoryCreator();
            var numberInWordsFactory = numberInWordsFactoryCreator.CreateFactory(cultureName);
            var numeralsRepository = numberInWordsFactory.CreateNumeralsRepository();
            return numberInWordsFactory.CreateNumberInWordsService(numeralsRepository);
        }
    }
}
