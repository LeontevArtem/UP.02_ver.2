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

namespace UP._02_ver._2.Pages.Developers.DevelopersElements
{
    /// <summary>
    /// Логика взаимодействия для DevelopersElements.xaml
    /// </summary>
    public partial class DevelopersElements : UserControl
    {
        MainWindow mainWindow;
        Classes.Developers curDevelopers;
        public DevelopersElements(Classes.Developers curDevelopers, MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.curDevelopers = curDevelopers;
            Name.Content = curDevelopers.Name;
            //Image.Source = new BitmapImage(new Uri(curEquipment.Image));

        }
    }
}
