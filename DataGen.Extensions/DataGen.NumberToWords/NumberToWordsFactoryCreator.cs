using DataGen.Extensions;
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
    public sealed class NumberToWordsFactoryCreator
    {
        #region Singleton

        private static volatile NumberToWordsFactoryCreator instance;

        private static readonly object syncObject = new object();

        static NumberToWordsFactoryCreator() { }

        private NumberToWordsFactoryCreator() { }
        
        public static NumberToWordsFactoryCreator Instance
        {
            get
            {
                if (instance.IsNull())
                {
                    lock(syncObject)
                    {
                        if (instance.IsNull())
                        {
                            instance = new NumberToWordsFactoryCreator();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion

        public NumberInWordsFactory CreateFactory(string cultureName)
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
