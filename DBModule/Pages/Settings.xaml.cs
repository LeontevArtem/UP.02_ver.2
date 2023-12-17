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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DBModule.Pages
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        Func<int, List<Exception>> LoadData;
        Func<Page, int> BackClick;
        Page ParrentPage;
        public Settings(Page parrentPage, Func<Page,int> BackClick, Func<int, List<Exception>> LoadData)
        {
            InitializeComponent();
            BackButton.MouseDown += delegate { BackClick(parrentPage); };
            CurStr.Content = $"Текущая строчка для входа: {Settings.ConnectionString}";
            Server.SetText(MainWindow.ServerStr);
            Name.SetText(MainWindow.UserStr);
            Password.SetText(MainWindow.PwdStr);
            DataBase.SetText(MainWindow.DatabaseStr);
            this.LoadData = LoadData;
            this.BackClick = BackClick;
            this.ParrentPage = parrentPage;
        }
        public static string ConnectionString = $"server = {MainWindow.ServerStr}; Trusted_Connection = No; DataBase = {MainWindow.DatabaseStr}; User = {MainWindow.UserStr}; PWD = {MainWindow.PwdStr}";
        public void Save(object sender, MouseButtonEventArgs e)
        {
            if (Server.GetText() != "") MainWindow.ServerStr = Server.GetText();
            if (Name.GetText() != "") MainWindow.UserStr = Name.GetText();
            if (Password.GetText() != "") MainWindow.PwdStr = Password.GetText();
            if (DataBase.GetText() != "") MainWindow.DatabaseStr = DataBase.GetText();
            ConnectionString = $"server = {MainWindow.ServerStr}; Trusted_Connection = No; DataBase = {MainWindow.DatabaseStr}; User = {MainWindow.UserStr}; PWD = {MainWindow.PwdStr}";
            if (UseName.state) ConnectionString = $"server = {MainWindow.ServerStr}; Trusted_Connection = Yes; DataBase = {MainWindow.DatabaseStr};";
            MessageBox.Show($"Данные сохранены. \nТекущая строка подключения: {ConnectionString}","Данные сохранены");
            LoadData(0);
            BackClick(ParrentPage);
        }
    }
    
}
