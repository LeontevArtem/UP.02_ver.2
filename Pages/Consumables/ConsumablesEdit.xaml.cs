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

namespace UP._02_ver._2.Pages.Consumables
{
    /// <summary>
    /// Логика взаимодействия для ConsumablesEdit.xaml
    /// </summary>
    public partial class ConsumablesEdit : Page
    {
        MainWindow mainWindow;
        Page ParrentPage;
        Classes.Consumables curConsumables;
        Classes.ValidationsField validationsField = new Classes.ValidationsField();
        public ConsumablesEdit(MainWindow mainWindow, Page ParrenrPage)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
            LoadData();
        }
        public ConsumablesEdit(MainWindow mainWindow, Page ParrenrPage, Classes.Consumables curConsumables)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
            this.curConsumables = curConsumables;
            LoadData(curConsumables);
        }
        public void LoadData()
        {
            User.ItemsSource = mainWindow.UsersList;
            TempUser.ItemsSource = mainWindow.UsersList;
            EquipmentID.ItemsSource = mainWindow.EquipmentList;
        }

        public void LoadData(Classes.Consumables curConsumables)
        {
            LoadData();
            Img.SetImage(curConsumables.Image);
            Name.SetText(curConsumables.Name);
            Description.SetText(curConsumables.Description);
            Date.SelectedDate=curConsumables.Date;
            count.SetText(curConsumables.Count.ToString());
            EquipmentID.SelectedItem = curConsumables.EquipmentID;
            User.SelectedItem = curConsumables.User;
            TempUser.SelectedItem = curConsumables.Temp_user;
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
                System.Data.DataTable UserQuerry = MsSQL.Select($"DELETE FROM [dbo].[Consumables] WHERE ConsumableID = '{curConsumables.Consumable_id}'",
                           DBModule.Pages.Settings.ConnectionString);
                MessageBox.Show("Успешно");
                mainWindow.LoadData(0);
                mainWindow.OpenPage(ParrentPage);
                (ParrentPage as Pages.Consumables.ConsumablesMain).ShowEquipment();
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
                if (validationsField.ValidationsOnlyText(Name.GetText()) && validationsField.ValidationsOnlyText(Description.GetText())
                    && validationsField.ValidationsDate(Date.SelectedDate.ToString()) && validationsField.ValidationsOnlyNumber(count.GetText())
                    && User.SelectedItem != null && TempUser.SelectedItem!=null)
                {
                    if (curConsumables == null)
                    {
                        System.Data.DataTable UserQuerry = MsSQL.Select($"INSERT INTO [dbo].[Consumables]([Name],[Description],[ReceiptDate],[Image]" +
                            $",[Quanity],[ResponsibleUser],[TempResponsibleUser],[EquipmentID]) VALUES ('" +
                            $"{Name.GetText()}','{Description.GetText()}','{Date.SelectedDate}','{Img.GetStringImage()}','{count.GetText()}'," +
                            $"'{(User.SelectedItem as Classes.Users).User_id}','{(TempUser.SelectedItem as Classes.Users).User_id}'," +
                            $"'{(EquipmentID.SelectedItem as Classes.Equipment).Equipment_id}')",
                            DBModule.Pages.Settings.ConnectionString);
                    }
                    else
                    {
                        System.Data.DataTable ProgramsQuerry = MsSQL.Select($"UPDATE [dbo].[Consumables] SET " +
                            $"[Name] = '{Name.GetText()}',[Description]='{Description.GetText()}',[ReceiptDate]='{Date.SelectedDate}',[Image]='{Img.GetStringImage()}'" +
                            $",[Quanity]='{count.GetText()}',[ResponsibleUser]='{(User.SelectedItem as Classes.Users).User_id}'" +
                            $",[TempResponsibleUser]='{(TempUser.SelectedItem as Classes.Users).User_id}'" +
                            $",[EquipmentID]='{(EquipmentID.SelectedItem as Classes.Equipment).Equipment_id}'WHERE ConsumableID = '{curConsumables.Consumable_id}'", DBModule.Pages.Settings.ConnectionString);
                    }
                    MessageBox.Show("Успешно");
                    mainWindow.LoadData(0);
                    mainWindow.OpenPage(ParrentPage);
                    (ParrentPage as Pages.Consumables.ConsumablesMain).ShowEquipment();
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
