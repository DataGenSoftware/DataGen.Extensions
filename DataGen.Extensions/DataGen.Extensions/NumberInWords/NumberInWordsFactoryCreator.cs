using DataGen.Extensions.NumberInWords.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGen.Extensions.NumberInWords
{
    /// <summary>
    /// Simple factory, creates factory for making families of related objects
    /// </summary>
    /// TODO: Implement singleton
    public class NumberInWordsFactoryCreator
    {
        public NumberInWordsFactory CreateFactory(string cultureName)
        {
            if (cultureName.StartsWith("en"))
            {
                return new En.NumberInWordsFactory();
            }
            else if (cultureName.StartsWith("pl"))
            {
                return new Pl.NumberInWordsFactory();
            }

            throw new ArgumentException("Invalid argument.", "cultureName");
        }
    }
}
