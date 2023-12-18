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

namespace Reports.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
            
        }

        //private void TabCtrl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    TabItem activeTabItem = TabCtrl.SelectedItem as TabItem;

        //    if (activeTabItem.IsSelected) activeTabItem.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        //    else activeTabItem.Foreground = new SolidColorBrush(Color.FromRgb(1, 1, 1));
        //}
    }
}
