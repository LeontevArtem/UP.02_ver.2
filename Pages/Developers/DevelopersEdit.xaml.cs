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

namespace UP._02_ver._2.Pages.Developers
{
    /// <summary>
    /// Логика взаимодействия для DevelopersEdit.xaml
    /// </summary>
    public partial class DevelopersEdit : Page
    {
        MainWindow mainWindow;
        Page ParrentPage;
        Classes.Developers curDevelopers;
        Classes.ValidationsField validationsField = new Classes.ValidationsField();
        public DevelopersEdit(MainWindow mainWindow, Page ParrenrPage)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;

        }
        public DevelopersEdit(MainWindow mainWindow, Page ParrenrPage, Classes.Developers curDevelopers)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
            this.curDevelopers = curDevelopers;
            LoadData(curDevelopers);
        }

        public void LoadData(Classes.Developers curDevelopers)
        {
            Name.SetText(curDevelopers.Name);
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
                System.Data.DataTable UserQuerry = MsSQL.Select($"DELETE FROM [dbo].[Developers] WHERE DeveloperID = '{curDevelopers.Developer_id}'",
                           DBModule.Pages.Settings.ConnectionString);
                MessageBox.Show("Успешно");
                mainWindow.LoadData(0);
                mainWindow.OpenPage(ParrentPage);
                (ParrentPage as Pages.Developers.DevelopersMain).ShowEquipment();
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
                if (validationsField.ValidationsOnlyText(Name.GetText()))
                {
                    if (curDevelopers == null)
                    {
                        System.Data.DataTable UserQuerry = MsSQL.Select($"INSERT INTO [dbo].[Developers]([Name]) VALUES ('" +
                            $"{Name.GetText()}')",
                            DBModule.Pages.Settings.ConnectionString);
                    }
                    else
                    {
                        System.Data.DataTable ProgramsQuerry = MsSQL.Select($"UPDATE [dbo].[Developers] SET " +
                            $"[Name] = '{Name.GetText()}' WHERE DeveloperID = '{curDevelopers.Developer_id}'", DBModule.Pages.Settings.ConnectionString);
                    }
                    MessageBox.Show("Успешно");
                    mainWindow.LoadData(0);
                    mainWindow.OpenPage(ParrentPage);
                    (ParrentPage as Pages.Developers.DevelopersMain).ShowEquipment();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
