using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions.Publish.Common
{
    public class ProductsManager
    {
        public PublishManager PublishManager { get; set; }

        public VersionManager VersionManager
        {
            get
            {
                return this.PublishManager.VersionManager;
            }
        }

        public BuildManager BuildManager
        {
            get
            {
                return this.PublishManager.BuildManager;
            }
        }

        public NuGetManager NuGetManager
        {
            get
            {
                return this.PublishManager.NuGetManager;
            }
        }

        public ProductsManager(PublishManager publishManager)
        {
            this.PublishManager = publishManager;
            this.Products = this.GetProducts();
            this.Product = this.GetDefaultProduct();
        }

        public IDictionary<string, string> Products { get; set; }

        public string Product { get; set; }

        private IDictionary<string, string> GetProducts()
        {
            Dictionary<string, string> products = new Dictionary<string, string>();

            var productsAppSetting = ConfigurationManager.AppSettings["Products"];
            if (!string.IsNullOrWhiteSpace(productsAppSetting))
            {
                products = productsAppSetting.Split(';').ToDictionary(x => x.Split('|')[0], x => x.Split('|')[1]);
            }
            else
            {
                products.Add("0", this.GetDefaultProduct());
            }

            return products;
        }

        private string GetDefaultProduct()
        {
            return this.PublishManager.GetAppSetting("DefaultProduct");
        }

        public void ChangeProduct(string productName)
        {
            this.Product = productName;
            this.VersionManager.UpdateAssemblyCurrentVersion();

            this.PublishManager.DisplayMainMenu();
        }

        public void DisplayProductMenu()
        {
            Console.WriteLine();
            Console.WriteLine("---Product menu---");
            foreach (var product in Products)
            {
                Console.WriteLine(string.Format("{0} - {1}", product.Key, product.Value));
            }
            Console.WriteLine("9 - Full process for all");
            Console.WriteLine("0 - Exit");

            this.PublishManager.GetUserCommand(new Action<string>(HandleProductMenuCommand));
        }

        private void HandleProductMenuCommand(string command)
        {
            if (this.Products.ContainsKey(command))
            {
                this.ChangeProduct(this.Products[command]);
            }
            else if(command == "9")
            {
                this.PublishManager.FullProcessForAll();
            }
            else if (command == "0")
            {
                Environment.Exit(0);
            }
            else
            {
                this.PublishManager.WrongCommand();
            }

            this.PublishManager.DisplayMainMenu();
        }
    }
}
