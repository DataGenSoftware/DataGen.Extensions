using DataGen.Extensions.NumberInWords.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.Extensions.NumberInWords.Common
{
    /// <summary>
    /// Abstract factory for creating objects dependent on culture
    /// </summary>
    public abstract class NumberInWordsFactory
    {
        public abstract NumeralsRepository CreateNumeralsRepository();

        public abstract NumberInWordsService CreateNumberInWordsService(NumeralsRepository numeralsRepository);
    }
}
