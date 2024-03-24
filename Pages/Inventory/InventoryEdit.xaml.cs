using DBModule.Classes;
using DocumentFormat.OpenXml.Wordprocessing;
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
using UP._02_ver._2.Classes;

namespace UP._02_ver._2.Pages.Inventory
{
    /// <summary>
    /// Логика взаимодействия для InventoryEdit.xaml
    /// </summary>
    public partial class InventoryEdit : Page
    {
        MainWindow mainWindow;
        Page ParrentPage;
        Classes.Inventory curInventory;
        Classes.ValidationsField validationsField = new Classes.ValidationsField();
        public InventoryEdit(MainWindow mainWindow, Page ParrenrPage)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
            LoadData();
        }
        public InventoryEdit(MainWindow mainWindow, Page ParrenrPage, Classes.Inventory curInventory)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
            this.curInventory = curInventory;
            LoadData(curInventory);
        }
        public void LoadData()
        {
            equipment.ItemsSource = mainWindow.EquipmentList;
        }
        public void LoadData(Classes.Inventory curInventory)
        {
            LoadData();
            Name.SetText(curInventory.Name);

            Delete.Visibility = Visibility.Visible;
        }
        public void AddClick(object sender, MouseButtonEventArgs e)
        {
            if(equipment.SelectedItem != null)
            {
                Classes.Equipment selectedEquipment = equipment.SelectedItem as Classes.Equipment;
                Equipment.EquipmentElements.EquipmentElement ItemShow = new Equipment.EquipmentElements.EquipmentElement(selectedEquipment, mainWindow);
                ItemShow.MouseDown += delegate { DeleteEquipmentClick(ItemShow); };
                parrent.Children.Add(ItemShow);
            }
        }
        public void DeleteEquipmentClick(Equipment.EquipmentElements.EquipmentElement equipmentElement)
        {
            if (MessageBox.Show("Вы действительно хотите удалить это оборудование?","Вопросик",MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {
                parrent.Children.Remove(equipmentElement);
            }
        }
        public void BackClick(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(ParrentPage);
        }
        public void DeleteClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                System.Data.DataTable UserQuerry = MsSQL.Select("",DBModule.Pages.Settings.ConnectionString);
                MessageBox.Show("Успешно");
                mainWindow.LoadData(0);
                mainWindow.OpenPage(ParrentPage);
                (ParrentPage as Pages.Models.ModelsMain).ShowEquipment();
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
                if (validationsField.ValidationsOnlyText(Name.GetText()) && equipment.SelectedItem != null
                    && validationsField.ValidationsDate(StartDate.SelectedDate.ToString()) && validationsField.ValidationsDate(EndDate.SelectedDate.ToString()))
                {
                    if (curInventory == null)
                    {
                        System.Data.DataTable db = MsSQL.Select($"INSERT INTO [dbo].[Inventorization]([DateStart],[DateEnd],[Name],[Comment],[UserID]) VALUES('{StartDate.SelectedDate}','{EndDate.SelectedDate}','{Name.GetText()}','{Comment.GetText()}','{MainWindow.CurrentUser.User_id}'); SELECT SCOPE_IDENTITY();",DBModule.Pages.Settings.ConnectionString);
                        int LastID = 0;
                        for (int i = 0; i < db.Rows.Count; i++)
                        {
                            LastID = Convert.ToInt32(db.Rows[i][0]);
                        }
                        foreach (Equipment.EquipmentElements.EquipmentElement equipmentElement in parrent.Children)
                        {
                            System.Data.DataTable InventorizationEquipment = MsSQL.Select($"INSERT INTO [dbo].[InventorizationEquipment]([InventorizationID],[EquipmentID]) VALUES('{LastID}','{equipmentElement.GetEquipment().Equipment_id}')", DBModule.Pages.Settings.ConnectionString);

                        }
                    }
                    else
                    {
                        System.Data.DataTable ProgramsQuerry = MsSQL.Select($"", DBModule.Pages.Settings.ConnectionString);
                    }
                    MessageBox.Show("Успешно");
                    mainWindow.LoadData(0);
                    mainWindow.OpenPage(ParrentPage);
                    //(ParrentPage as Pages.Models.ModelsMain).ShowEquipment();
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
