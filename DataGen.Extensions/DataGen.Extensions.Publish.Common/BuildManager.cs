using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataGen.Extensions.Publish.Common
{
    public class BuildManager
    {

        public PublishManager PublishManager { get; set; }

        public ProductsManager ProductsManager { get; set; }

        public BuildManager()
        {
            this.BuildConfigurations = this.GetBuildConfigurations();
        }

        public IEnumerable<string> BuildConfigurations { get; set; }

        // TODO: Get from config
        private IEnumerable<string> GetBuildConfigurations()
        {
            yield return "Release 3.5";
            yield return "Release 4.0";
            yield return "Release 4.5";
            yield return "Release 4.6";
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
            string fileName = "C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\msbuild.exe";
            string arguments = "..\\..\\..\\" + this.ProductsManager.ProductName + "\\" + this.ProductsManager.ProductName + ".csproj /nologo /v:m /t:Rebuild /p:WarningLevel=0 /property:Configuration=\"" + configurationName + "\";Platform=\"AnyCPU\"";
            this.PublishManager.Process(fileName, arguments);
        }
    }
}
