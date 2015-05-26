using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Sql.Net.Extensions
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

		public static string ToWords(this long Liczba, string culture)
		{
			if (culture == "pl-PL")
			{
				string Slownie;
				Slownie = "";

				if (Liczba < 0)
				{
					Slownie += "minus ";
					Liczba = Liczba * (-1);
				}

				bool Tysiace;
				int Liczba_tys;
				Liczba_tys = 0;

				int Liczba_int;
				Liczba_int = Convert.ToInt32(Liczba);

				string Liczba_str;
				Liczba_str = Liczba_int.ToString();

				int Liczba_tmp;

				while (Liczba_str.Length > 0)
				{
					Tysiace = false;
					Liczba_tmp = Convert.ToInt32(Liczba_str.Substring(0, 1));
					Liczba_tys += Liczba_tmp;
					if ((Liczba_str.Length % 3) == 1)
					{
						switch (Liczba_tmp)
						{
							case 1:
								Slownie += "jeden "; break;
							case 2:
								Slownie += "dwa "; break;
							case 3:
								Slownie += "trzy "; break;
							case 4:
								Slownie += "cztery "; break;
							case 5:
								Slownie += "pięć "; break;
							case 6:
								Slownie += "sześć "; break;
							case 7:
								Slownie += "siedem "; break;
							case 8:
								Slownie += "osiem "; break;
							case 9:
								Slownie += "dziewięć "; break;
							default:
								Slownie += ""; break;
						}
					}
					else if ((Liczba_str.Length % 3) == 2)
					{
						if (Liczba_tmp == 1)
						{

							Liczba_str = Liczba_str.Substring(1, Liczba_str.Length - 1);
							Liczba_tmp = Convert.ToInt32(Liczba_str.Substring(0, 1));

							switch (Liczba_tmp)
							{
								case 1:
									Slownie += "jedenaście "; break;
								case 2:
									Slownie += "dwanaście "; break;
								case 3:
									Slownie += "trzynaście "; break;
								case 4:
									Slownie += "czternascie "; break;
								case 5:
									Slownie += "piętnaście "; break;
								case 6:
									Slownie += "szesnaście "; break;
								case 7:
									Slownie += "siedemnaście "; break;
								case 8:
									Slownie += "osiemnaście "; break;
								case 9:
									Slownie += "dziewiętnaście "; break;
								case 0:
									Slownie += "dziesięć "; break;
								default:
									Slownie += ""; break;
							}
							if (Liczba_tys > 0)
							{
								if (Liczba_str.Length == 4)
								{
									Slownie += "tysięcy ";
									Tysiace = true;
								}
								if (Liczba_str.Length == 7)
								{
									Slownie += "milionów ";
									Tysiace = true;
								}
								if (Liczba_str.Length == 10)
								{
									Slownie += "miliardów ";
									Tysiace = true;
								}
							}
							Liczba_tys = 0;
						}
						else
						{
							switch (Liczba_tmp)
							{
								case 1:
									Slownie += ""; break;
								case 2:
									Slownie += "dwadzieścia "; break;
								case 3:
									Slownie += "trzydzieści "; break;
								case 4:
									Slownie += "czterdzieści "; break;
								case 5:
									Slownie += "pięćdziesiąt "; break;
								case 6:
									Slownie += "sześćdziesiąt "; break;
								case 7:
									Slownie += "siedemdziesiąt "; break;
								case 8:
									Slownie += "osiemdziesiąt "; break;
								case 9:
									Slownie += "dziewięćdziesiąt "; break;
								default:
									Slownie += ""; break;
							}
						}
					}
					else if ((Liczba_str.Length % 3) == 0)
					{
						switch (Liczba_tmp)
						{
							case 1:
								Slownie += "sto "; break;
							case 2:
								Slownie += "dwieście "; break;
							case 3:
								Slownie += "trzysta "; break;
							case 4:
								Slownie += "czterysta "; break;
							case 5:
								Slownie += "pięćset "; break;
							case 6:
								Slownie += "sześćset "; break;
							case 7:
								Slownie += "siedemset "; break;
							case 8:
								Slownie += "osiemset "; break;
							case 9:
								Slownie += "dziewięćset "; break;
							default:
								Slownie += ""; break;
						}
					}
					if (Tysiace == false && Liczba_tys > 0)
					{
						if (Liczba_str.Length == 4)
						{
							switch (Liczba_tmp)
							{
								case 1:
									Slownie += "tysiąc "; break;
								case 2:
								case 3:
								case 4:
									Slownie += "tysiące "; break;
								case 5:
								case 6:
								case 7:
								case 8:
								case 9:
								case 0:
									Slownie += "tysięcy "; break;
								default:
									Slownie += ""; break;
							}
							Liczba_tys = 0;
						}
						if (Liczba_str.Length == 7)
						{
							switch (Liczba_tmp)
							{
								case 1:
									Slownie += "milion "; break;
								case 2:
								case 3:
								case 4:
									Slownie += "miliony "; break;
								case 5:
								case 6:
								case 7:
								case 8:
								case 9:
								case 0:
									Slownie += "milionów "; break;
								default:
									Slownie += ""; break;
							}
							Liczba_tys = 0;
						}
						if (Liczba_str.Length == 10)
						{
							switch (Liczba_tmp)
							{
								case 1:
									Slownie += "miliard "; break;
								case 2:
								case 3:
								case 4:
									Slownie += "milirady "; break;
								case 5:
								case 6:
								case 7:
								case 8:
								case 9:
								case 0:
									Slownie += "miliardów "; break;
								default:
									Slownie += ""; break;
							}
							Liczba_tys = 0;
						}
					}

					Liczba_str = Liczba_str.Substring(1, Liczba_str.Length - 1);
				}

				if (Slownie.Trim() == "")
				{
					return " - - - ";
				}
				else
				{
					return Slownie;
				}
			}
			else
			{
				throw new ArgumentException("Method for specified culture is not implemented.", "culture");
			}
		}
	}
}
