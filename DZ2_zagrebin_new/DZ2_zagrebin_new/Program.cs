using System;

namespace ConsoleApp1

{

    class Program

    {

        static double segment1(double x, double r)

        {

            // На графике R = 2

            double a = -8;

            double b = -2;

            double y;

            y = -Math.Sqrt(r * r - (x - a) * (x - a)) - b;

            return y;

        }

        static double segment2()

        {

            double y;

            y = 2;

            return y;

        }

        static double segment3(double x)

        {

            double y;

            y = -0.5 * x;

            return y;

        }

        static double segment4(double x)

        {

            double y;

            y = x - 3;

            return y;

        }

        static void value_finder(double i, double r)

        {

            if (i < -10)

            {

                Console.WriteLine("Функция не определена");

            }

            else if (i < -6)

            {

                if ((r < 2) && (Math.Abs(i + 8) >= r))

                    Console.WriteLine("Точка разрыва второго рода");

                else

                    Console.WriteLine("y({0:0.00}) = {1:0.00}", i, segment1(i, r));

            }

            else if (i <= -4)

            {

                Console.WriteLine("y({0:0.00}) = {1:0.00}", i, segment2());

            }

            else if (i <= 2)

            {

                Console.WriteLine("y({0:0.00}) = {1:0.00}", i, segment3(i));

            }

            else if (i <= 4)

            {

                Console.WriteLine("y({0:0.00}) = {1:0.00}", i, segment4(i));

            }

            else if (i > 4)

            {

                Console.WriteLine("Функция не определена");

            }

        }

        static void Main(string[] args)

        {

            double R = 0;

            Console.WriteLine("Введите радиус: ");

            R = double.Parse(Console.ReadLine());

            if (R < 0)

            {

                while (R < 0)

                {

                    Console.WriteLine("Радиус не может быть меньше 0, введите еще раз: ");

                    R = double.Parse(Console.ReadLine());

                }

            }

            double in_value = 0;

            while (in_value != 100)

            {

                Console.WriteLine("Введите x (Если вы хотите посмотреть значения в виде таблицы, введите 100): ");

                in_value = double.Parse(Console.ReadLine());

                if (in_value != 100)

                {

                    value_finder(in_value, R);

                }

            }

            for (double x = -10; x <= 4; x = x + 0.2)

            {

                value_finder(x, R);

            }

        }

    }
}