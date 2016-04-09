using DataGen.Extensions.NumberInWords.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.Extensions.NumberInWords.Pl
{
    public class NumberInWordsFactory : Common.NumberInWordsFactory
    {
        public override Common.NumeralsRepository CreateNumeralsRepository()
        {
            return new NumeralsRepository();
        }

        public override Common.NumberInWordsService CreateNumberInWordsService(Common.NumeralsRepository numeralsRepository)
        {
            return new NumberInWordsService(numeralsRepository);
        }
    }
}
