using DataGen.NumberToWords.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.NumberToWords.Pl
{
    public class NumberToWordsService: Common.NumberInWordsService
    {
        public NumberToWordsService(Common.NumeralsRepository numeralsRepository, Common.NumberInWordsFactory numberInWordsFactory)
            :base (numeralsRepository, numberInWordsFactory)
        {
        }
        
    }
}
