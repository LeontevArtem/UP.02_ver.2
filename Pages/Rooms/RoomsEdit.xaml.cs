using DBModule.Classes;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.EMMA;
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

namespace UP._02_ver._2.Pages.Rooms
{
    /// <summary>
    /// Логика взаимодействия для RoomsEdit.xaml
    /// </summary>
    public partial class RoomsEdit : Page
    {
        MainWindow mainWindow;
        Page ParrentPage;
        Classes.Rooms rooms;
        public RoomsEdit(MainWindow mainWindow, Page ParrenrPage)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
            LoadData();
        }
        public RoomsEdit(MainWindow mainWindow, Page ParrenrPage, Classes.Rooms rooms)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
            this.rooms = rooms;
            LoadData(rooms);
        }
        public void LoadData()
        {
            User.ItemsSource = mainWindow.UsersList;
            Temp_user.ItemsSource = mainWindow.UsersList;
        }
        public void LoadData(Classes.Rooms rooms)
        {
            LoadData();
            Name.SetText(rooms.Name);
            Short_name.SetText(rooms.Short_name.ToString());
            Temp_user.SelectedItem = rooms.Temp_user;
            User.SelectedItem = rooms.User;
            Delete.Visibility = Visibility.Visible;
        }
        public void BackClick(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(ParrentPage);
        }
        public void DeleteClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                System.Data.DataTable UserQuerry = MsSQL.Select($"DELETE FROM [dbo].[Rooms] WHERE RoomID = '{rooms.Room_id}'",
                           DBModule.Pages.Settings.ConnectionString);
                MessageBox.Show("Успешно");
                mainWindow.LoadData(0);
                mainWindow.OpenPage(ParrentPage);
                (ParrentPage as Pages.Rooms.RoomsMain).ShowEquipment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SaveClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (rooms == null)
                {
                    System.Data.DataTable UserQuerry = MsSQL.Select($"INSERT INTO [dbo].[Rooms]([Name],[Short_name],[Temp_user],[User]) VALUES ('" +
                        $"{Name.GetText()}','" +
                        $"{Short_name.GetText()}','" +
                        $"{(Temp_user.SelectedItem as Classes.Users).User_id}','" +
                        $"{(User.SelectedItem as Classes.Users).User_id}')",
                        DBModule.Pages.Settings.ConnectionString);
                }
                else
                {
                    System.Data.DataTable ProgramsQuerry = MsSQL.Select($"UPDATE [dbo].[Rooms] SET " +
                        $"[Name] = '{Name.GetText()}'," +
                        $"[Short_name] = '{Short_name.GetText()}'," +
                        $"[Temp_user] = '{(Temp_user.SelectedItem as Classes.Users).User_id}'," +
                        $"[User] = '{(User.SelectedItem as Classes.Users).User_id}' " +
                        $"WHERE RoomID = '{rooms.Room_id}'", DBModule.Pages.Settings.ConnectionString);
                }
                MessageBox.Show("Успешно");
                mainWindow.LoadData(0);
                mainWindow.OpenPage(ParrentPage);
                (ParrentPage as Pages.Rooms.RoomsMain).ShowEquipment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
