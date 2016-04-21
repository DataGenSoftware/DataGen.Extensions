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
    public abstract class NumberToWordsFactory
    {
        public abstract NumeralsRepository CreateNumeralsRepository();

        public abstract NumberToWordsService CreateNumberToWordsService(NumeralsRepository numeralsRepository);
    }
}
