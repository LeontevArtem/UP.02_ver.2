using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace UP._02_ver._2.Pages.Users
{
    /// <summary>
    /// Логика взаимодействия для UserMain.xaml
    /// </summary>
    public partial class UserMain : Page
    {
        MainWindow mainWindow;
        Page ParrentPage;
        public UserMain(MainWindow mainWindow, Page parrentPage)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = parrentPage;
            ShowUsers();
            WpfControlLibrary2.Elements.Button1 SortByName = new WpfControlLibrary2.Elements.Button1() { XAMLText = "Сортировать по имени", XAMLTextColor = Color.FromRgb(255, 255, 255) };
            SortByName.MouseDown += delegate
            {
                mainWindow.UsersList = mainWindow.UsersList.OrderBy(x => x.Name).ToList();
                ShowUsers();
            };
            SidePanel.AddChildren(SortByName);
            WpfControlLibrary2.Elements.Button1 SortBySurname = new WpfControlLibrary2.Elements.Button1() { XAMLText = "Сортировать по фамилии", XAMLTextColor = Color.FromRgb(255, 255, 255) };
            SortBySurname.MouseDown += delegate
            {
                mainWindow.UsersList = mainWindow.UsersList.OrderBy(x => x.Surname).ToList();
                ShowUsers();
            };
            SidePanel.AddChildren(SortBySurname);
            WpfControlLibrary2.Elements.Button1 SortByPatronymic = new WpfControlLibrary2.Elements.Button1() { XAMLText = "Сортировать по отчеству", XAMLTextColor = Color.FromRgb(255, 255, 255) };
            SortByPatronymic.MouseDown += delegate
            {
                mainWindow.UsersList = mainWindow.UsersList.OrderBy(x => x.Patronymic).ToList();
                ShowUsers();
            };
            SidePanel.AddChildren(SortByPatronymic);
            WpfControlLibrary2.Elements.Button1 SortByAdress = new WpfControlLibrary2.Elements.Button1() { XAMLText = "Сортировать по адресу", XAMLTextColor = Color.FromRgb(255, 255, 255) };
            SortByAdress.MouseDown += delegate
            {
                mainWindow.UsersList = mainWindow.UsersList.OrderBy(x => x.Address).ToList();
                ShowUsers();
            };
            SidePanel.AddChildren(SortByAdress);
            WpfControlLibrary2.Elements.Button1 SortByPhone = new WpfControlLibrary2.Elements.Button1() { XAMLText = "Сортировать по телефону", XAMLTextColor = Color.FromRgb(255, 255, 255) };
            SortByPhone.MouseDown += delegate
            {
                mainWindow.UsersList = mainWindow.UsersList.OrderBy(x => x.Phone).ToList();
                ShowUsers();
            };
            SidePanel.AddChildren(SortByPhone);
            WpfControlLibrary2.Elements.Button1 SortByMail = new WpfControlLibrary2.Elements.Button1() { XAMLText = "Сортировать по почте", XAMLTextColor = Color.FromRgb(255, 255, 255) };
            SortByMail.MouseDown += delegate
            {
                mainWindow.UsersList = mainWindow.UsersList.OrderBy(x => x.Email).ToList();
                ShowUsers();
            };
            SidePanel.AddChildren(SortByMail);


        }
        public void ShowUsers()
        {
            UserPanel.Children.Clear();
            foreach (Classes.Users curUser in mainWindow.UsersList)
            {
                UserPanel.Children.Add(new Pages.Users.UserElements.UserElement(mainWindow, this, curUser));
            }
        }
        public void BackClick(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(ParrentPage);
        }
    }
}
