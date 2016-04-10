using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.Extensions.NumberToWords.Common
{
    public abstract class NumeralsRepository
    {
        public Dictionary<int, string> Numerals { get; protected set; }

        public Dictionary<KeyValuePair<NumeralOrderOfMagnitude, NumeralGrammaticalCase>, string> NumeralExtensions { get; protected set; }

        public abstract string GetNumeral(int value);

        public abstract string GetNumeralExtensions(NumeralOrderOfMagnitude orderOfMagnitude, NumeralGrammaticalCase grammaticalCase);
    }
}
