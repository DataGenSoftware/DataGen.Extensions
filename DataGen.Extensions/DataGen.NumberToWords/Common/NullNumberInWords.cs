using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.NumberToWords.Common
{
    public class NullNumberInWords : INumberInWords
    {
        public string Value
        {
            get
            {
                return string.Empty;
            }
        }
    }
}
