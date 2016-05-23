using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions.Collection
{
    public class Page<T>: List<T>
    {

        public int pagesCount { get; set; }

        public int elementsCount { get; set; }
    }
}
