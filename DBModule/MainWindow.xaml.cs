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

namespace DBModule
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //public static string ServerStr = "SD\\ADM";
        //public static string DatabaseStr = "UP.02";
        //public static string UserStr = "sa";
        public static string ServerStr = "DESKTOP-ARTEM";
        public static string DatabaseStr = "UP.02";
        public static string PwdStr = "sa";
        public static string UserStr = "sa";
       // public static string PwdStr = "Asdfg123!";

    }
}
