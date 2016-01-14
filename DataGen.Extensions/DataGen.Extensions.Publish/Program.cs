using System;
using System.Collections.Generic;
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

            Console.ReadKey();
        }

        private static void HandleCommand(string command)
        {

        }

        private static void Rebuild()
        {

        }

        private static void ChangeVersion()
        {

        }

        private static void PublishToNuget()
        {

        }

        private static void Exit()
        {
            
        }
    }

}
