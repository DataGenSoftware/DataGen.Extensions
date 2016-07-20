using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions.Publish.Common
{
    public class PublishManager
    {
        public VersionManager VersionManager { get; set; }

        public BuildManager BuildManager { get; set; }

        public NuGetManager NuGetManager { get; set; }

        public ProductsManager ProductsManager { get; set; }

        

        public void DisplayMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine(string.Format("---{0} Main menu---", this.ProductsManager.ProductName));
            Console.WriteLine("1 - Change verion");
            Console.WriteLine("2 - Rebuild");
            Console.WriteLine("3 - Publish to NuGet");
            Console.WriteLine("0 - Product menu");

            this.GetUserCommand(new Action<string>(HandleMainMenuCommand));
        }

        private void HandleMainMenuCommand(string command)
        {
            switch (command)
            {
                case "1":
                    this.VersionManager.ChangeVersion();
                    break;
                case "2":
                    this.BuildManager.Rebuild();
                    break;
                case "3":
                    this.NuGetManager.Publish();
                    break;
                case "0":
                    this.ProductsManager.DisplayProductMenu();
                    break;
                default:
                    WrongCommand();
                    break;
            }

            DisplayMainMenu();
        }

        public void FullProcessForAll()
        {
            this.VersionManager.EnterVersion();

            foreach (var product in this.ProductsManager.Products)
            {
                Console.WriteLine();

                this.ProductsManager.ProductName = product.Value;
                Console.WriteLine(this.ProductsManager.ProductName);

                this.VersionManager.FullProcessChangeVersion();

                this.BuildManager.Rebuild();

                this.NuGetManager.Publish();
            }

            this.ProductsManager.DisplayProductMenu();
        }

        public void GetUserCommand(Action<string> menuCommandHandler)
        {
            var key = Console.ReadKey();
            Console.WriteLine();
            menuCommandHandler(key.KeyChar.ToString());
        }

        public void Git(string arguments)
        {
            string fileName = "C:\\Program Files\\Git\\cmd\\git.exe";
            Process(fileName, arguments);
        }

        public void Process(string fileName, string arguments)
        {
            Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            process.Start();
            while (!process.StandardOutput.EndOfStream)
            {
                string processOutput = process.StandardOutput.ReadLine();
                Console.WriteLine(processOutput);
            }
        }

        public void WrongCommand()
        {
            Console.WriteLine("Wrong command! Try again.");
        }
    }
}
