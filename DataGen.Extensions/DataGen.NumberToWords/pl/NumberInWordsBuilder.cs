using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGen.NumberToWords.Common;

namespace DataGen.NumberToWords.Pl
{
    public class NumberInWordsBuilder:Common.NumberInWordsBuilder
    {
        public NumberInWordsBuilder(int number, Common.NumeralsRepository numeralsRepository)
            : base(number, numeralsRepository)
        {
        }

        protected override string GetNumeralExtension(int value, NumeralOrderOfMagnitude orderOfMagnitude)
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
    }

}
