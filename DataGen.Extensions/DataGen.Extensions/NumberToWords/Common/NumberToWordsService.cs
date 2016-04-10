using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.Extensions.NumberToWords.Common
{
    public abstract class NumberToWordsService
    {
        public abstract string InWords(int value);
    }
}
