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

namespace UP._02_ver._2.Pages.Equipment.EquipmentElements
{
    /// <summary>
    /// Логика взаимодействия для EquipmentElement.xaml
    /// </summary>
    public partial class EquipmentElement : UserControl
    {
        MainWindow mainWindow;
        Classes.Equipment curEquipment;
        public EquipmentElement(Classes.Equipment curEquipment,MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.curEquipment = curEquipment;
            Name.Content = curEquipment.Name;
            //Image.Source = new BitmapImage(new Uri(curEquipment.Image));
            InventoryNumber.Content = curEquipment.Equipment_id;
            Room.Content = curEquipment.Room.Name;
            User.Content = $"{curEquipment.User.Surname} {curEquipment.User.Name} {curEquipment.User.Patronymic}";
            TempUser.Content = $"{curEquipment.Temp_user.Surname} {curEquipment.Temp_user.Name} {curEquipment.Temp_user.Patronymic}";
            Price.Content = curEquipment.Cost;
            Direction.Content = curEquipment.Direction.Name;
            Status.Content = curEquipment.Status;
            Model.Content = curEquipment.Model.Name;
            Comment.Text = curEquipment.Name;
        }
    }
}
