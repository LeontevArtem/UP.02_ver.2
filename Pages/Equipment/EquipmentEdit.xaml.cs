using DBModule.Classes;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        Classes.ValidationsField validationsField = new Classes.ValidationsField();
        public EquipmentEdit(MainWindow mainWindow, Page ParrenrPage)
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
                System.Data.DataTable UserQuerry = MsSQL.Select($"DELETE FROM [dbo].[Equipment] WHERE EquipmentID = '{curEquipment.Equipment_id}'",
                           DBModule.Pages.Settings.ConnectionString);
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
        public void SaveClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (validationsField.ValidationsOnlyText(Name.GetText()) && validationsField.ValidationsOnlyNumber(Cost.GetText())
                    && Room.SelectedItem != null && User.SelectedItem != null && TempUser.SelectedItem != null && Direction.SelectedItem != null
                    && Model.SelectedItem != null && Type.SelectedItem != null)
                {
                    if (curEquipment == null)
                    {
                        System.Data.DataTable UserQuerry = MsSQL.Select($"INSERT INTO [dbo].[Equipment]([Name],[Image],[Room],[User],[Temp_user],[Cost],[Direction],[Model],[Type]) VALUES ('" +
                            $"{Name.GetText()}','{Img.GetStringImage()}','" +
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
                            $"[Image] = '{Img.GetStringImage()}'," +
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
                else MessageBox.Show("Заполните все поля");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
