using System;

namespace ConsoleApp1
{
    class Program
    {


        static double segment1(double x, double r)
        {
            double a = -8;
            double b = 0;
            double y;
            y = Math.Abs(Math.Sqrt(Math.Abs(r * r - (x - a) * (x - a) - b)));
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

        static void value_finder(double R1, double R2, double i)
        {

            if (i < -10)
            {
                Console.WriteLine("Функция не определена");
            }
            else if (i < -6)
            {
                if (R1 < 2)
                {
                    Console.WriteLine("При этих значениях возникают разрывы, выберите другой радиус: ");
                }
                else if (R1 > 2)
                {
                    Console.WriteLine("y({0:0.00}) = {1:0.00}", i, segment1(i, 0));
                }
                else if (R1 == 2)
                {
                    Console.WriteLine("y({0:0.00}) = {1:0.00}", i, segment1(i, 0));
                }

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

            double R1 = 0;
            double R = 0;

            Console.WriteLine("Введите радиус: ");
            R1 = double.Parse(Console.ReadLine());


            if (R1 < 0)
            {
                while (R1 < 0)
                {

                    Console.WriteLine("Радиус не может быть меньше 0, введите еще раз: ");
                    R1 = double.Parse(Console.ReadLine());

                }

            }



            double in_value = 0;

            while (in_value != 100)
            {
                Console.WriteLine("Введите x (Если вы хотите посмотреть значения в виде таблицы, введите 100): ");//
                in_value = double.Parse(Console.ReadLine());
                if (in_value != 100)
                {
                    value_finder(R1, R, in_value);
                }
            }


            for (double x = -10; x <= 4; x = x + 0.2)
            {
                value_finder(R1, R, x);
            }
        }
    }
}