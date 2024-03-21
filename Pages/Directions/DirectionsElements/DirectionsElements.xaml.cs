using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.EMMA;
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

namespace UP._02_ver._2.Pages.Directions.DirectionsElements
{
    /// <summary>
    /// Логика взаимодействия для DirectionsElements.xaml
    /// </summary>
    public partial class DirectionsElements : UserControl
    {
        MainWindow mainWindow;
        Classes.Directions curDirections;
        public DirectionsElements(Classes.Directions curDirections, MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.curDirections = curDirections;
            Name.Content = curDirections.Name;
            //Image.Source = new BitmapImage(new Uri(curEquipment.Image));
          
        }
    }
}
