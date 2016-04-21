using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.NumberToWords.Common
{
    public abstract class NumberToWordsService
    {
        public abstract string InWords(int value);
    }
}
