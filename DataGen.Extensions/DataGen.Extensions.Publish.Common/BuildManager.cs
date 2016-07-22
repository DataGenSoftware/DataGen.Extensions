using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataGen.Extensions.Publish.Common
{
    public class BuildManager
    {
        public PublishManager PublishManager { get; set; }

        public ProductsManager ProductsManager
        {
            get
            {
                return this.PublishManager.ProductsManager;
            }
        }

        public BuildManager(PublishManager publishManager)
        {
            this.PublishManager = publishManager;
            this.BuildConfigurations = this.GetBuildConfigurations();
        }

        public IEnumerable<string> BuildConfigurations { get; set; }

        private IEnumerable<string> GetBuildConfigurations()
        {
            var buildConfigurationsAppSetting = this.PublishManager.GetAppSetting("BuildConfigurations");
            return buildConfigurationsAppSetting.Split(';');
        }

        public void Rebuild()
        {
            Console.WriteLine("--Rebuilding--");
            foreach (var buildConfiguration in BuildConfigurations)
            {
                RebuildProjectWithConfiguration(buildConfiguration);
            }
        }

        private void RebuildProjectWithConfiguration(string configurationName)
        {
            string fileName = this.PublishManager.GetAppSetting("MsBuildPath");
            string arguments = "..\\..\\..\\" + this.ProductsManager.Product + "\\" + this.ProductsManager.Product + ".csproj /nologo /v:m /t:Rebuild /p:WarningLevel=0 /property:Configuration=\"" + configurationName + "\";Platform=\"AnyCPU\"";
            this.PublishManager.Process(fileName, arguments);
        }
    }
}
