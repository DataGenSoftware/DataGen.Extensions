using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions.Publish.Common
{
    public class ProductsManager
    {
        public PublishManager PublishManager { get; set; }

        public VersionManager VersionManager { get; set; }

        public ProductsManager()
        {
            this.Products = this.GetProducts();
        }

        // TODO: Get from config
        public IDictionary<int, string> Products { get; set; }

        // TODO: Get from config
        public string ProductName { get; set; }

        // TODO: Get from config
        private IDictionary<int, string> GetProducts()
        {
            return new Dictionary<int, string>()
            {
                { 1, "DataGen.Extensions"},
                { 2, "DataGen.RomanNumerals"},
                { 3, "DataGen.NumberToWords"},
                { 4, "DataGen.Cryptography"},
            };
        }

        public void ChangeProduct(string productName)
        {
            this.ProductName = productName;
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
            switch (command)
            {
                case "1":
                    this.ChangeProduct("DataGen.Extensions");
                    break;
                case "2":
                    this.ChangeProduct("DataGen.RomanNumerals");
                    break;
                case "3":
                    this.ChangeProduct("DataGen.NumberToWords");
                    break;
                case "4":
                    this.ChangeProduct("DataGen.Cryptography");
                    break;
                case "9":
                    this.PublishManager.FullProcessForAll();
                    break;
                case "0":
                    Environment.Exit(0);
                    break;
                default:
                    this.PublishManager.WrongCommand();
                    break;
            }

            this.PublishManager.DisplayMainMenu();
        }
    }
}
