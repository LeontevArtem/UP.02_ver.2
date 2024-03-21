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

namespace UP._02_ver._2.Pages.Models
{
    /// <summary>
    /// Логика взаимодействия для ModelsEdit.xaml
    /// </summary>
    public partial class ModelsEdit : Page
    {
        MainWindow mainWindow;
        Page ParrentPage;
        Classes.Models curModels;
        public ModelsEdit(MainWindow mainWindow, Page ParrenrPage)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
            LoadData();
        }
        public ModelsEdit(MainWindow mainWindow, Page ParrenrPage, Classes.Models curModels)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
            this.curModels = curModels;
            LoadData(curModels);
        }
        public void LoadData()
        {
            Type.ItemsSource = mainWindow.EquipmentTypesList;
        }
        public void LoadData(Classes.Models curModels)
        {
            LoadData();
            Name.SetText(curModels.Name);
            Type.SelectedItem = mainWindow.EquipmentTypesList.Find(x=> x.Type_id == curModels.Type);
        }
        public void BackClick(object sender, MouseButtonEventArgs e)
        {
            mainWindow.OpenPage(ParrentPage);
        }
        public void SaveClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (curModels == null)
                {
                    System.Data.DataTable UserQuerry = MsSQL.Select($"INSERT INTO [dbo].[Models]([Name],[Type]) VALUES ('" +
                        $"{Name.GetText()}','{(Type.SelectedItem as Classes.Equipment_types).Type_id}')",
                        DBModule.Pages.Settings.ConnectionString);
                }
                else
                {
                    System.Data.DataTable ProgramsQuerry = MsSQL.Select($"UPDATE [dbo].[Models] SET " +
                        $"[Name] = '{Name.GetText()}'," +
                        $"[Type] = '{(Type.SelectedItem as Classes.Equipment_types).Type_id}'" +
                        $" WHERE ModelID = '{curModels.Model_id}'", DBModule.Pages.Settings.ConnectionString);
                }
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
    }
}
