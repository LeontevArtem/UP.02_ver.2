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

namespace UP._02_ver._2.Pages.Programs.ProgramsElements
{
    /// <summary>
    /// Логика взаимодействия для ProgramsElements.xaml
    /// </summary>
    public partial class ProgramsElements : UserControl
    {
        MainWindow mainWindow;
        Classes.Programs curPrograms;
        public ProgramsElements(MainWindow mainWindow, Classes.Programs curPrograms)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.curPrograms = curPrograms;
            Name.Content = curPrograms.Name;
            Version.Content = curPrograms.Version;
            Develop.Content = curPrograms.Developer.Name;
            //Image.Source = new BitmapImage(new Uri(curEquipment.Image));

        }
    }
}
