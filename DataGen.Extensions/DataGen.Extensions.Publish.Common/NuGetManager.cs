using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions.Publish.Common
{
    public class NuGetManager
    {
        public PublishManager PublishManager { get; set; }

        public ProductsManager ProductsManager { get; set; }

        public VersionManager VersionManager { get; set; }

        public void Publish()
        {
            Console.WriteLine("--Publishing--");
            PackNuspec();
            PushNupkg();
        }

        private void PackNuspec()
        {
            string fileName = "..\\..\\..\\Tools\\nuget.exe";
            string arguments = "pack ..\\..\\..\\NuGet\\" + this.ProductsManager.ProductName + ".nuspec -OutputDirectory \"..\\..\\..\\NuGet\"";
            this.PublishManager.Process(fileName, arguments);
        }

        private void PushNupkg()
        {
            string fileName = "..\\..\\..\\Tools\\nuget.exe";
            string arguments = string.Format("push ..\\..\\..\\NuGet\\" + this.ProductsManager.ProductName + ".{0}.nupkg", this.VersionManager.GetCurrentVersionString());
            this.PublishManager.Process(fileName, arguments);
        }
    }
}
