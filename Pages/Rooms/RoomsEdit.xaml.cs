using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.EMMA;
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

namespace UP._02_ver._2.Pages.Rooms
{
    /// <summary>
    /// Логика взаимодействия для RoomsEdit.xaml
    /// </summary>
    public partial class RoomsEdit : Page
    {
        MainWindow mainWindow;
        Page ParrentPage;
        Classes.Rooms rooms;
        public RoomsEdit(MainWindow mainWindow, Page ParrenrPage)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
            LoadData();
        }
        public RoomsEdit(MainWindow mainWindow, Page ParrenrPage, Classes.Rooms rooms)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
            this.rooms = rooms;
            LoadData(rooms);
        }
        public void LoadData()
        {
            User.ItemsSource = mainWindow.UsersList;
            Temp_user.ItemsSource = mainWindow.UsersList;

        }
        public void LoadData(Classes.Rooms rooms)
        {
            LoadData();
            Name.SetText(rooms.Name);
            Short_name.SetText(rooms.Short_name.ToString());
            Temp_user.SelectedItem = rooms.Temp_user;
            User.SelectedItem = rooms.User;
           
        }
        public void BackClick(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(ParrentPage);
        }
        public void SaveClick(object sender, MouseButtonEventArgs e)
        {
        }
    }
}
