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
            ListEquipment.Items.Add(equipment.SelectedItem);
            
        }
        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListEquipment.SelectedItems.Count > 0)
            {
                ListEquipment.Items.Remove(ListEquipment.SelectedItem);
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
                System.Data.DataTable UserQuerry = MsSQL.Select($"DELETE FROM [dbo].[Models] WHERE ModelID = '{curInventory.Inventory_id}'",
                           DBModule.Pages.Settings.ConnectionString);
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
                    && validationsField.ValidationsDate(StartDate.GetText()) && validationsField.ValidationsDate(EndDate.GetText()))
                {
                    if (curInventory == null)
                    {
                        System.Data.DataTable UserQuerry = MsSQL.Select($"INSERT INTO [dbo].[Models]([Name],[Type]) VALUES ('" +
                            $"{Name.GetText()}','{(equipment.SelectedItem as Classes.Equipment_types).Type_id}')",
                            DBModule.Pages.Settings.ConnectionString);
                    }
                    else
                    {
                        System.Data.DataTable ProgramsQuerry = MsSQL.Select($"UPDATE [dbo].[Models] SET " +
                            $"[Name] = '{Name.GetText()}'," +
                            $"[Type] = '{(equipment.SelectedItem as Classes.Equipment_types).Type_id}'" +
                            $" WHERE ModelID = '{curInventory.Inventory_id}'", DBModule.Pages.Settings.ConnectionString);
                    }
                    MessageBox.Show("Успешно");
                    mainWindow.LoadData(0);
                    mainWindow.OpenPage(ParrentPage);
                    (ParrentPage as Pages.Models.ModelsMain).ShowEquipment();
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
