using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DataGen.Extensions
{
	public static class IntegerExtensions
	{
		public static string ToWords(this short Liczba, CultureInfo culture)
		{
			return ((long)Liczba).ToWords(culture);
		}

		public static string ToWords(this short Liczba, string culture)
		{
			return ((long)Liczba).ToWords(culture);
		}

		public static string ToWords(this int Liczba, CultureInfo culture)
		{
			return ((long)Liczba).ToWords(culture);
		}

		public static string ToWords(this int Liczba, string culture)
		{
			return ((long)Liczba).ToWords(culture);
		}

		public static string ToWords(this long Liczba, CultureInfo culture)
		{
			return Liczba.ToWords(culture.Name);
		}

		public static string ToWords(this long number, string culture)
		{
			if (culture.StartsWith("pl"))
			{
				return IntegerExtensions.ToWords_pl_PL(number);
			}
			else if (culture.StartsWith("en"))
			{
				return IntegerExtensions.ToWords_en(number);
			}
			else
			{
				throw new ArgumentException("Method for specified culture is not implemented.", "culture");
			}
		}

		private static string ToWords_en(long number)
		{
			string inWords;
			inWords = "";

			if (number < 0)
			{
				inWords += "minus ";
				number = number * (-1);
			}

			bool thousands;
			int numberThousands;
			numberThousands = 0;

			string numberString = number.ToString();

			int numberTmp;

			while (numberString.Length > 0)
			{
				thousands = false;
				numberTmp = Convert.ToInt32(numberString.Substring(0, 1));
				numberThousands += numberTmp;
				if ((numberString.Length % 3) == 1)
				{
					switch (numberTmp)
					{
						case 1:
							inWords += "one "; break;
						case 2:
							inWords += "two "; break;
						case 3:
							inWords += "three "; break;
						case 4:
							inWords += "four "; break;
						case 5:
							inWords += "five "; break;
						case 6:
							inWords += "six "; break;
						case 7:
							inWords += "seven "; break;
						case 8:
							inWords += "eight "; break;
						case 9:
							inWords += "nine "; break;
						default:
							inWords += ""; break;
					}
				}
				else if ((numberString.Length % 3) == 2)
				{
					if (numberTmp == 1)
					{

						numberString = numberString.Substring(1, numberString.Length - 1);
						numberTmp = Convert.ToInt32(numberString.Substring(0, 1));

						switch (numberTmp)
						{
							case 1:
								inWords += "eleven "; break;
							case 2:
								inWords += "twelve "; break;
							case 3:
								inWords += "thirteen "; break;
							case 4:
								inWords += "fourteen "; break;
							case 5:
								inWords += "fifteen "; break;
							case 6:
								inWords += "sixteen "; break;
							case 7:
								inWords += "seventeen "; break;
							case 8:
								inWords += "eighteen "; break;
							case 9:
								inWords += "nineteen "; break;
							case 0:
								inWords += "ten "; break;
							default:
								inWords += ""; break;
						}
						if (numberThousands > 0)
						{
							if (numberString.Length == 4)
							{
								inWords += "thousands ";
								thousands = true;
							}
							if (numberString.Length == 7)
							{
								inWords += "milions ";
								thousands = true;
							}
							if (numberString.Length == 10)
							{
								inWords += "bilions ";
								thousands = true;
							}
						}
						numberThousands = 0;
					}
					else
					{
						switch (numberTmp)
						{
							case 1:
								inWords += ""; break;
							case 2:
								inWords += "twenty "; break;
							case 3:
								inWords += "thirty "; break;
							case 4:
								inWords += "fourty "; break;
							case 5:
								inWords += "fifty "; break;
							case 6:
								inWords += "sixty "; break;
							case 7:
								inWords += "seventy "; break;
							case 8:
								inWords += "eighty "; break;
							case 9:
								inWords += "ninety "; break;
							default:
								inWords += ""; break;
						}
					}
				}
				else if ((numberString.Length % 3) == 0)
				{
					switch (numberTmp)
					{
						case 1:
							inWords += "one hundred "; break;
						case 2:
							inWords += "two hundreds "; break;
						case 3:
							inWords += "three hundreds "; break;
						case 4:
							inWords += "four hundreds "; break;
						case 5:
							inWords += "five hundreds "; break;
						case 6:
							inWords += "six hundreds "; break;
						case 7:
							inWords += "seven hundreds "; break;
						case 8:
							inWords += "eight hundreds "; break;
						case 9:
							inWords += "nine hundreds "; break;
						default:
							inWords += ""; break;
					}
				}
				if (thousands == false && numberThousands > 0)
				{
					if (numberString.Length == 4)
					{
						switch (numberTmp)
						{
							case 1:
								inWords += "thousand "; break;
							case 2:
							case 3:
							case 4:
							case 5:
							case 6:
							case 7:
							case 8:
							case 9:
							case 0:
								inWords += "thousands "; break;
							default:
								inWords += ""; break;
						}
						numberThousands = 0;
					}
					if (numberString.Length == 7)
					{
						switch (numberTmp)
						{
							case 1:
								inWords += "milion "; break;
							case 2:
							case 3:
							case 4:
							case 5:
							case 6:
							case 7:
							case 8:
							case 9:
							case 0:
								inWords += "milions "; break;
							default:
								inWords += ""; break;
						}
						numberThousands = 0;
					}
					if (numberString.Length == 10)
					{
						switch (numberTmp)
						{
							case 1:
								inWords += "bilion "; break;
							case 2:
							case 3:
							case 4:
							case 5:
							case 6:
							case 7:
							case 8:
							case 9:
							case 0:
								inWords += "bilions "; break;
							default:
								inWords += ""; break;
						}
						numberThousands = 0;
					}
				}

				numberString = numberString.Substring(1, numberString.Length - 1);
			}

			if (inWords.Trim() == "")
			{
				return " - - - ";
			}
			else
			{
				return inWords;
			}
		}

		private static string ToWords_pl_PL(long number)
		{
			string inWords;
			inWords = "";

			if (number < 0)
			{
				inWords += "minus ";
				number = number * (-1);
			}

			bool thousands;
			int numberThousands;
			numberThousands = 0;

			string numberString = number.ToString();

			int numberTmp;

			while (numberString.Length > 0)
			{
				thousands = false;
				numberTmp = Convert.ToInt32(numberString.Substring(0, 1));
				numberThousands += numberTmp;
				if ((numberString.Length % 3) == 1)
				{
					switch (numberTmp)
					{
						case 1:
							inWords += "jeden "; break;
						case 2:
							inWords += "dwa "; break;
						case 3:
							inWords += "trzy "; break;
						case 4:
							inWords += "cztery "; break;
						case 5:
							inWords += "pięć "; break;
						case 6:
							inWords += "sześć "; break;
						case 7:
							inWords += "siedem "; break;
						case 8:
							inWords += "osiem "; break;
						case 9:
							inWords += "dziewięć "; break;
						default:
							inWords += ""; break;
					}
				}
				else if ((numberString.Length % 3) == 2)
				{
					if (numberTmp == 1)
					{

						numberString = numberString.Substring(1, numberString.Length - 1);
						numberTmp = Convert.ToInt32(numberString.Substring(0, 1));

						switch (numberTmp)
						{
							case 1:
								inWords += "jedenaście "; break;
							case 2:
								inWords += "dwanaście "; break;
							case 3:
								inWords += "trzynaście "; break;
							case 4:
								inWords += "czternascie "; break;
							case 5:
								inWords += "piętnaście "; break;
							case 6:
								inWords += "szesnaście "; break;
							case 7:
								inWords += "siedemnaście "; break;
							case 8:
								inWords += "osiemnaście "; break;
							case 9:
								inWords += "dziewiętnaście "; break;
							case 0:
								inWords += "dziesięć "; break;
							default:
								inWords += ""; break;
						}
						if (numberThousands > 0)
						{
							if (numberString.Length == 4)
							{
								inWords += "tysięcy ";
								thousands = true;
							}
							if (numberString.Length == 7)
							{
								inWords += "milionów ";
								thousands = true;
							}
							if (numberString.Length == 10)
							{
								inWords += "miliardów ";
								thousands = true;
							}
						}
						numberThousands = 0;
					}
					else
					{
						switch (numberTmp)
						{
							case 1:
								inWords += ""; break;
							case 2:
								inWords += "dwadzieścia "; break;
							case 3:
								inWords += "trzydzieści "; break;
							case 4:
								inWords += "czterdzieści "; break;
							case 5:
								inWords += "pięćdziesiąt "; break;
							case 6:
								inWords += "sześćdziesiąt "; break;
							case 7:
								inWords += "siedemdziesiąt "; break;
							case 8:
								inWords += "osiemdziesiąt "; break;
							case 9:
								inWords += "dziewięćdziesiąt "; break;
							default:
								inWords += ""; break;
						}
					}
				}
				else if ((numberString.Length % 3) == 0)
				{
					switch (numberTmp)
					{
						case 1:
							inWords += "sto "; break;
						case 2:
							inWords += "dwieście "; break;
						case 3:
							inWords += "trzysta "; break;
						case 4:
							inWords += "czterysta "; break;
						case 5:
							inWords += "pięćset "; break;
						case 6:
							inWords += "sześćset "; break;
						case 7:
							inWords += "siedemset "; break;
						case 8:
							inWords += "osiemset "; break;
						case 9:
							inWords += "dziewięćset "; break;
						default:
							inWords += ""; break;
					}
				}
				if (thousands == false && numberThousands > 0)
				{
					if (numberString.Length == 4)
					{
						switch (numberTmp)
						{
							case 1:
								inWords += "tysiąc "; break;
							case 2:
							case 3:
							case 4:
								inWords += "tysiące "; break;
							case 5:
							case 6:
							case 7:
							case 8:
							case 9:
							case 0:
								inWords += "tysięcy "; break;
							default:
								inWords += ""; break;
						}
						numberThousands = 0;
					}
					if (numberString.Length == 7)
					{
						switch (numberTmp)
						{
							case 1:
								inWords += "milion "; break;
							case 2:
							case 3:
							case 4:
								inWords += "miliony "; break;
							case 5:
							case 6:
							case 7:
							case 8:
							case 9:
							case 0:
								inWords += "milionów "; break;
							default:
								inWords += ""; break;
						}
						numberThousands = 0;
					}
					if (numberString.Length == 10)
					{
						switch (numberTmp)
						{
							case 1:
								inWords += "miliard "; break;
							case 2:
							case 3:
							case 4:
								inWords += "milirady "; break;
							case 5:
							case 6:
							case 7:
							case 8:
							case 9:
							case 0:
								inWords += "miliardów "; break;
							default:
								inWords += ""; break;
						}
						numberThousands = 0;
					}
				}

				numberString = numberString.Substring(1, numberString.Length - 1);
			}

			if (inWords.Trim() == "")
			{
				return " - - - ";
			}
			else
			{
				return inWords;
			}
		}
	}
}
