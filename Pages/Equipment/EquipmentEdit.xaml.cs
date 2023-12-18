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

namespace UP._02_ver._2.Pages.Equipment
{
    /// <summary>
    /// Логика взаимодействия для EquipmentEdit.xaml
    /// </summary>
    public partial class EquipmentEdit : Page
    {
        MainWindow mainWindow;
        Page ParrentPage;
        Classes.Equipment curEquipment;
        public EquipmentEdit(MainWindow mainWindow,Page ParrenrPage)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
            LoadData();
        }
        public EquipmentEdit(MainWindow mainWindow, Page ParrenrPage, Classes.Equipment curEquipment)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
            this.curEquipment = curEquipment;
            LoadData(curEquipment);
        }
        public void LoadData()
        {
            Name.SetText(curEquipment.Name);
            Cost.SetText(curEquipment.Cost.ToString());
            Comment.SetText(curEquipment.Comment);
            User.ItemsSource = mainWindow.UsersList;
            TempUser.ItemsSource = mainWindow.UsersList;
            Direction.ItemsSource = mainWindow.DirectionsList;
            Model.ItemsSource = mainWindow.ModelsList;
            Type.ItemsSource = mainWindow.EquipmentTypesList;

        }
        public void LoadData(Classes.Equipment curEquipment)
        {
            LoadData();
            User.SelectedItem = curEquipment.User;
            TempUser.SelectedItem = curEquipment.Temp_user;
            Model.SelectedItem = curEquipment.Model;
            Type.SelectedItem = curEquipment.Type;
            Model.SelectedItem = curEquipment.Model;
            Direction.SelectedItem = curEquipment.Direction;
        }
        public void BackClick(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(ParrentPage);
        }

    }
}
