using DataGen.Extensions.NumberInRomans.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.Extensions.RomanNumerals
{
    public class NumeralsRomansRepository : INumeralsRomansRepository
    {
        public IDictionary<int, string> Dictionary { get; set; }

        public NumeralsRomansRepository()
        {
            this.Dictionary = this.GetRomanConstantNumerals;
        }

        public virtual string Get(int value)
        {
            return this.Dictionary[value];
        }

        protected virtual IDictionary<int, string> GetRomanConstantNumerals
        {
            get
            {
                return this.GetBasicRomanNumerals.Concat(this.GetExtendedRomanNumerals).ToDictionary(x => (int)x.Value, x => (string)x.Symbol);
            }
        }

        private IEnumerable<Numeral> GetBasicRomanNumerals
        {
            get
            {
                // I
                yield return new Numeral { Value = 1, Symbol = "I" };

                // V
                yield return new Numeral { Value = 5, Symbol = "V" };

                // X
                yield return new Numeral { Value = 10, Symbol = "X" };

                // L
                yield return new Numeral { Value = 50, Symbol = "L" };

                // C
                yield return new Numeral { Value = 100, Symbol = "C" };

                // D
                yield return new Numeral { Value = 500, Symbol = "D" };

                // M
                yield return new Numeral { Value = 1000, Symbol = "M" };
            }
        }

        private IEnumerable<Numeral> GetExtendedRomanNumerals
        {
            get
            {
                // IV
                yield return new Numeral { Value = 4, Symbol = "IV" };

                // IX
                yield return new Numeral { Value = 9, Symbol = "IX" };

                // XL
                yield return new Numeral { Value = 40, Symbol = "XL" };

                // XC
                yield return new Numeral { Value = 90, Symbol = "XC" };

                // CD
                yield return new Numeral { Value = 400, Symbol = "CD" };

                // CM
                yield return new Numeral { Value = 900, Symbol = "CM" };
            }
        }
    }
}