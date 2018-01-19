using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions.Publish.Common
{
    public class PublishManager
    {
        public ProductsManager ProductsManager { get; set; }

        public VersionManager VersionManager { get; set; }

        public BuildManager BuildManager { get; set; }

        public NuGetManager NuGetManager { get; set; }



		private string GitPath
		{
			get
			{
				return this.GetAppSetting("GitPath");
			}
		}

		public void DisplayMenu()
        {
            if (this.ProductsManager.Products.Count > 1)
            {
                this.ProductsManager.DisplayProductMenu();
            }
            else
            {
                this.DisplayMainMenu();
            }
        }

        public void DisplayMainMenu()
        {
            Console.WriteLine();
            Console.WriteLine(string.Format("---{0} Main menu---", this.ProductsManager.Product));
            Console.WriteLine("1 - Change verion");
            Console.WriteLine("2 - Rebuild");
            Console.WriteLine("3 - Publish to NuGet");
            if (this.ProductsManager.Products.Count > 1)
            {
                Console.WriteLine("0 - Product menu");
            }
            else
            {
                Console.WriteLine("0 - Exit");
            }

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
                    if (this.ProductsManager.Products.Count > 1)
                    {
                        this.ProductsManager.DisplayProductMenu();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
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

                this.ProductsManager.Product = product.Value;
                Console.WriteLine(this.ProductsManager.Product);

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
            string fileName = this.GitPath;
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

        public string GetAppSetting(string key)
        {
            var appSetting = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrWhiteSpace(appSetting))
            {
                throw new Exception(string.Format("{0} appsetting is missing.", key));
            }
            return appSetting;
        }
    }
}
