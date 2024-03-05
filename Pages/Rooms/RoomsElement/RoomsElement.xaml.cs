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

namespace UP._02_ver._2.Pages.Rooms.RoomsElement
{
    /// <summary>
    /// Логика взаимодействия для RoomsElement.xaml
    /// </summary>
    public partial class RoomsElement : UserControl
    {
        MainWindow mainWindow;
        Classes.Rooms rooms;
        public RoomsElement(MainWindow mainWindow, Classes.Rooms rooms)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.rooms = rooms;
            Name.Content = rooms.Name;
            Short_name.Content = rooms.Short_name;
            Temp_user.Content = $"{rooms.User.Surname} {rooms.User.Name} {rooms.User.Patronymic}";
            User.Content = $"{rooms.User.Surname} {rooms.User.Name} {rooms.User.Patronymic}";
        }
    }
}
