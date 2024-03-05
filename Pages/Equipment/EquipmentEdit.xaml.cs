using DBModule.Classes;
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

namespace UP._02_ver._2.Pages.Equipment
{
    /// <summary>
    /// Логика взаимодействия для EquipmentEdit.xaml
    /// </summary>
    public partial class EquipmentEdit : Page
    {
        MainWindow mainWindow;
        Page ParrentPage;
        Classes.Equipment curEquipment;
        public EquipmentEdit(MainWindow mainWindow,Page ParrenrPage)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
            LoadData();
        }
        public EquipmentEdit(MainWindow mainWindow, Page ParrenrPage, Classes.Equipment curEquipment)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
            this.curEquipment = curEquipment;
            LoadData(curEquipment);
        }
        public void LoadData()
        {
            User.ItemsSource = mainWindow.UsersList;
            TempUser.ItemsSource = mainWindow.UsersList;
            Direction.ItemsSource = mainWindow.DirectionsList;
            Model.ItemsSource = mainWindow.ModelsList;
            Type.ItemsSource = mainWindow.EquipmentTypesList;
            Room.ItemsSource = mainWindow.RoomsList;

        }
        public void LoadData(Classes.Equipment curEquipment)
        {
            LoadData();
            Name.SetText(curEquipment.Name);
            Cost.SetText(curEquipment.Cost.ToString());
            Comment.SetText(curEquipment.Comment);
            User.SelectedItem = curEquipment.User;
            TempUser.SelectedItem = curEquipment.Temp_user;
            Model.SelectedItem = curEquipment.Model;
            Type.SelectedItem = curEquipment.Type;
            Direction.SelectedItem = curEquipment.Direction;
            Room.SelectedItem = curEquipment.Room;
        }
        public void BackClick(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(ParrentPage);
        }
        public void SaveClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (curEquipment == null)
                {
                    System.Data.DataTable UserQuerry = MsSQL.Select($"INSERT INTO [dbo].[Equipment]([Name],[Image],[Room],[User],[Temp_user],[Cost],[Direction],[Model],[Type]) VALUES ('" +
                        $"{Name.GetText()}','{0}','" +
                        $"{(Room.SelectedItem as Classes.Rooms).Room_id}','" +
                        $"{(User.SelectedItem as Classes.Users).User_id}','" +
                        $"{(TempUser.SelectedItem as Classes.Users).User_id}','" +
                        $"{Cost.GetText()}','" +
                        $"{(Direction.SelectedItem as Classes.Directions).Direction_id}','" +
                        $"{(Model.SelectedItem as Classes.Models).Model_id}','" +
                        $"{(Type.SelectedItem as Classes.Equipment_types).Type_id}')", 
                        DBModule.Pages.Settings.ConnectionString);
                }
                else
                {
                    System.Data.DataTable ProgramsQuerry = MsSQL.Select($"UPDATE [dbo].[Equipment] SET " +
                        $"[Name] = '{Name.GetText()}'," +
                        $"[Image] = '{0}'," +
                        $"[Room] = '{(Room.SelectedItem as Classes.Rooms).Room_id}'," +
                        $"[User] = '{(User.SelectedItem as Classes.Users).User_id}'," +
                        $"[Temp_user] = '{(TempUser.SelectedItem as Classes.Users).User_id}'," +
                        $"[Cost] = '{Cost.GetText()}'," +
                        $"[Direction] = '{(Direction.SelectedItem as Classes.Directions).Direction_id}'," +
                        $"[Model] = '{(Model.SelectedItem as Classes.Models).Model_id}'," +
                        $"[Type] = '{(Type.SelectedItem as Classes.Equipment_types).Type_id}' " +
                        $"WHERE EquipmentID = '{curEquipment.Equipment_id}'", DBModule.Pages.Settings.ConnectionString);
                }
                MessageBox.Show("Успешно");
                mainWindow.LoadData(0);
                mainWindow.OpenPage(ParrentPage);
                (ParrentPage as Pages.Equipment.EquipmentMain).ShowEquipment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

    }
}
