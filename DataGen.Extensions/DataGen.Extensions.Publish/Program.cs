using DataGen.Extensions.Publish.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataGen.Extensions.Publish
{
    class Program
    {
        private static PublishManager PublishManager { get; set; }

        static void Main(string[] args)
        {
            PublishManager.ProductsManager.DisplayProductMenu();
        }
    }
}
