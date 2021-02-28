using System;

namespace Balistic
{
    class Program
    {
        static void Main(string[] args)
        {
            double angle, hight, vol, y = 0;
            int t = 0;
            angle = Convert.ToDouble(Console.ReadLine());
            hight = Convert.ToDouble(Console.ReadLine());
            vol = Convert.ToDouble(Console.ReadLine());
            
            if(angle > Math.PI/2 || hight < 0 || vol <= 0)
            {
                Console.WriteLine("Ошибка ввода данных, координаты полёта тела будут найденный неверно");
            }

            angle = (angle * Math.PI) / 180;
            do
            {
                y = hight + (vol * Math.Sin(angle) * t) - (9.81 * t * t) / 2;
                t += 1;
            } while (y > 0);
            t *= 10;
            double[] abscisa = new double[t];
            double[] ordinata = new double[t];
            double k;
            for (int i = 0; i < t; i++)
            {
                k = i;
                abscisa[i] = vol * Math.Cos(angle) * (k/10);
                ordinata[i] = hight + (vol * Math.Sin(angle) * (k/10)) - (9.81 * (k/10) * (k/10)) / 2;
                if (ordinata[i] < 0)
                {
                    ordinata[i] = 0;
                }
            }

            Console.WriteLine("t:   x   y");
            for (int i = 0; i < t; i++)
            {
                Console.WriteLine("{0}:   {1}   {2}", i, abscisa[i], ordinata[i]);
            }

        }
    }
}
