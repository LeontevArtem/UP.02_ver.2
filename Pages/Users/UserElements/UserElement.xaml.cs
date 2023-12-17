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

namespace UP._02_ver._2.Pages.Users.UserElements
{
    /// <summary>
    /// Логика взаимодействия для UserElement.xaml
    /// </summary>
    public partial class UserElement : UserControl
    {
        public UserElement(MainWindow mainWindow,Page ParrentPage, Classes.Users curUser)
        {
            InitializeComponent();
            Name.Content = curUser.Name;
            Surname.Content = curUser.Surname;
            Patronymic.Content = curUser.Patronymic;
            Adress.Content = curUser.Address;
            Phone.Content = curUser.Phone;
            Mail.Content = curUser.Email;
        }
    }
}
