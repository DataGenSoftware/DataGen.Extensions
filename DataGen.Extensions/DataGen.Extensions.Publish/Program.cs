using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions.Publish
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayMenu();
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("1 - Rebuild");
            Console.WriteLine("2 - Change verion");
            Console.WriteLine("3 - Publish to NuGet");
            Console.WriteLine("0 - Exit");

            GetUserCommand();
        }

        private static void GetUserCommand()
        {
            var key = Console.ReadKey();
            Console.WriteLine();
            HandleCommand(key.KeyChar.ToString());
        }

        private static void HandleCommand(string command)
        {
            switch (command)
            {
                case "1":
                    Rebuild();
                    break;
                case "2":
                    ChangeVersion();
                    break;
                case "3":
                    PublishToNuget();
                    break;
                case "0":
                    return;
                default:
                    WrongCommand();
                    break;
            }

            GetUserCommand();
        }

        private static void Rebuild()
        {
            RebuildProjectWithConfiguration("Release 3.5");
            RebuildProjectWithConfiguration("Release 4.0");
            RebuildProjectWithConfiguration("Release 4.5");

            Console.WriteLine("Rebuild finished.");
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
                    Arguments = "..\\..\\..\\DataGen.Extensions\\DataGen.Extensions.csproj /t:t:Rebuild /property:Configuration=\"" + configurationName + "\";Platform=\"AnyCPU\"",
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

        private static void ChangeVersion()
        {

        }

        private static void PublishToNuget()
        {

        }

        private static void WrongCommand()
        {
            Console.WriteLine("Wrong command. Try again.");
        }
    }

}
