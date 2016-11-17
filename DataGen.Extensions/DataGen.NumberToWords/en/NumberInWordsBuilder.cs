using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGen.NumberToWords.Common;

namespace DataGen.NumberToWords.En
{
    public class NumberInWordsBuilder : Common.NumberInWordsBuilder
    {
        public NumberInWordsBuilder(int number, Common.NumeralsRepository numeralsRepository)
            : base(number, numeralsRepository)
        {
        }

        protected override string GetNumeralExtension(int value, NumeralOrderOfMagnitude orderOfMagnitude)
        {
            NumeralGrammaticalCase grammaticalCase = NumeralGrammaticalCase.SingularNominative;

            var numeralExtensionsKey = new KeyValuePair<NumeralOrderOfMagnitude, NumeralGrammaticalCase>(orderOfMagnitude, grammaticalCase);

            if (this.NumeralsRepository.NumeralExtensions.ContainsKey(numeralExtensionsKey))
            {
                return this.NumeralsRepository.NumeralExtensions[numeralExtensionsKey];
            }
            return string.Empty;
        }
    }

}
