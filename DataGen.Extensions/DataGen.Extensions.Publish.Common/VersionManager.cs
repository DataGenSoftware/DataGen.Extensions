using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataGen.Extensions.Publish.Common
{
    public class VersionManager
    {
        public Version CurrentVersion { get; set; }

        public PublishManager PublishManager { get; set; }

        public ProductsManager ProductsManager
        {
            get
            {
                return this.PublishManager.ProductsManager;
            }
        }

        public VersionManager(PublishManager publishManager)
        {
            this.PublishManager = publishManager;
            this.CurrentVersion = GetAssemblyCurrentVersion();
        }

        public void UpdateAssemblyCurrentVersion()
        {
            this.CurrentVersion = this.GetAssemblyCurrentVersion();
        }

        private Version GetAssemblyCurrentVersion()
        {
            string fileContent;
            var fileName = "..\\..\\..\\" + this.ProductsManager.ProductName + "\\Properties\\AssemblyInfo.cs";
            string regexPattern = "\\[assembly: AssemblyVersion\\(\\\"\\d+\\.\\d+\\.\\d+.\\*\\\"\\)\\]";
            Match match = GetVersionRegexMatch(fileName, regexPattern, out fileContent);
            if (match.Success)
            {
                match = Regex.Match(match.Value, "\\d+\\.\\d+\\.\\d+");
                if (match.Success)
                    return new Version(match.Value);
            }

            return new Version();
        }

        public string GetCurrentVersionString()
        {
            if (CurrentVersion.IsNull())
                return string.Empty;

            return string.Format("{0}.{1}.{2}", CurrentVersion.Major, CurrentVersion.Minor, CurrentVersion.Build);
        }

        private Match GetVersionRegexMatch(string fileName, string regexPattern, out string fileContent)
        {
            fileContent = File.ReadAllText(fileName);
            var match = Regex.Match(fileContent, regexPattern);
            return match;
        }

        public void EnterVersion()
        {
            Console.WriteLine("Enter version in format 'Major.Minor.Build'.");
            string version = Console.ReadLine();
            if (Regex.Match(version, "^\\d+\\.\\d+\\.\\d+$").Success)
            {
               this. CurrentVersion = new Version(version);
            }
            else
            {
                Console.WriteLine("Wrong format!");
                this.DisplayChangeVersionMenu();
            }
        }

        private void DisplayChangeVersionMenu()
        {
            Console.WriteLine();
            Console.WriteLine(string.Format("---{0} Change version menu---", this.ProductsManager.ProductName));
            Console.WriteLine("1 - Increase build version number");
            Console.WriteLine("2 - Increase minor version number");
            Console.WriteLine("3 - Increase major version number");
            Console.WriteLine("4 - Change version");
            Console.WriteLine("5 - Show current version");
            Console.WriteLine("6 - Commit current version");
            Console.WriteLine("7 - Update dependencies version");
            Console.WriteLine("0 - Main menu");

            this.PublishManager.GetUserCommand(new Action<string>(HandleChangeVersionMenuCommand));
        }

        private void HandleChangeVersionMenuCommand(string command)
        {
            switch (command)
            {
                case "1":
                    IncreaseBuildVersionNumber();
                    ChangeVersionInFiles();
                    break;
                case "2":
                    IncreaseMinorVersionNumber();
                    ChangeVersionInFiles();
                    break;
                case "3":
                    IncreaseMajorVersionNumber();
                    ChangeVersionInFiles();
                    break;
                case "4":
                    EnterVersion();
                    ChangeVersionInFiles();
                    break;
                case "5":
                    ShowCurrentVersion();
                    break;
                case "6":
                    CommitCurrentVersion();
                    break;
                case "7":
                    UpdateDependenciesVersion();
                    break;
                case "0":
                    this.PublishManager.DisplayMainMenu();
                    break;
                default:
                    this.PublishManager.WrongCommand();
                    break;
            }

            DisplayChangeVersionMenu();
        }
        private void IncreaseBuildVersionNumber()
        {
            this.CurrentVersion = new Version(string.Format("{0}.{1}.{2}", this.CurrentVersion.Major, this.CurrentVersion.Minor, this.CurrentVersion.Build + 1));
        }

        private void IncreaseMinorVersionNumber()
        {
            this.CurrentVersion = new Version(string.Format("{0}.{1}.{2}", this.CurrentVersion.Major, this.CurrentVersion.Minor + 1, 0));
        }

        private void IncreaseMajorVersionNumber()
        {
            this.CurrentVersion = new Version(string.Format("{0}.{1}.{2}", this.CurrentVersion.Major + 1, 0, 0));
        }

        private void ShowCurrentVersion()
        {
            Console.WriteLine(string.Format("Current version: {0}", this.GetCurrentVersionString()));
        }

        public void ChangeVersion()
        {
            this.DisplayChangeVersionMenu();
        }

        public void FullProcessChangeVersion()
        {
            this.ChangeVersionInFiles();
            this.CommitCurrentVersion();
            this.UpdateDependenciesVersion();
        }

        private void ChangeVersionInFiles()
        {
            Console.WriteLine("--Changing version--");
            this.ChangeAssemblyInfoVerion();
            this.ChangeNuSpecVersion();
            this.ShowCurrentVersion();
        }

        private void ChangeAssemblyInfoVerion()
        {
            string fileName = "..\\..\\..\\" + this.ProductsManager.ProductName + "\\Properties\\AssemblyInfo.cs";
            string regexPattern = "\\[assembly: AssemblyVersion\\(\\\"\\d+\\.\\d+\\.\\d+.\\*\\\"\\)\\]";
            string versionPlaceholder = "[assembly: AssemblyVersion(\"{0}.*\")]";
            this.ChangeVersionInFile(fileName, regexPattern, versionPlaceholder);
        }

        private void ChangeNuSpecVersion()
        {
            string fileName = "..\\..\\..\\NuGet\\" + this.ProductsManager.ProductName + ".nuspec";
            string regexPattern = "<version>\\d+\\.\\d+\\.\\d+</version>";
            string versionPlaceholder = "<version>{0}</version>";
            this.ChangeVersionInFile(fileName, regexPattern, versionPlaceholder);
        }

        private void UpdateDependenciesVersion()
        {
            Console.WriteLine("--Updating dependencies with changed version--");
            foreach (var product in this.ProductsManager.Products)
            {
                this.UpdateDependencyVersion(product.Value);
            }
        }

        private void UpdateDependencyVersion(string dependentProduct)
        {
            string fileName = "..\\..\\..\\NuGet\\" + dependentProduct + ".nuspec";
            string regexPattern = "<dependency id=\"" + this.ProductsManager.ProductName + "\" version=\"\\d+\\.\\d+\\.\\d+\" />";
            string placeholder = "<dependency id=\"" + this.ProductsManager.ProductName + "\" version=\"{0}\" />";
            this.ChangeVersionInFile(fileName, regexPattern, placeholder);
        }

        private void ChangeVersionInFile(string fileName, string regexPattern, string placeholder)
        {
            string fileContent;

            Match match = GetVersionRegexMatch(fileName, regexPattern, out fileContent);
            if (match.Success)
            {
                fileContent = fileContent.Replace(match.Value, string.Format(placeholder, GetCurrentVersionString()));
            }

            File.WriteAllText(fileName, fileContent);
        }

        private void CommitCurrentVersion()
        {
            Console.WriteLine("--Commiting changed version--");
            this.PublishManager.Git("add ..\\..\\..\\" + this.ProductsManager.ProductName + "\\Properties\\AssemblyInfo.cs");
            this.PublishManager.Git("add ..\\..\\..\\NuGet\\" + this.ProductsManager.ProductName + ".nuspec");
            this.PublishManager.Git("commit -m \"Change version\"");
        }
    }
}
