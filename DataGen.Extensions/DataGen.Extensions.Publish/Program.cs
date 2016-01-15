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
            currentVersion = GetAssemblyCurrentVersion();

            DisplayMainMenu();
        }

        private static Version currentVersion;

        private static string GetCurrentVersionString()
        {
            if (currentVersion.IsNull())
                return string.Empty;

            return string.Format("{0}.{1}.{2}", currentVersion.Major, currentVersion.Minor, currentVersion.Build);
        }

        private static void DisplayMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("---Main menu---");
            Console.WriteLine("1 - Change verion");
            Console.WriteLine("2 - Rebuild");
            Console.WriteLine("3 - Publish to NuGet");
            Console.WriteLine("0 - Exit");

            GetUserCommand(new Action<string>(HandleMainMenuCommand));
        }

        private static void GetUserCommand(Action<string> menuCommandHandler)
        {
            var key = Console.ReadKey();
            Console.WriteLine();
            menuCommandHandler(key.KeyChar.ToString());
        }

        private static void HandleMainMenuCommand(string command)
        {
            switch (command)
            {
                case "1":
                    ChangeVersion();
                    break;
                case "2":
                    Rebuild();
                    break;
                case "3":
                    PublishToNuget();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    WrongCommand();
                    break;
            }

            DisplayMainMenu();
        }

        private static void Rebuild()
        {
            RebuildProjectWithConfiguration("Release 3.5");
            RebuildProjectWithConfiguration("Release 4.0");
            RebuildProjectWithConfiguration("Release 4.5");

            Console.WriteLine("Rebuild finished");
        }

        private static void RebuildProjectWithConfiguration(string configurationName)
        {
            Console.WriteLine("Rebuilding project with configuration: " + configurationName + "...");
            Console.WriteLine();
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "C:\\Windows\\Microsoft.NET\\Framework64\\v4.0.30319\\msbuild.exe",
                    Arguments = "..\\..\\..\\DataGen.Extensions\\DataGen.Extensions.csproj /nologo /v:m /t:Rebuild /property:Configuration=\"" + configurationName + "\";Platform=\"AnyCPU\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
            process.Start();
            while (!process.StandardOutput.EndOfStream)
            {
                string processOutput = process.StandardOutput.ReadLine();
                Console.WriteLine(processOutput);
            }
            Console.WriteLine();
        }

        private static Version GetAssemblyCurrentVersion()
        {
            string fileContent;
            var fileName = "..\\..\\..\\DataGen.Extensions\\Properties\\AssemblyInfo.cs";
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

        private static Match GetVersionRegexMatch(string fileName, string regexPattern, out string fileContent)
        {
            fileContent = File.ReadAllText(fileName);
            var match = Regex.Match(fileContent, regexPattern);
            return match;
        }

        private static void DisplayChangeVersionMenu()
        {
            Console.WriteLine();
            Console.WriteLine("---Change version menu---");
            Console.WriteLine("1 - Increase build version number");
            Console.WriteLine("2 - Increase minor version number");
            Console.WriteLine("3 - Increase major version number");
            Console.WriteLine("4 - Enter version");
            Console.WriteLine("5 - Show current version");
            Console.WriteLine("0 - Main menu");

            GetUserCommand(new Action<string>(HandleChangeVersionMenuCommand));
        }

        private static void HandleChangeVersionMenuCommand(string command)
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
                case "0":
                    DisplayMainMenu();
                    break;
                default:
                    WrongCommand();
                    break;
            }

            DisplayChangeVersionMenu();
        }

        private static void IncreaseBuildVersionNumber()
        {
            currentVersion = new Version(string.Format("{0}.{1}.{2}", currentVersion.Major, currentVersion.Minor, currentVersion.Build + 1));
        }

        private static void IncreaseMinorVersionNumber()
        {
            currentVersion = new Version(string.Format("{0}.{1}.{2}", currentVersion.Major, currentVersion.Minor + 1, 0));
        }

        private static void IncreaseMajorVersionNumber()
        {
            currentVersion = new Version(string.Format("{0}.{1}.{2}", currentVersion.Major + 1, 0, 0));
        }

        private static void EnterVersion()
        {
            Console.WriteLine("Enter version in format 'Major.Minor.Build'.");
            string version = Console.ReadLine();
            if (Regex.Match(version, "^\\d+\\.\\d+\\.\\d+$").Success)
            {
                currentVersion = new Version(version);
            }
            else
            {
                Console.WriteLine("Wrong format!");
                DisplayChangeVersionMenu();
            }
        }

        private static void ShowCurrentVersion()
        {
            Console.WriteLine(string.Format("Current version: {0}", GetCurrentVersionString()));
        }

        private static void ChangeVersion()
        {
            DisplayChangeVersionMenu();
        }

        private static void ChangeVersionInFiles()
        {
            ChangeAssemblyInfoVerion();
            ChangeNuSpecVersion();
            ShowCurrentVersion();
        }

        private static void ChangeAssemblyInfoVerion()
        {
            string fileName = "..\\..\\..\\DataGen.Extensions\\Properties\\AssemblyInfo.cs";
            string regexPattern = "\\[assembly: AssemblyVersion\\(\\\"\\d+\\.\\d+\\.\\d+.\\*\\\"\\)\\]";
            string versionPlaceholder = "[assembly: AssemblyVersion(\"{0}.*\")]";
            ChangeVersionInFile(fileName, regexPattern, versionPlaceholder);
        }

        private static void ChangeNuSpecVersion()
        {
            string fileName = "..\\..\\..\\NuGet\\DataGen.Extensions.nuspec";
            string regexPattern = "<version>\\d+\\.\\d+\\.\\d+</version>";
            string versionPlaceholder = "<version>{0}</version>";
            ChangeVersionInFile(fileName, regexPattern, versionPlaceholder);
        }

        private static void ChangeVersionInFile(string fileName, string regexPattern, string versionPlaceholder)
        {
            string fileContent;
            
            Match match = GetVersionRegexMatch(fileName, regexPattern, out fileContent);
            if (match.Success)
            {
                fileContent = fileContent.Replace(match.Value, string.Format(versionPlaceholder, GetCurrentVersionString()));
            }

            File.WriteAllText(fileName, fileContent);
        }

        private static void PublishToNuget()
        {

        }

        private static void WrongCommand()
        {
            Console.WriteLine("Wrong command! Try again.");
        }
    }
}
