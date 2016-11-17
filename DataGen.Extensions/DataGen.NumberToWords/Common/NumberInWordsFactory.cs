using DataGen.NumberToWords.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.NumberToWords.Common
{
    /// <summary>
    /// Abstract factory for creating objects dependent on culture
    /// </summary>
    public abstract class NumberInWordsFactory
    {
        public abstract NumeralsRepository CreateNumeralsRepository();

        public abstract NumberInWordsService CreateNumberToWordsService(NumeralsRepository numeralsRepository, Common.NumberInWordsFactory numberInWordsFactory);

        public abstract INumberInWordsBuilder CreateNumberInWordsBuilder(int number, NumeralsRepository numeralRepository);
    }
}
