using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions.Generic
{
    public class Range<T>
    {
        public T Start { get; set; }

        public T End { get; set; }

        public Range(T start, T end)
        {
            this.Start = start;
            this.End = end;
        }
    }
}
