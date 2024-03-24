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

namespace UP._02_ver._2.Pages.Consumables
{
    /// <summary>
    /// Логика взаимодействия для ConsumablesMain.xaml
    /// </summary>
    public partial class ConsumablesMain : Page
    {
        MainWindow mainWindow;
        Page ParrentPage;
        public ConsumablesMain(MainWindow mainWindow, Page ParrentPage)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrentPage;
            ShowEquipment();
        }
        public void ShowEquipment()
        {
            EquipmentPanel.Children.Clear();
            foreach (Classes.Consumables curConsumables in mainWindow.ConsumablesList)
            {
                Pages.Consumables.ConsumablesElement.ConsumablesElement newElement = new Pages.Consumables.ConsumablesElement.ConsumablesElement(curConsumables, mainWindow);
                newElement.MouseDown += delegate { ElementClick(curConsumables); };
                EquipmentPanel.Children.Add(newElement);
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
            mainWindow.OpenPage(new Pages.Consumables.ConsumablesEdit(mainWindow, this));
        }
        public void ElementClick(Classes.Consumables curConsumables)
        {
            mainWindow.OpenPage(new Pages.Consumables.ConsumablesEdit(mainWindow, this, curConsumables));
        }
    }
}
