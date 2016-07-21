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
        static void Main(string[] args)
        {
            // TODO: Refactor to builder
            var publishManager = new PublishManager();
            publishManager.ProductsManager = new ProductsManager(publishManager); 
            publishManager.VersionManager = new VersionManager(publishManager); 
            publishManager.BuildManager = new BuildManager(publishManager); 
            publishManager.NuGetManager = new NuGetManager(publishManager);

            publishManager.ProductsManager.DisplayProductMenu();
        }
    }
}
