using DataGen.Extensions.NumberInWords.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.Extensions.NumberInWords.Pl
{
    public class NumberInWordsService: Common.NumberInWordsService
    {
        private Common.NumeralsRepository NumeralsRepository { get; set; }

        public NumberInWordsService(Common.NumeralsRepository numeralsRepository)
        {
            this.NumeralsRepository = numeralsRepository;
        }

        public override string InWords(int value)
        {
            if (value < 1 || value > 999999999)
            {
                throw new ArgumentOutOfRangeException("value");
            }

            var result = string.Empty;

            result = ProcessPartOfValue(value, result, NumeralOrderOfMagnitude.Milion);

            result = ProcessPartOfValue(value, result, NumeralOrderOfMagnitude.Thousand);

            result = ProcessPartOfValue(value, result, NumeralOrderOfMagnitude.Unit);

            return result.Trim();
        }

        private string ProcessPartOfValue(int value, string result, NumeralOrderOfMagnitude numeralOrderOfMagnitude)
        {
            int partOfValue = this.GetPartOfValue(value, numeralOrderOfMagnitude);

            if (partOfValue > 0)
            {
                string extension = this.GetNumeralExtension(partOfValue, numeralOrderOfMagnitude);

                while (partOfValue > 0)
                {
                    int operatorValue = this.NumeralsRepository.Numerals.OrderByDescending(x => x.Key).First(x => x.Key <= partOfValue).Key;
                    result += " " + this.NumeralsRepository.GetNumeral(operatorValue);
                    partOfValue -= operatorValue;
                }

                result += " " + extension;
            }

            return result;
        }

        private int GetPartOfValue(int value, NumeralOrderOfMagnitude numeralOrderOfMagnitude)
        {
            switch (numeralOrderOfMagnitude)
            {
                case NumeralOrderOfMagnitude.Unit:
                    return this.GetUnits(value);
                case NumeralOrderOfMagnitude.Thousand:
                    return this.GetThousands(value);
                case NumeralOrderOfMagnitude.Milion:
                    return this.GetMilions(value);
                default:
                    return 0;
            }
        }

        private string GetNumeralExtension(int value, NumeralOrderOfMagnitude orderOfMagnitude)
        {
            NumeralGrammaticalCase grammaticalCase = NumeralGrammaticalCase.SingularNominative;
            
            if (value % 10 >= 5 || value % 10 == 0 || (value >= 11 && value <= 19))
            {
                grammaticalCase = NumeralGrammaticalCase.PluralGenitive;
            }
            else if (value % 10 >= 2)
            {
                grammaticalCase = NumeralGrammaticalCase.PluralNominative;
            }

            var numeralExtensionsKey = new KeyValuePair<NumeralOrderOfMagnitude, NumeralGrammaticalCase>(orderOfMagnitude, grammaticalCase);

            if (this.NumeralsRepository.NumeralExtensions.ContainsKey(numeralExtensionsKey))
            {
                return this.NumeralsRepository.NumeralExtensions[numeralExtensionsKey];
            }
            return string.Empty;
        }

        private int GetUnits(int value)
        {
            return value % 1000;
        }

        private int GetThousands(int value)
        {
            return Convert.ToInt32(Math.Floor(Convert.ToDecimal((value % 1000000) / 1000)));
        }

        private int GetMilions(int value)
        {
            return Convert.ToInt32(Math.Floor(Convert.ToDecimal((value % 1000000000) / 1000000)));
        }
    }
}
