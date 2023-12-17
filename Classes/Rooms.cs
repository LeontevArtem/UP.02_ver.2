using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP._02_ver._2.Classes
{
    public class Rooms
    {
        public int Room_id { get; set; }
        public string Name { get; set; }
        public string Short_name { get; set; }
        public int Temp_user { get; set; }
        public int User { get; set; }
        public Rooms(int room_id, string name, string short_name, int temp_user,int user)
        {
            this.Room_id = room_id;
            this.Name = name;
            this.Short_name = short_name;
            this.Temp_user = temp_user;
            this.User = user;
        }
        public Rooms()
        {

        }
        //public static void Add(MainWindow mainWindow, string name, string short_name, int temp_user)
        //{

        //    try
        //    {
        //        MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
        //        mySqlConnection.Open();
        //        MySqlDataReader addCarQuery = Connection.Query($"INSERT INTO `УП.02`.`Rooms` (`Name`,`Short_name`,`Temp_user`) VALUES ('{name}','{short_name}','{temp_user}');", mySqlConnection);
        //        mySqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Добавление"));
        //    }
        //}
        //public static void Edit(MainWindow mainWindow, int room_id, string name, string short_name, int temp_user)
        //{

        //    try
        //    {
        //        MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
        //        mySqlConnection.Open();
        //        MySqlDataReader addCarQuery = Connection.Query($"UPDATE `УП.02`.`Rooms` SET  `Name` = '{name}' , `Short_name` = '{short_name}',`Temp_user` = '{temp_user}' WHERE (`Room_id` = '{room_id}');", mySqlConnection);
        //        mySqlConnection.Close();
        //        mySqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Изменение"));
        //    }
        //}
        //public static void Delete(MainWindow mainWindow, int room_id)
        //{
        //    try
        //    {
        //        MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
        //        mySqlConnection.Open();
        //        MySqlDataReader addCarQuery = Connection.Query($"DELETE FROM `УП.02`.`Rooms` WHERE (`Room_id` = '{room_id}');", mySqlConnection);
        //        mySqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {

        //        // mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Удаление"));
        //    }
        //}
    }
}
