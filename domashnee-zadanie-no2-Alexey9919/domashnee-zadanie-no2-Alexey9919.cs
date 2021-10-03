using System;

namespace function_analysis
{
	class Program
	{
		static void Main(string[] args)
		{
			double R = 0;

			Console.WriteLine("Введите параметр R:");

			R = double.Parse(Console.ReadLine()); //Считаем R

			if (R < 0) //Радиус не может быть меньше 0, но может быть ему равен
			{
				while (R < 0)
				{
					Console.WriteLine("R не может быть меньше 0, повторите попытку:"); 
					R = double.Parse(Console.ReadLine());
				}
			}

			Console.WriteLine("Значения функции для всех x от -10 до 4:");

			for (double x = -10.0; x < 4; x = x + 0.1) 
			{
				sector_detection(R, x);
			}

			Console.WriteLine("\r\n-------------------------\r\n");

			double in_value = 0; // Программа для значений x 

			while (in_value != 500)
			{
				Console.WriteLine("Введите x, для которого хотите получить значение функции. 500 - Если хотите завершить работу");
				in_value = double.Parse(Console.ReadLine());
				if (in_value != 500) sector_detection(R, in_value); //x = 500 остановка 
			}
		}

		static void sector_detection(double R, double i)
		{
			i = Math.Round(i, 1);
			if (i < -10)
			{
				Console.WriteLine("Функция не определена"); 
			}
			else if (i < -8)
			{
				if (R < 2) //когда радиус меньше 2, образуются точки разрыва 
				{
					if ((i >= -8) && (i <= -8 - R))
					{
						if (i == -10)
						{
							Console.WriteLine($"y({i}) = {0} (точка разрыва, слева)");
						}
						else if (i == -8 - R)
						{
							Console.WriteLine($"y({i}) = {0} (точка разрыва, справа)"); 
						}
					}
					else
					{
						Console.WriteLine($"y({i}) = {sector_1(i, R)}"); //когда четверть-окружность начинается, то её значения можно посчитать по основной формуле
					}

				}
				else if (R > 2)
				{
					Console.WriteLine($"y({i}) = {sector_unknownarc(i, R)}"); 
				}
				else
				{
					Console.WriteLine($"y({i}) = {sector_1(i, R)}"); 
				}
			}
			else if (i <= -6) //аналогично для правой части полуокружности
			{
				if (R < 2)
				{
					if ((i >= R) && (i <= -6))
					{
						if (i == R)
						{
							Console.WriteLine($"y({i}) = {0} (точка разрыва, слева)");
						}
						else if (i == -6)
						{
							Console.WriteLine($"y({i}) = {0} (точка разрыва, справа)");
						}
					}
					else
					{
						Console.WriteLine($"y({i}) = {sector_2(i, R)}"); 
					}
				}
				else if (R > 2)
				{
					Console.WriteLine($"y({i}) = {sector_unknownarc(i, R)}");
				}
				else
				{
					Console.WriteLine($"y({i}) = {sector_2(i, R)}"); 
				}
			}
			else if (i <= -4)
			{
				Console.WriteLine($"y({i}) = {sector_3()}"); // Сектор 3
			}
			else if (i <= 0)


			{
				Console.WriteLine($"y({i}) = {sector_4(i)}"); // Сектор 4
			}
			else if (i <= 2)
			{
				Console.WriteLine($"y({i}) = {sector_5(i)}"); // Сектор 5
			}
			else if (i <= 4)
			{
				Console.WriteLine($"y({i}) = {sector_6(i)}"); // Сектор 6
			}
			else if (i > 4)
			{
				Console.WriteLine("Функция не определена"); //если точка правее шестого сектора
			}
		}

		static double sector_1(double x, double r)
		{
			return Math.Round(Math.Sqrt(r * r - x * x), 5); // т. Пифагора
		}
		static double sector_2(double x, double r)
		{
			return Math.Round(Math.Sqrt(r * r - x * x), 5); 
		}
		static double sector_3()
		{
			return 2; // Прямая y = 2
		}
		static double sector_4(double x)
		{
			return Math.Round(-0.5 * x, 5); // Функция вида y=kx+b
		}
		static double sector_5(double x)
		{
			return Math.Round(-0.5 * x, 5); // Функция вида y=kx+b
		}
		static double sector_6(double x)
		{
			return Math.Round(x - 3, 5); // Функция вида kx+b
		}
		static void sector_unknowngap(double x, double r, out double left, out double right)
		{
			if (x < -8) //если радиус меньше трёх, то мы мысленно переносим четверть окружности в право до нуля, и слева получается разрыв
			{
				left = -8; //Левая часть окружности
				right = -Math.Abs(r); 
			}
			else
			{
				left = -6; 
				right = Math.Abs(r); 
			}
		}
		static double sector_unknownarc(double x, double r) 
		{
			double delta = Math.Round(Math.Sqrt(r * r - 4), 5);
			return Math.Round(Math.Sqrt(r * r - x * x) - delta, 5);
		}
	}
}
