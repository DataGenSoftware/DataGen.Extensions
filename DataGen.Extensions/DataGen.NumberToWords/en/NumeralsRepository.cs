using DataGen.NumberToWords.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.NumberToWords.En
{
    public class NumeralsRepository : Common.NumeralsRepository
    {
        public NumeralsRepository()
        {
            this.Numerals = this.GetNumerals();
            this.NumeralExtensions = this.GetNumeralExtensions();
        }

        public override string Minus
        {
            get
            {
                return "minus";
            }
        }

        public override string GetNumeral(int value)
        {
            return this.Numerals[value];
        }

        public override string GetNumeralExtensions(NumeralOrderOfMagnitude orderOfMagnitude, NumeralGrammaticalCase grammaticalCase)
        {
            return this.NumeralExtensions[new KeyValuePair<NumeralOrderOfMagnitude, NumeralGrammaticalCase>(orderOfMagnitude, grammaticalCase)];
        }

        protected virtual Dictionary<int, string> GetNumerals()
        {
            return this.CreateNumerals().ToDictionary(x => (int)x.Value, x => (string)x.Word);
        }

        protected virtual Dictionary<KeyValuePair<NumeralOrderOfMagnitude, NumeralGrammaticalCase>, string> GetNumeralExtensions()
        {
            return this.CreateNumeralExtensions().ToDictionary(
                x => new KeyValuePair<NumeralOrderOfMagnitude, NumeralGrammaticalCase>(x.OrderOfMagnitude.Value, x.GrammaticalCase.Value), 
                x => (string)x.Word
            );
        }

        private IEnumerable<Numeral> CreateNumerals()
        {
            return this.CreateUnitNumerals()
            .Concat(this.CreateTeenNumerals())
            .Concat(this.CreateDozenNumerals())
            .Concat(this.CreateHundredNumerals());

        }

        private IEnumerable<Numeral> CreateNumeralExtensions()
        {
            return this.CreateThousandNumerals()
            .Concat(this.CreateMilionNumerals());

        }

        private IEnumerable<Numeral> CreateUnitNumerals()
        {
            yield return new Numeral { Value = 1, Word = "one" };
            yield return new Numeral { Value = 2, Word = "two" };
            yield return new Numeral { Value = 3, Word = "three" };
            yield return new Numeral { Value = 4, Word = "four" };
            yield return new Numeral { Value = 5, Word = "five" };
            yield return new Numeral { Value = 6, Word = "six" };
            yield return new Numeral { Value = 7, Word = "seven" };
            yield return new Numeral { Value = 8, Word = "eight" };
            yield return new Numeral { Value = 9, Word = "nine" };
        }

        private IEnumerable<Numeral> CreateTeenNumerals()
        {
            yield return new Numeral { Value = 11, Word = "eleven" };
            yield return new Numeral { Value = 12, Word = "twelve" };
            yield return new Numeral { Value = 13, Word = "thirteen" };
            yield return new Numeral { Value = 14, Word = "fourteen" };
            yield return new Numeral { Value = 15, Word = "fifteen" };
            yield return new Numeral { Value = 16, Word = "sixteen" };
            yield return new Numeral { Value = 17, Word = "seventeen" };
            yield return new Numeral { Value = 18, Word = "eighteen" };
            yield return new Numeral { Value = 19, Word = "nineteen" };
        }

        private IEnumerable<Numeral> CreateDozenNumerals()
        {
            yield return new Numeral { Value = 10, Word = "ten" };
            yield return new Numeral { Value = 20, Word = "twenty" };
            yield return new Numeral { Value = 30, Word = "thirty" };
            yield return new Numeral { Value = 40, Word = "fourty" };
            yield return new Numeral { Value = 50, Word = "fifty" };
            yield return new Numeral { Value = 80, Word = "eighty" };

            var postfix = "ty";
            foreach (var numeral in CreateUnitNumerals().Where(x => x.Value >= 6 && x.Value != 8))
            {
                var value = numeral.Value * 10;
                yield return new Numeral { Value = value, Word = numeral.Word + postfix };
            }
        }

        private IEnumerable<Numeral> CreateHundredNumerals()
        {
            var postfix = "hundred";
            foreach (var numeral in CreateUnitNumerals().Where(x => x.Value >= 1))
            {
                var value = numeral.Value * 100;
                yield return new Numeral { Value = value, Word = numeral.Word + NumeralsRepository.Space + postfix };
            }

        }

        private IEnumerable<Numeral> CreateThousandNumerals()
        {
            yield return new Numeral { OrderOfMagnitude = NumeralOrderOfMagnitude.Thousand, GrammaticalCase = NumeralGrammaticalCase.SingularNominative, Word = "thousand" };
        }

        private IEnumerable<Numeral> CreateMilionNumerals()
        {
            yield return new Numeral { OrderOfMagnitude = NumeralOrderOfMagnitude.Milion, GrammaticalCase = NumeralGrammaticalCase.SingularNominative, Word = "milion" };
        }

        
    }
}
