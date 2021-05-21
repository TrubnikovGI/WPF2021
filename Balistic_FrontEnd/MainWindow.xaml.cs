using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Balistic_FrontEnd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        double a;
        double v;
        double m;

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            a = Convert.ToDouble(Ang_val.Text);
            v = Convert.ToDouble(Vol_val.Text);
            m = Convert.ToDouble(Mas_val.Text);

            Coordinates Obj = new Coordinates(a, v, m);

            Obj.Demo();

        }


    }


    class Coordinates
    {
        double ang, vol, mass;

        public Coordinates(double a, double v, double m)
        {
            ang = (Math.PI * a) / 180;
            vol = v;
            mass = m;
        }

        public void Demo()
        {
            double max_y = 0, max_x = 0;

            double v_x = vol * Math.Cos(ang);
            double v_y = vol * Math.Sin(ang);
            double x = 0, y = 0, t = 0.01;

            do
            {
                x = x + (0.01 * v_x);
                y = y + (0.01 * v_y);

                if (y > max_y)
                    max_y = y;

                if (x > max_x)
                    max_x = x;

                if (y < 0)
                    y = 0;

                v_x = Vol_x(t, v_x, mass, 0.01);
                v_y = Vol_y(t, v_x, mass, 0.01);

                t += 0.01;
            }
            while (y > 0);

            MessageBox.Show(Convert.ToString(max_x), "дальность полёта");
            MessageBox.Show(Convert.ToString(max_y), "максимальная высота подъёма");

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
            while (y > 0);
        }

        public void Write_to_File(string path = @"..\..\Flight.csv")
        {


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

}
