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

namespace UP._02_ver._2.Pages.Regin.ReginSteps
{
    /// <summary>
    /// Логика взаимодействия для Step1.xaml
    /// </summary>
    public partial class Step1 : Page
    {
        Pages.Regin.ReginMain reginMain;
        public Step1(Pages.Regin.ReginMain reginMain)
        {
            InitializeComponent();
            this.reginMain = reginMain;
        }
        public async void NextStepClick(object sender, MouseButtonEventArgs e)
        {
            string Errors = "";
            Task LoginError = new Task(() => Task.Delay(0));
            Task PasswordError = new Task(() => Task.Delay(0));
            bool flag = true; 
            if (reginMain.mainWindow.UsersList.FindAll(x => x.Login == LoginBox.GetText().Trim()).Count ==0) reginMain.NewUser.Login = LoginBox.GetText();
            else
            {
                LoginError = LoginBox.ShowError(5);
                Errors += "Пользователь с таким логином уже существует!\n";
                flag = false;
            }
            if (PasswordBox1.GetText() == PasswordBox2.GetText()) reginMain.NewUser.Password = PasswordBox1.GetText();
            else
            {
                Errors += "Введеные пароли должны совпадать!\n";
                PasswordError = PasswordboxError();
                flag = false;
            }
            if (!flag)
            {
                Task Error = new Task(() => MessageBox.Show(Errors, "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error));
                Error.Start();
                await Task.WhenAll(LoginError, PasswordError);
            }
            else reginMain.ChangeStep(new Pages.Regin.ReginSteps.Step2(reginMain));

        }
        private async Task PasswordboxError()
        {
            Task Error1 = PasswordBox1.ShowError(5);
            Task Error2 = PasswordBox2.ShowError(5);
            await Error1;
            await Error2;
        }
    }
}
