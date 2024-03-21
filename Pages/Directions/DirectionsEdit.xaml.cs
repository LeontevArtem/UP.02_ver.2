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

namespace UP._02_ver._2.Pages.Directions
{
    /// <summary>
    /// Логика взаимодействия для DirectionsEdit.xaml
    /// </summary>
    public partial class DirectionsEdit : Page
    {
        MainWindow mainWindow;
        Page ParrentPage;
        Classes.Directions curDirections;
        public DirectionsEdit(MainWindow mainWindow, Page ParrenrPage)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
        
        }
        public DirectionsEdit(MainWindow mainWindow, Page ParrenrPage, Classes.Directions curDirections)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.ParrentPage = ParrenrPage;
            this.curDirections = curDirections;
            LoadData(curDirections);
        }
       
        public void LoadData(Classes.Directions curEquipment)
        {
            Name.SetText(curEquipment.Name);
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
                System.Data.DataTable UserQuerry = MsSQL.Select($"DELETE FROM [dbo].[Directions] WHERE DirectionID = '{curDirections.Direction_id}'",
                           DBModule.Pages.Settings.ConnectionString);
                MessageBox.Show("Успешно");
                mainWindow.LoadData(0);
                mainWindow.OpenPage(ParrentPage);
                (ParrentPage as Pages.Directions.DirectionsMain).ShowEquipment();
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
                if (curDirections == null)
                {
                    System.Data.DataTable UserQuerry = MsSQL.Select($"INSERT INTO [dbo].[Directions]([Name]) VALUES ('" +
                        $"{Name.GetText()}')",
                        DBModule.Pages.Settings.ConnectionString);
                }
                else
                {
                    System.Data.DataTable ProgramsQuerry = MsSQL.Select($"UPDATE [dbo].[Directions] SET " +
                        $"[Name] = '{Name.GetText()}' WHERE DirectionID = '{curDirections.Direction_id}'", DBModule.Pages.Settings.ConnectionString);
                }
                MessageBox.Show("Успешно");
                mainWindow.LoadData(0);
                mainWindow.OpenPage(ParrentPage);
                (ParrentPage as Pages.Directions.DirectionsMain).ShowEquipment();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
