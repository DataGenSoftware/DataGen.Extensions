using DataGen.NumberToWords.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.NumberToWords.En
{
    public class NumberToWordsService : Common.NumberInWordsService
    {
        public NumberToWordsService(Common.NumeralsRepository numeralsRepository, Common.NumberInWordsFactory numberInWordsFactory)
            : base(numeralsRepository, numberInWordsFactory)
        {
        }

        //protected override string GetNumeralExtension(int value, NumeralOrderOfMagnitude orderOfMagnitude)
        //{
        //    NumeralGrammaticalCase grammaticalCase = NumeralGrammaticalCase.SingularNominative;

        //    var numeralExtensionsKey = new KeyValuePair<NumeralOrderOfMagnitude, NumeralGrammaticalCase>(orderOfMagnitude, grammaticalCase);

        //    if (this.NumeralsRepository.NumeralExtensions.ContainsKey(numeralExtensionsKey))
        //    {
        //        return this.NumeralsRepository.NumeralExtensions[numeralExtensionsKey];
        //    }
        //    return string.Empty;
        //}
    }
}
