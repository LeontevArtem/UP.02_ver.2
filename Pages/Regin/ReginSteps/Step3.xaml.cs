using DBModule.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для Step3.xaml
    /// </summary>
    public partial class Step3 : Page
    {
        Pages.Regin.ReginMain reginMain;
        public Step3(Pages.Regin.ReginMain reginMain)
        {
            InitializeComponent();
            this.reginMain = reginMain;
        }
        public async void NextStepClick(object sender, MouseButtonEventArgs e)
        {
            string Errors = "";
            Task AdressError = new Task(() => Task.Delay(0));
            Task PhoneError = new Task(() => Task.Delay(0));
            Task MailError = new Task(() => Task.Delay(0));

            if (Regex.IsMatch(AdressBox.GetText().Trim(), @"^г\.[^\s,]+,\s*ул\.[^\s,]+,\s*д\.\d+$"))
            {
                reginMain.NewUser.Address = AdressBox.GetText();
            }
            else
            {
                Errors += "Неверный формат адресса!\n";
                AdressError = AdressBox.ShowError(5);
            }
            if (Regex.IsMatch(PhoneBox.GetText().Trim(), @"^\+7\d{11}$")|| Regex.IsMatch(PhoneBox.GetText(), @"^8\d{10}$"))
            {
                reginMain.NewUser.Phone = PhoneBox.GetText();
            }
            else
            {
                Errors += "Неверный формат номера телефона!\n";
                PhoneError = PhoneBox.ShowError(5);
            }
            if (Regex.IsMatch(MailBox.GetText().Trim(), @"^[a-zA-Z0-9_.+-]+@[a-zA-Z]+\.[a-zA-Z]+$"))
            {
                reginMain.NewUser.Email = MailBox.GetText();
            }
            else
            {
                Errors += "Неверный формат электронной почты!\n";
                MailError = MailBox.ShowError(5);
            }
            if (Errors != "")
            {
                Task Error = new Task(() => MessageBox.Show(Errors, "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error));
                Error.Start();
                await Task.WhenAll(AdressError, PhoneError, MailError);
            }
            else
            {
                MsSQL.Select($"INSERT INTO [Users] (Login,Password,Role,Email,Name,Surname,Patronymic,Phone,Adress) VALUES ('" +
                    $"{reginMain.NewUser.Login}','" +
                    $"{reginMain.NewUser.Password}','" +
                    $"{0}','" +
                    $"{reginMain.NewUser.Email}','" +
                    $"{reginMain.NewUser.Name}','" +
                    $"{reginMain.NewUser.Surname}','" +
                    $"{reginMain.NewUser.Patronymic}','" +
                    $"{reginMain.NewUser.Phone}','" +
                    $"{reginMain.NewUser.Address}')", 
                    DBModule.Pages.Settings.ConnectionString);
                reginMain.mainWindow.LoadData(0);
                MessageBox.Show("Успешная регистрация","Успех");
                reginMain.mainWindow.OpenPage(new Pages.Login(reginMain.mainWindow));
            }

            //Task PasswordError = PasswordboxError();
            //await PasswordError;
        }
    }
}
