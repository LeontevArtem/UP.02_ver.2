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

namespace UP._02_ver._2.Pages.Consumables.ConsumablesElement
{
    /// <summary>
    /// Логика взаимодействия для ConsumablesElement.xaml
    /// </summary>
    public partial class ConsumablesElement : UserControl
    {
        MainWindow mainWindow;
        Classes.Consumables curConsumables;
        public ConsumablesElement(Classes.Consumables curConsumables, MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.curConsumables = curConsumables;
            Name.Content = curConsumables.Name;
            Description.Content = curConsumables.Description;
            Date.Content = curConsumables.Date;
            count.Content = curConsumables.Count;
            User.Content = curConsumables.User.FullName;
            TempUser.Content = curConsumables.User.FullName;
            EquipmentID.Content = curConsumables.EquipmentID.Name;
            Image.HideButton();
            Image.SetImage(curConsumables.Image);
            

        }
    }
}
