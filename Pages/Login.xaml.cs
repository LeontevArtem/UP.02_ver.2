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

namespace UP._02_ver._2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        MainWindow mainWindow;
        public Login(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            LoginBox.PlaceHolder = "Login:";
            //if (mainWindow.UsersList.Count == 0) MessageBox.Show("Не удалось загрузить данные из БД", "Ошибка загрузки данных", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private async void LoginClick(object sender, MouseButtonEventArgs e)
        {
            Classes.Users CurrentUser = mainWindow.UsersList.Find(x => x.Login==LoginBox.GetText().Trim() && x.Password==PasswordBox.GetText().Trim());
            if (CurrentUser != null) MainWindow.CurrentUser = CurrentUser;
            else
            {
                Task Error = new Task(() => MessageBox.Show("Неверный логин или пароль!", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error));
                Error.Start();
                Task LoginError = LoginBox.ShowError(5);
                Task PasswordError = PasswordBox.ShowError(5);
                await LoginError;
                await PasswordError;
            } 
        }
        public void SettingsClick(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(new DBModule.Pages.Settings(this,mainWindow.OpenPage,mainWindow.LoadData));
        }
    }
}
