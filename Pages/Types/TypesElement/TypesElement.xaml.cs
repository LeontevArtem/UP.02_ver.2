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

namespace UP._02_ver._2.Pages.Types.TypesElement
{
    /// <summary>
    /// Логика взаимодействия для TypesElement.xaml
    /// </summary>
    public partial class TypesElement : UserControl
    {
        MainWindow mainWindow;
        Classes.Equipment_types types;
        public TypesElement(MainWindow mainWindow, Classes.Equipment_types types)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.types = types;
            Name.Content = types.Name;
        }
    }
}
