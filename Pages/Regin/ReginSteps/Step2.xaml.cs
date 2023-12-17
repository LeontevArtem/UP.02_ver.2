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
using WpfControlLibrary2.Elements;

namespace UP._02_ver._2.Pages.Regin.ReginSteps
{
    /// <summary>
    /// Логика взаимодействия для Step2.xaml
    /// </summary>
    public partial class Step2 : Page
    {
        Pages.Regin.ReginMain reginMain;
        public Step2(Pages.Regin.ReginMain reginMain)
        {
            InitializeComponent();
            this.reginMain = reginMain;
        }
        public async void NextStepClick(object sender, MouseButtonEventArgs e)
        {
            string Errors="";
            Task NameError = new Task(()=> Task.Delay(0));
            Task SurnameError = new Task(() => Task.Delay(0));
            Task PatronymicError = new Task(() => Task.Delay(0));

            if (Regex.IsMatch(NameBox.GetText().Trim(), @"^[А-Я][А-Яа-я]+$"))
            {
                reginMain.NewUser.Name = NameBox.GetText();
            }
            else 
            {
                Errors += "Неверный формат имени!\n";
                PatronymicError = NameBox.ShowError(5);
            }
            if (Regex.IsMatch(SurnameBox.GetText().Trim(), @"^[А-Я][А-Яа-я]+$"))
            {
                reginMain.NewUser.Surname = SurnameBox.GetText();
            }
            else
            {
                Errors += "Неверный формат фамилии!\n";
                SurnameError = SurnameBox.ShowError(5);
            }
            if (Regex.IsMatch(PatronymicBox.GetText().Trim(), @"^[А-Я][А-Яа-я]+$"))
            {
                reginMain.NewUser.Patronymic = PatronymicBox.GetText();
            }
            else
            {
                Errors += "Неверный формат отчества!\n";
                NameError = PatronymicBox.ShowError(5);
            }
            if (Errors != "")
            {
                Task Error = new Task(() => MessageBox.Show(Errors, "Ошибка регистрации", MessageBoxButton.OK, MessageBoxImage.Error));
                Error.Start();
                await Task.WhenAll(NameError, SurnameError, PatronymicError);                
            }
            else reginMain.ChangeStep(new Pages.Regin.ReginSteps.Step3(reginMain));

            //Task PasswordError = PasswordboxError();
            //await PasswordError;
        }
    }
}
