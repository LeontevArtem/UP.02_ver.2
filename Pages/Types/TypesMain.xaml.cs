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

namespace UP._02_ver._2.Pages.Types
{
    /// <summary>
    /// Логика взаимодействия для TypesMain.xaml
    /// </summary>
    public partial class TypesMain : Page
    {
        MainWindow mainWindow;
        Page ParrentPage;
        public TypesMain(MainWindow mainWindow, Page ParrentPage)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrentPage;
            ShowEquipment();
        }
        public void ShowEquipment()
        {
            EquipmentPanel.Children.Clear();
            foreach (Classes.Equipment_types types in mainWindow.EquipmentTypesList)
            {
                Pages.Types.TypesElement.TypesElement newTypes = new Pages.Types.TypesElement.TypesElement(mainWindow, types);
                newTypes.MouseDown += delegate { ElementClick(types); };
                EquipmentPanel.Children.Add(newTypes);
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
            mainWindow.OpenPage(new Pages.Types.TypesEdit(mainWindow, this));
        }
        public void ElementClick(Classes.Equipment_types types)
        {
            mainWindow.OpenPage(new Pages.Types.TypesEdit(mainWindow, this, types));
        }
    }
}
