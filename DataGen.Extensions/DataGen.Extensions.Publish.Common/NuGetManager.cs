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

        public ProductsManager ProductsManager
        {
            get
            {
                return this.PublishManager.ProductsManager;
            }
        }

        public VersionManager VersionManager
        {
            get
            {
                return this.PublishManager.VersionManager;
            }
        }

        private string NuGetPath
        {
            get
            {
                return this.PublishManager.GetAppSetting("NuGetPath");
            }
        }

        private string NuGetSource
        {
            get
            {
                return this.PublishManager.GetAppSetting("NuGetSource");
            }
        }

		public NuGetManager(PublishManager publishManager)
        {
            this.PublishManager = publishManager;
        }

        public void Publish()
        {
            Console.WriteLine("--Publishing--");
            PackNuspec();
            PushNupkg();
        }

        private void PackNuspec()
        {
            string fileName = this.NuGetPath;
            string arguments = "pack ..\\..\\..\\NuGet\\" + this.ProductsManager.Product + ".nuspec -OutputDirectory \"..\\..\\..\\NuGet\"";
            this.PublishManager.Process(fileName, arguments);
        }

        private void PushNupkg()
        {
            string fileName = this.NuGetPath;
            string arguments = string.Format("push ..\\..\\..\\NuGet\\" + this.ProductsManager.Product + ".{0}.nupkg -Source {1}", this.VersionManager.GetCurrentVersionString(), this.NuGetSource);
            this.PublishManager.Process(fileName, arguments);
        }
    }
}
