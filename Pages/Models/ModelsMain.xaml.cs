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

namespace UP._02_ver._2.Pages.Models
{
    /// <summary>
    /// Логика взаимодействия для ModelsMain.xaml
    /// </summary>
    public partial class ModelsMain : Page
    {
        MainWindow mainWindow;
        Page ParrentPage;
        public ModelsMain(MainWindow mainWindow, Page ParrentPage)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrentPage;
            ShowEquipment();
        }
        public void ShowEquipment()
        {
            EquipmentPanel.Children.Clear();
            foreach (Classes.Models model in mainWindow.ModelsList)
            {
                Pages.Models.ModelsElement.ModelsElements newModels = new Pages.Models.ModelsElement.ModelsElements(mainWindow, model);
                newModels.MouseDown += delegate { ElementClick(model); };
                EquipmentPanel.Children.Add(newModels);
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
            mainWindow.OpenPage(new Pages.Models.ModelsEdit(mainWindow, this));
        }
        public void ElementClick(Classes.Models model)
        {
            mainWindow.OpenPage(new Pages.Models.ModelsEdit(mainWindow, this, model));
        }
    }
}
