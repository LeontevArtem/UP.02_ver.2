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

namespace UP._02_ver._2.Pages.Models.ModelsElement
{
    /// <summary>
    /// Логика взаимодействия для ModelsElements.xaml
    /// </summary>
    public partial class ModelsElements : UserControl
    { 
        MainWindow mainWindow;
        Classes.Models curModels;
        public ModelsElements(MainWindow mainWindow, Classes.Models curModels)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.curModels = curModels;
            Name.Content = curModels.Name;
            Type.Content = curModels.Type;
            //Image.Source = new BitmapImage(new Uri(curEquipment.Image));
          
        }
    }
}
