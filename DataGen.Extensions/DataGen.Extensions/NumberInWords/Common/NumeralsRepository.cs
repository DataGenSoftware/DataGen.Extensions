using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions.NumberInWords.Common
{
    public abstract class NumeralsRepository
    {
        public Dictionary<int, string> Numerals { get; protected set; }

        public Dictionary<KeyValuePair<NumeralOrderOfMagnitude, NumeralGrammaticalCase>, string> NumeralExtensions { get; protected set; }

        public abstract string GetNumeral(int value);

        public abstract string GetNumeralExtensions(NumeralOrderOfMagnitude orderOfMagnitude, NumeralGrammaticalCase grammaticalCase);
    }
}
