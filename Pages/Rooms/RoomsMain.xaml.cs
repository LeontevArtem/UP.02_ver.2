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
    /// Логика взаимодействия для RoomsMain.xaml
    /// </summary>
    public partial class RoomsMain : Page
    {
        MainWindow mainWindow;
        Page ParrentPage;
        public RoomsMain(MainWindow mainWindow, Page ParrentPage)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrentPage;
            ShowEquipment();
        }
        public void ShowEquipment()
        {
            EquipmentPanel.Children.Clear();
            foreach (Classes.Rooms rooms in mainWindow.RoomsList)
            {
                Pages.Rooms.RoomsElement.RoomsElement newRooms = new Pages.Rooms.RoomsElement.RoomsElement(mainWindow,rooms);
                newRooms.MouseDown += delegate { ElementClick(rooms); };
                EquipmentPanel.Children.Add(newRooms);
            }
            WpfControlLibrary2.Elements.Button1 AddButton = new WpfControlLibrary2.Elements.Button1() { XAMLText = "Добавить", XAMLTextColor = Color.FromRgb(255, 255, 255), Margin = new System.Windows.Thickness(10), Height = 75 };
            AddButton.MouseDown += delegate { AddClick(); };
            EquipmentPanel.Children.Add(AddButton);
        }
        public void BackClick(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(ParrentPage);
        }
        public void AddClick()
        {
            mainWindow.OpenPage(new Pages.Rooms.RoomsEdit(mainWindow, this));
        }
        public void ElementClick(Classes.Rooms rooms)
        {
            mainWindow.OpenPage(new Pages.Rooms.RoomsEdit(mainWindow, this, rooms));
        }
    }
}
