using DataGen.NumberToWords.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.NumberToWords.En
{
    public class NumberToWordsFactory : Common.NumberInWordsFactory
    {
        public override Common.NumeralsRepository CreateNumeralsRepository()
        {
            return new NumeralsRepository();
        }

        public override Common.NumberInWordsService CreateNumberToWordsService(Common.NumeralsRepository numeralsRepository, Common.NumberInWordsFactory numberInWordsFactory)
        {
            return new NumberToWordsService(numeralsRepository, numberInWordsFactory);
        }

        public override INumberInWordsBuilder CreateNumberInWordsBuilder(int number, Common.NumeralsRepository numeralRepository)
        {
            return new NumberInWordsBuilder(number, numeralRepository);
        }
    }
}
