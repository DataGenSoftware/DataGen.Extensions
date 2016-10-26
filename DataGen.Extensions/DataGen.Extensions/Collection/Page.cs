using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.Extensions.Collection
{
    public class Page<T>: List<T>
    {

        public int PagesCount { get; set; }

        public int ElementsCount { get; set; }
    }
}
