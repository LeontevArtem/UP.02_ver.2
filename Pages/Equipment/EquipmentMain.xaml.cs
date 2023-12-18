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
    /// Логика взаимодействия для EquipmentMain.xaml
    /// </summary>
    public partial class EquipmentMain : Page
    {
        MainWindow mainWindow;
        Page ParrentPage;
        public EquipmentMain(MainWindow mainWindow,Page ParrentPage)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrentPage;
            ShowEquipment();
        }
        public void ShowEquipment()
        {
            EquipmentPanel.Children.Clear();
            foreach (Classes.Equipment curEquipment in mainWindow.EquipmentList)
            {
                Pages.Equipment.EquipmentElements.EquipmentElement newElement = new Pages.Equipment.EquipmentElements.EquipmentElement(curEquipment, mainWindow);
                newElement.MouseDown += delegate { ElementClick(curEquipment); };
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

        }
        public void ElementClick(Classes.Equipment curEquipment)
        {
            mainWindow.OpenPage(new Pages.Equipment.EquipmentEdit(mainWindow,this,curEquipment));
        }
    }
}
