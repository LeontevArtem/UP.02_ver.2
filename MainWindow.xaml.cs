using DBModule.Classes;
using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UP._02_ver._2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            LoginPage = new Pages.Login(this);
            
            
            List<Exception> ErrorsList = LoadData(0);
            if (ErrorsList.Count != 0) 
            {
                if(MessageBox.Show("Возникли ошибки при загрузке данных из БД. Посмотреть список?", "Ошибка загрузки данных из БД", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    string Errors="";
                    foreach(Exception ex in ErrorsList)
                    {
                        Errors += $"{ex.Message}\n";
                    }
                    MessageBox.Show(Errors);
                }
                else MessageBox.Show("Измените строку подключения или проверьте правильность данных в БД", "Предупреждение");
                (LoginPage as Pages.Login).LogIn.IsEnabled = false;
                (LoginPage as Pages.Login).LogIn.SetBackgroundColor(Color.FromRgb(220,220,220));
                (LoginPage as Pages.Login).RegIn.IsEnabled = false;
                (LoginPage as Pages.Login).RegIn.SetBackgroundColor(Color.FromRgb(220, 220, 220));
            }
            OpenPage(LoginPage);

        }
        Page LoginPage;
        public static Classes.Users CurrentUser;
        public List<Classes.Users> UsersList = new List<Classes.Users>();
        public List<Classes.Consumables> ConsumablesList = new List<Classes.Consumables>();
        public List<Classes.Developers> DevelopersList = new List<Classes.Developers>();
        public List<Classes.Directions> DirectionsList = new List<Classes.Directions>();
        public List<Classes.Equipment> EquipmentList = new List<Classes.Equipment>();
        public List<Classes.Equipment_types> EquipmentTypesList = new List<Classes.Equipment_types>();
        public List<Classes.Inventory> InventoryList = new List<Classes.Inventory>();
        public List<Classes.Models> ModelsList = new List<Classes.Models>();
        public List<Classes.Programs> ProgramsList = new List<Classes.Programs>();
        public List<Classes.Rooms> RoomsList = new List<Classes.Rooms>();
        public int OpenPage(Page ToPage)
        {
            DoubleAnimation opgrid = new DoubleAnimation();
            opgrid.From = 1;
            opgrid.To = 0;
            opgrid.Duration = TimeSpan.FromSeconds(0.1);
            opgrid.Completed += delegate
            {
                this.frame.Navigate(ToPage);
                DoubleAnimation opgrid2 = new DoubleAnimation();
                opgrid2.From = 0;
                opgrid2.To = 1;
                opgrid2.Duration = TimeSpan.FromSeconds(0.1);
                this.frame.BeginAnimation(Frame.OpacityProperty, opgrid2);
                

            };
            this.frame.BeginAnimation(Frame.OpacityProperty, opgrid);
            return 0;
        }
        
        public List<Exception> LoadData(int a)
        {
            (LoginPage as Pages.Login).LogIn.IsEnabled = true;
            (LoginPage as Pages.Login).LogIn.SetBackgroundColor(WpfControlLibrary2.Resources.BackgroundColor);
            (LoginPage as Pages.Login).RegIn.IsEnabled = true;
            (LoginPage as Pages.Login).RegIn.SetBackgroundColor(WpfControlLibrary2.Resources.BackgroundColor);

            ClearAllLists();
            List<Exception> ErrorsList = new List<Exception>();
            //Users
            try
            {
                System.Data.DataTable UserQuerry = MsSQL.Select("SELECT * FROM [Users]", DBModule.Pages.Settings.ConnectionString);
                for (int i = 0; i < UserQuerry.Rows.Count; i++)
                {
                    UsersList.Add(new Classes.Users(Convert.ToInt32(UserQuerry.Rows[i][0]), Convert.ToString(UserQuerry.Rows[i][1]), Convert.ToString(UserQuerry.Rows[i][2]), Convert.ToInt32(UserQuerry.Rows[i][3]), Convert.ToString(UserQuerry.Rows[i][4]), Convert.ToString(UserQuerry.Rows[i][5]), Convert.ToString(UserQuerry.Rows[i][6]), Convert.ToString(UserQuerry.Rows[i][7]), Convert.ToString(UserQuerry.Rows[i][8]), Convert.ToString(UserQuerry.Rows[i][9])));
                }
            }
            catch(Exception ex) { ErrorsList.Add(ex); }

            //Consumables
            try
            {
                System.Data.DataTable ConsumablesQuerry = MsSQL.Select("SELECT * FROM [Consumables]", DBModule.Pages.Settings.ConnectionString);
                for (int i = 0; i < ConsumablesQuerry.Rows.Count; i++)
                {
                    ConsumablesList.Add(new Classes.Consumables(Convert.ToInt32(ConsumablesQuerry.Rows[i][0]), Convert.ToString(ConsumablesQuerry.Rows[i][1]), Convert.ToString(ConsumablesQuerry.Rows[i][2]), Convert.ToString(ConsumablesQuerry.Rows[i][3]), Convert.ToString(ConsumablesQuerry.Rows[i][4]), Convert.ToInt32(ConsumablesQuerry.Rows[i][5]), Convert.ToInt32(ConsumablesQuerry.Rows[i][6]), Convert.ToInt32(ConsumablesQuerry.Rows[i][7]), Convert.ToString(ConsumablesQuerry.Rows[i][8])));
                }
            }
            catch (Exception ex) { ErrorsList.Add(ex); }

            //Equipment
            try
            {
                System.Data.DataTable EquipmentQuerry = MsSQL.Select("SELECT * FROM [Equipment]", DBModule.Pages.Settings.ConnectionString);
                for (int i = 0; i < EquipmentQuerry.Rows.Count; i++)
                {
                    EquipmentList.Add(new Classes.Equipment(Convert.ToInt32(EquipmentQuerry.Rows[i][0]), Convert.ToString(EquipmentQuerry.Rows[i][1]), Convert.ToString(EquipmentQuerry.Rows[i][2]), Convert.ToInt32(EquipmentQuerry.Rows[i][3]), Convert.ToInt32(EquipmentQuerry.Rows[i][4]), Convert.ToInt32(EquipmentQuerry.Rows[i][5]), Convert.ToInt32(EquipmentQuerry.Rows[i][6]), Convert.ToInt32(EquipmentQuerry.Rows[i][7]), Convert.ToInt32(EquipmentQuerry.Rows[i][8]), Convert.ToInt32(EquipmentQuerry.Rows[i][9]), Convert.ToString(EquipmentQuerry.Rows[i][10])));
                }
            }
            catch (Exception ex) { ErrorsList.Add(ex); }
            //Rooms
            try
            {
                System.Data.DataTable RoomsQuerry = MsSQL.Select("SELECT * FROM [Rooms]", DBModule.Pages.Settings.ConnectionString);
                for (int i = 0; i < RoomsQuerry.Rows.Count; i++)
                {
                    RoomsList.Add(new Classes.Rooms(Convert.ToInt32(RoomsQuerry.Rows[i][0]), Convert.ToString(RoomsQuerry.Rows[i][1]), Convert.ToString(RoomsQuerry.Rows[i][2]), Convert.ToInt32(RoomsQuerry.Rows[i][3]), Convert.ToInt32(RoomsQuerry.Rows[i][4])));
                }
            }
            catch (Exception ex) { ErrorsList.Add(ex); }
            //Models
            try
            {
                System.Data.DataTable ModelsQuerry = MsSQL.Select("SELECT * FROM [Models]", DBModule.Pages.Settings.ConnectionString);
                for (int i = 0; i < ModelsQuerry.Rows.Count; i++)
                {
                    ModelsList.Add(new Classes.Models(Convert.ToInt32(ModelsQuerry.Rows[i][0]), Convert.ToString(ModelsQuerry.Rows[i][1]), Convert.ToInt32(ModelsQuerry.Rows[i][2])));
                }
            }
            catch (Exception ex) { ErrorsList.Add(ex); }
            //Equipment_types
            try
            {
                System.Data.DataTable Equipment_typesQuerry = MsSQL.Select("SELECT * FROM [Equipment_types]", DBModule.Pages.Settings.ConnectionString);
                for (int i = 0; i < Equipment_typesQuerry.Rows.Count; i++)
                {
                    EquipmentTypesList.Add(new Classes.Equipment_types(Convert.ToInt32(Equipment_typesQuerry.Rows[i][0]), Convert.ToString(Equipment_typesQuerry.Rows[i][1])));
                }
            }
            catch (Exception ex) { ErrorsList.Add(ex); }
            //Directions
            try
            {
                System.Data.DataTable DirectionsQuerry = MsSQL.Select("SELECT * FROM [Directions]", DBModule.Pages.Settings.ConnectionString);
                for (int i = 0; i < DirectionsQuerry.Rows.Count; i++)
                {
                    DirectionsList.Add(new Classes.Directions(Convert.ToInt32(DirectionsQuerry.Rows[i][0]), Convert.ToString(DirectionsQuerry.Rows[i][1])));
                }
            }
            catch (Exception ex) { ErrorsList.Add(ex); }
            //Developers
            try
            {
                System.Data.DataTable DevelopersQuerry = MsSQL.Select("SELECT * FROM [Developers]", DBModule.Pages.Settings.ConnectionString);
                for (int i = 0; i < DevelopersQuerry.Rows.Count; i++)
                {
                    DevelopersList.Add(new Classes.Developers(Convert.ToInt32(DevelopersQuerry.Rows[i][0]), Convert.ToString(DevelopersQuerry.Rows[i][1])));
                }
            }
            catch (Exception ex) { ErrorsList.Add(ex); }
            //Inventory
            try
            {
                System.Data.DataTable InventoryQuerry = MsSQL.Select("SELECT * FROM [Inventory]", DBModule.Pages.Settings.ConnectionString);
                for (int i = 0; i < InventoryQuerry.Rows.Count; i++)
                {
                    InventoryList.Add(new Classes.Inventory(Convert.ToInt32(InventoryQuerry.Rows[i][0]), Convert.ToDateTime(InventoryQuerry.Rows[i][1]), Convert.ToDateTime(InventoryQuerry.Rows[i][2])));
                }
            }
            catch (Exception ex) { ErrorsList.Add(ex); }
            //Programs
            try
            {
                System.Data.DataTable ProgramsQuerry = MsSQL.Select("SELECT * FROM [Programs]", DBModule.Pages.Settings.ConnectionString);
                for (int i = 0; i < ProgramsQuerry.Rows.Count; i++)
                {
                    ProgramsList.Add(new Classes.Programs(Convert.ToInt32(ProgramsQuerry.Rows[i][0]), Convert.ToString(ProgramsQuerry.Rows[i][1]), Convert.ToInt32(ProgramsQuerry.Rows[i][2]), Convert.ToString(ProgramsQuerry.Rows[i][3])));
                }
            }
            catch (Exception ex) { ErrorsList.Add(ex); }
            return ErrorsList;
        }
        public void ClearAllLists()
        {
            UsersList.Clear();
            ConsumablesList.Clear();
            DirectionsList.Clear();
            DevelopersList.Clear();
            EquipmentList.Clear();
            EquipmentTypesList.Clear();
            InventoryList.Clear();
            ModelsList.Clear();
            ProgramsList.Clear();
            RoomsList.Clear();
        }
    }
}
