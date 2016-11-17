using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGen.NumberToWords.Common
{
    public class NumberInWordsService
    {
        protected Common.NumeralsRepository NumeralsRepository { get; set; }

        protected Common.NumberInWordsFactory NumberInWordsFactory { get; set; }


        public NumberInWordsService(Common.NumeralsRepository numeralsRepository, Common.NumberInWordsFactory numberInWordsFactory)
        {
            this.NumeralsRepository = numeralsRepository;
            this.NumberInWordsFactory = numberInWordsFactory;
        }

        public virtual string InWords(int argument)
        {
            this.ValidateArgument(argument);

            INumberInWordsBuilder builder = this.NumberInWordsFactory.CreateNumberInWordsBuilder(argument, this.NumeralsRepository);
            builder.Build();
            var numberInWords = builder.NumberInWords;

            return numberInWords.Value;
        }

        private void ValidateArgument(int value)
        {
            if (value < -999999999 || value > 999999999)
            {
                throw new ArgumentOutOfRangeException("value");
            }
        }

        
    }
}
