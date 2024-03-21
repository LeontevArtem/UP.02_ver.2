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
using UP._02_ver._2.Classes;

namespace UP._02_ver._2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        MainWindow mainWindow;
        public Main(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }
        public void UserClick(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(new Pages.Users.UserMain(mainWindow,this));
        }
        public void EquipmentClick(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(new Pages.Equipment.EquipmentMain(mainWindow,this));
        } 
        public void RoomsClick(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(new Pages.Rooms.RoomsMain(mainWindow,this));
        }
        public void ReportsClick(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(new importBD.Pages.main(this, mainWindow.OpenPage));
        }
        public void ImportClick(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(new Reports.Pages.Main(this, mainWindow.OpenPage));
        }
        public void TypeClick(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(new Pages.Types.TypesMain(mainWindow,this));
        } 
        public void DirectionsClick(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(new Pages.Directions.DirectionsMain(mainWindow,this));
        }
        public void ModelsClick(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(new Pages.Models.ModelsMain(mainWindow,this));
        }
    }
}
