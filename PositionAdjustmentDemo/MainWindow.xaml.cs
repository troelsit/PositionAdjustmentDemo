using System;
using System.Collections.Generic;
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

namespace PositionAdjustmentDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            double h = 150;
            double x = 150;
            double t = 1;
            double adjustment = calculateAdjustment(h, x, t);
            Console.WriteLine("h: " + h + "x: " + x + " t: " + t + ", adjustment " + adjustment);

            h = 160;
            x = 160;
            t = 2;
            adjustment = calculateAdjustment(h, x, t);
            Console.WriteLine("h: " + h + "x: " + x + " t: " + t + ", adjustment " + adjustment);

            h = 160;
            x = 80;
            t = 1;
            adjustment = calculateAdjustment2(h, x, t);
            Console.WriteLine("h: " + h + "x: " + x + " t: " + t + ", adjustment " + adjustment);


        }

        public static double calculateAdjustment(double h, double x, double t)
        {
            double tan = Math.Atan(x / h);
            tan = (180 / Math.PI)*tan;
            double c = Math.Sqrt(x * x + h * h);
            double angle1 = 180 - (90 + tan);
            double angle2 = 90 - angle1;
            angle2 = (Math.PI / 180) * angle2;
            double l2 = c * c + t * t - 2 * c * t * Math.Cos(angle2);
            double l = Math.Sqrt(l2);

            double cosC = (c * c - t * t - l * l) / (-2 * t * l);
            double angle3 = Math.Acos(cosC);
            angle3 = (180 / Math.PI) * angle3;
            double angle4 = 180 - angle3;
            double angle5 = 180 - (90 + angle4);
            angle5 = (Math.PI/180) * angle5;
            double adjustment = t / Math.Tan(angle5);
            return adjustment;
        }

        public static double calculateAdjustment2(double h, double x, double t)
        {
            return t / h * x;
        }
    }
}
