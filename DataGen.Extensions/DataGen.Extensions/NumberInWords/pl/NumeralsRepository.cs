using DataGen.Extensions.NumberInWords.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions.NumberInWords.Pl
{
    public class NumeralsRepository : Common.NumeralsRepository
    {
        public NumeralsRepository()
        {
            this.Numerals = this.GetNumerals();
            this.NumeralExtensions = this.GetNumeralExtensions();
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
            return this.CreateNumerals().ToDictionary(x => x.Value, x => x.Word);
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
            yield return new Numeral { Value = 1, Word = "jeden" };
            yield return new Numeral { Value = 2, Word = "dwa" };
            yield return new Numeral { Value = 3, Word = "trzy" };
            yield return new Numeral { Value = 4, Word = "cztery" };
            yield return new Numeral { Value = 5, Word = "pięć" };
            yield return new Numeral { Value = 6, Word = "sześć" };
            yield return new Numeral { Value = 7, Word = "siedem" };
            yield return new Numeral { Value = 8, Word = "osiem" };
            yield return new Numeral { Value = 9, Word = "dziewięć" };
        }

        private IEnumerable<Numeral> CreateTeenNumerals()
        {
            yield return new Numeral { Value = 11, Word = "jedenaście" };
            yield return new Numeral { Value = 12, Word = "dwanaście" };
            yield return new Numeral { Value = 13, Word = "trzynaście" };
            yield return new Numeral { Value = 14, Word = "czternaście" };
            yield return new Numeral { Value = 15, Word = "piętnaście" };
            yield return new Numeral { Value = 16, Word = "szesnaście" };
            yield return new Numeral { Value = 17, Word = "siedemnaście" };
            yield return new Numeral { Value = 18, Word = "osiemnaście" };
            yield return new Numeral { Value = 19, Word = "dziewiętnaście" };
        }

        private IEnumerable<Numeral> CreateDozenNumerals()
        {
            yield return new Numeral { Value = 10, Word = "dziesięć" };
            yield return new Numeral { Value = 20, Word = "dwadzieścia" };
            yield return new Numeral { Value = 30, Word = "trzydzieści" };
            yield return new Numeral { Value = 40, Word = "czterdzieści" };

            var postfix = "dziesiąt";
            foreach (var numeral in CreateUnitNumerals().Where(x => x.Value >= 5))
            {
                var value = numeral.Value * 10;
                yield return new Numeral { Value = value, Word = numeral.Word + postfix };
            }
        }

        private IEnumerable<Numeral> CreateHundredNumerals()
        {
            yield return new Numeral { Value = 100, Word = "sto" };
            yield return new Numeral { Value = 200, Word = "dwieście" };
            yield return new Numeral { Value = 300, Word = "trzysta" };
            yield return new Numeral { Value = 400, Word = "czterysta" };

            var postfix = "set";
            foreach (var numeral in CreateUnitNumerals().Where(x => x.Value >= 5))
            {
                var value = numeral.Value * 100;
                yield return new Numeral { Value = value, Word = numeral.Word + postfix };
            }

        }

        private IEnumerable<Numeral> CreateThousandNumerals()
        {
            yield return new Numeral { OrderOfMagnitude = NumeralOrderOfMagnitude.Thousand, GrammaticalCase = NumeralGrammaticalCase.SingularNominative, Word = "tysiąc" };
            yield return new Numeral { OrderOfMagnitude = NumeralOrderOfMagnitude.Thousand, GrammaticalCase = NumeralGrammaticalCase.PluralNominative, Word = "tysiące" };
            yield return new Numeral { OrderOfMagnitude = NumeralOrderOfMagnitude.Thousand, GrammaticalCase = NumeralGrammaticalCase.PluralGenitive, Word = "tysięcy" };
        }

        private IEnumerable<Numeral> CreateMilionNumerals()
        {
            yield return new Numeral { OrderOfMagnitude = NumeralOrderOfMagnitude.Milion, GrammaticalCase = NumeralGrammaticalCase.SingularNominative, Word = "milion" };
            yield return new Numeral { OrderOfMagnitude = NumeralOrderOfMagnitude.Milion, GrammaticalCase = NumeralGrammaticalCase.PluralNominative, Word = "miliony" };
            yield return new Numeral { OrderOfMagnitude = NumeralOrderOfMagnitude.Milion, GrammaticalCase = NumeralGrammaticalCase.PluralGenitive, Word = "milionów" };
        }

        
    }
}
