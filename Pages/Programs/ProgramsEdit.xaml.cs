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

namespace UP._02_ver._2.Pages.Programs
{
    /// <summary>
    /// Логика взаимодействия для ProgramsEdit.xaml
    /// </summary>
    public partial class ProgramsEdit : Page
    {
        MainWindow mainWindow;
        Page ParrentPage;
        Classes.Programs curPrograms;
        Classes.ValidationsField validationsField = new Classes.ValidationsField();
        public ProgramsEdit(MainWindow mainWindow, Page ParrenrPage)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
            LoadData();
        }
        public ProgramsEdit(MainWindow mainWindow, Page ParrenrPage, Classes.Programs curPrograms)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
            this.curPrograms = curPrograms;
            LoadData(curPrograms);
        }
        public void LoadData()
        {
            Developer.ItemsSource = mainWindow.DevelopersList;
        }
        public void LoadData(Classes.Programs curPrograms)
        {
            LoadData();
            Name.SetText(curPrograms.Name);
            Version.SetText(curPrograms.Version);
            Developer.SelectedItem = mainWindow.DevelopersList.Find(x => x.Developer_id == curPrograms.Developer.Developer_id);
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
                System.Data.DataTable UserQuerry = MsSQL.Select($"DELETE FROM [dbo].[Programs] WHERE ProgramID = '{curPrograms.Program_id}'",
                           DBModule.Pages.Settings.ConnectionString);
                MessageBox.Show("Успешно");
                mainWindow.LoadData(0);
                mainWindow.OpenPage(ParrentPage);
                (ParrentPage as Pages.Programs.ProgramsMain).ShowEquipment();
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
                if (validationsField.ValidationsOnlyText(Name.GetText()) && Developer.SelectedItem != null && validationsField.ValidationsVersion(Version.GetText()))
                {
                    if (curPrograms == null)
                    {
                        System.Data.DataTable UserQuerry = MsSQL.Select($"INSERT INTO [dbo].[Programs]([Name],[Developer],[Version]) VALUES ('" +
                            $"{Name.GetText()}','{(Developer.SelectedItem as Classes.Developers).Developer_id}','{Version.GetText()}')",
                            DBModule.Pages.Settings.ConnectionString);
                    }
                    else
                    {
                        System.Data.DataTable ProgramsQuerry = MsSQL.Select($"UPDATE [dbo].[Programs] SET " +
                            $"[Name] = '{Name.GetText()}'," +
                            $"[Developer] = '{(Developer.SelectedItem as Classes.Developers).Developer_id}'," +
                            $"[Version]='{Version.GetText()}'"+
                            $" WHERE ProgramID = '{curPrograms.Program_id}'", DBModule.Pages.Settings.ConnectionString);
                    }
                    MessageBox.Show("Успешно");
                    mainWindow.LoadData(0);
                    mainWindow.OpenPage(ParrentPage);
                    (ParrentPage as Pages.Programs.ProgramsMain).ShowEquipment();
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
