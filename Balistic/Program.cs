using System;
using System.IO;

namespace Balistic
{
    class Coordinates
    {
        double ang, vol, mass;

        public Coordinates(double a, double v, double m)
        {
            ang = (Math.PI * a) / 180;
            vol = v;
            mass = m;
        }
        public void Write_to_Console()
        {
            double v_x = vol * Math.Cos(ang);
            double v_y = vol * Math.Sin(ang);
            double x = 0, y = 0, t = 0.01;

            Console.WriteLine("{0},   |||   {1}", x, y);

            do
            {
                x = x + (0.01 * v_x);
                y = y + (0.01 * v_y);

                if (y < 0)
                    y = 0;

                v_x = Vol_x(t, v_x, mass, 0.01);
                v_y = Vol_y(t, v_x, mass, 0.01);

                Console.WriteLine("{0},   |||   {1}", x, y);

                t += 0.01;
            }
            while (y > 0) ;
        }

        public void Write_to_File()
        {
            string path = @"..\..\..\Flight.csv";
            using (StreamWriter in_File = new StreamWriter(path))
            {
                in_File.WriteLine("angle: {0}; speed: {1}; mass: {2}", (ang * 180 / Math.PI), vol, mass);
                in_File.WriteLine(" ");
                in_File.WriteLine("t:; x:; y:;");

                double v_x = vol * Math.Cos(ang);
                double v_y = vol * Math.Sin(ang);
                double x = 0, y = 0, t = 0.01;

                in_File.WriteLine("0; {0};  {1}", x, y);

                do
                {
                    x = x + (0.01 * v_x);
                    y = y + (0.01 * v_y);

                    if (y < 0)
                        y = 0;

                    v_x = Vol_x(t, v_x, mass, 0.01);
                    v_y = Vol_y(t, v_x, mass, 0.01);

                    in_File.WriteLine("{0}; {1}; {2}", t, x, y);

                    t += 0.01;
                }
                while (y > 0);
            }

        }

        public double Wind_ver(double time)
        {
            return 9 * Math.Sin(5 * time);
        }
        public double Wind_hor(double time)
        {
            return 7 * Math.Cos(2.5 * time);
        }
        public double Vol_x(double time, double vol, double mass, double delta)
        {
            return vol - (delta * Wind_hor(time) * vol / mass);
        }
        public double Vol_y(double time, double vol, double mass, double delta)
        {
            return vol - ((9.81 + (delta * Wind_ver(time) * vol)) / mass);
        }

    }
 
    class Program
    {
        static void Main(string[] args)
        {
            double angle, vol, mass;
            angle = Convert.ToDouble(Console.ReadLine());
            vol = Convert.ToDouble(Console.ReadLine());
            mass = Convert.ToDouble(Console.ReadLine());


            if (angle >= 90 || vol <= 0 || mass <= 0)
            {
                Console.WriteLine("Ошибка ввода данных, координаты полёта тела будут найденный неверно");
            }

            Coordinates Hammer = new Coordinates(angle, vol, mass);

            Hammer.Write_to_File();
            Hammer.Write_to_Console();

        }
    }
}
