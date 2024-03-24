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

namespace UP._02_ver._2.Pages.Inventory.InventoryElement
{
    /// <summary>
    /// Логика взаимодействия для InventoryElements.xaml
    /// </summary>
    public partial class InventoryElements : UserControl
    {
        MainWindow mainWindow;
        Classes.Inventory curInventory;
        public InventoryElements(MainWindow mainWindow, Classes.Inventory curInventory)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.curInventory = curInventory;
            StartDate.Content = curInventory.Date_start;
            EndDate.Content = curInventory.Date_end;
            Name.Content = curInventory.Name;
            User.Content = curInventory.User;
            Comment.Content = curInventory.Comment;
        }
    }
}
