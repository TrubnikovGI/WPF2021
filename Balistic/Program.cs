using System;

namespace Balistic
{
    class Coordinates
    {
        private double[] abscisa;
        private double[] ordinata;
        private int time;
        public Coordinates(double ang, double v)
        {
            ang = (ang * Math.PI) / 180;
            double t = (2 * v * Math.Sin(ang)) / 9.81;
            int l = (int)Math.Round(t) * 10;

            time = l;
            abscisa = new double[l];
            ordinata = new double[l];

            double k;
            for (int i = 0; i < l; i++)
            {
                k = i;
                abscisa[i] = v * Math.Cos(ang) * (k / 10);
                ordinata[i] = (v * Math.Sin(ang) * (k / 10)) - (9.81 * (k / 10) * (k / 10)) / 2;
                if (ordinata[i] < 0)
                {
                    ordinata[i] = 0;
                }
            }


        }

        public void Write_Coordinates()
        {
            Console.WriteLine("t:   x   y");
            for (int i = 0; i < time; i++)
            {
                Console.WriteLine("{0}:   {1}   {2}", i, abscisa[i], ordinata[i]);
            }
        }
    }
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

            Coordinates Hammer = new Coordinates(angle, vol);

            Hammer.Write_Coordinates();
            
        }
    }
}
