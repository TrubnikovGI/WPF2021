using System;

namespace Balistic
{
    class Program
    {
        static void Main(string[] args)
        {
            double angle, vol;
            angle = Convert.ToDouble(Console.ReadLine());
            vol = Convert.ToDouble(Console.ReadLine());
            
            if(angle >= 90 || vol <= 0)
            {
                Console.WriteLine("Ошибка ввода данных, координаты полёта тела будут найденный неверно");
            }

            angle = (angle * Math.PI) / 180;
            double t = (2 * vol * Math.Sin(angle)) / 9.81;
            int l = (int)Math.Round(t)*10;
            
            
            double[] abscisa = new double[l];
            double[] ordinata = new double[l];
            double k;
            for (int i = 0; i < l; i++)
            {
                k = i;
                abscisa[i] = vol * Math.Cos(angle) * (k/10);
                ordinata[i] = (vol * Math.Sin(angle) * (k/10)) - (9.81 * (k/10) * (k/10)) / 2;
                if (ordinata[i] < 0)
                {
                    ordinata[i] = 0;
                }
            }

            Console.WriteLine("t:   x   y");
            for (int i = 0; i < l; i++)
            {
                Console.WriteLine("{0}:   {1}   {2}", i, abscisa[i], ordinata[i]);
            }
            
        }
    }
}
