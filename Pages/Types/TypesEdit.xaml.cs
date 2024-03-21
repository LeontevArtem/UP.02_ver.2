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

namespace UP._02_ver._2.Pages.Types
{
    /// <summary>
    /// Логика взаимодействия для TypesEdit.xaml
    /// </summary>
    public partial class TypesEdit : Page
    {
        MainWindow mainWindow;
        Page ParrentPage;
        Classes.Equipment_types types;
        public TypesEdit(MainWindow mainWindow, Page ParrenrPage)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
        }
        public TypesEdit(MainWindow mainWindow, Page ParrenrPage, Classes.Equipment_types types)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
            this.types = types;
            LoadData(types);
        }
        public void LoadData(Classes.Equipment_types types)
        {
            Name.SetText(types.Name);
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
                System.Data.DataTable UserQuerry = MsSQL.Select($"DELETE FROM [dbo].[Equipment_types] WHERE TypeID = '{types.Type_id}'",
                           DBModule.Pages.Settings.ConnectionString);
                MessageBox.Show("Успешно");
                mainWindow.LoadData(0);
                mainWindow.OpenPage(ParrentPage);
                (ParrentPage as Pages.Types.TypesMain).ShowEquipment();
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
                if (types == null)
                {
                    System.Data.DataTable UserQuerry = MsSQL.Select($"INSERT INTO [dbo].[Equipment_types]([Name]) VALUES ('" +
                        $"{Name.GetText()}')",
                        DBModule.Pages.Settings.ConnectionString);
                }
                else
                {
                    System.Data.DataTable ProgramsQuerry = MsSQL.Select($"UPDATE [dbo].[Equipment_types] SET " +
                        $"[Name] = '{Name.GetText()}' WHERE TypeID = '{types.Type_id}'", DBModule.Pages.Settings.ConnectionString);
                }
                MessageBox.Show("Успешно");
                mainWindow.LoadData(0);
                mainWindow.OpenPage(ParrentPage);
                (ParrentPage as Pages.Types.TypesMain).ShowEquipment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
