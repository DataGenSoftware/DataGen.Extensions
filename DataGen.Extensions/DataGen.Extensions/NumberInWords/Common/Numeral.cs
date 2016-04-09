using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DataGen.Extensions.NumberInWords.Common
{
    public class Numeral
    {
        public int Value { get; set; }

        public string Word { get; set; }

        public NumeralOrderOfMagnitude? OrderOfMagnitude { get; set; }

        public NumeralGrammaticalCase? GrammaticalCase { get; set; }
    }
}
