using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.NumberToWords.Common
{
    public interface INumberInWordsBuilder
    {
        void Build();

        INumberInWords NumberInWords { get; }
    }
}
