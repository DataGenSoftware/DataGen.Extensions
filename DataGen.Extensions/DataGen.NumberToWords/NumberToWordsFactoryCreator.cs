using DataGen.NumberToWords.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.NumberToWords
{
    /// <summary>
    /// Simple factory, creates factory for making families of related objects
    /// </summary>
    /// TODO: Implement singleton
    public class NumberToWordsFactoryCreator
    {
        public NumberToWordsFactory CreateFactory(string cultureName)
        {
            if (cultureName.StartsWith("en"))
            {
                return new En.NumberToWordsFactory();
            }
            else if (cultureName.StartsWith("pl"))
            {
                return new Pl.NumberToWordsFactory();
            }

            throw new ArgumentException("Invalid argument.", "cultureName");
        }
    }
}
