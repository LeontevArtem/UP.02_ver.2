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

namespace UP._02_ver._2.Pages.Regin
{
    /// <summary>
    /// Логика взаимодействия для ReginMain.xaml
    /// </summary>
    public partial class ReginMain : Page
    {
        public MainWindow mainWindow;
        public ReginMain(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            ChangeStep(new Pages.Regin.ReginSteps.Step1(this));
        }
        public void ChangeStep(Page Step)
        {
            RegFrame.Navigate(Step);
        }
        public Classes.Users NewUser = new Classes.Users();
    }
}
