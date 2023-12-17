using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP._02_ver._2.Classes
{
    public class Equipment
    {
        public int Equipment_id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Room { get; set; }
        public int User { get; set; }
        public int Temp_user { get; set; }
        public int Cost { get; set; }
        public int Direction { get; set; }
        public int Model { get; set; }
        public int Type { get; set; }
        public string Status { get; set; }
        public Equipment(int equipment_id,string name,string image,int room,int user,int temp_user,int cost,int direction, int model,int type, string status)
        {
            this.Equipment_id = equipment_id;
            this.Name = name;
            this.Image = image;
            this.Room = room;
            this.User = user;
            this.Temp_user = temp_user;
            this.Cost = cost;
            this.Direction = direction;
            this.Model = model;
            this.Type = type;
            this.Status = status;
        }
        public Equipment()
        {

        }
        //public static void Add(MainWindow mainWindow, string name, string image, int room, int user, int temp_user, int cost, int direction, int model)
        //{

        //    try
        //    {
        //        MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
        //        mySqlConnection.Open();
        //        MySqlDataReader addCarQuery = Connection.Query($"INSERT INTO `УП.02`.`Equipment` (`Name`,`Image`,`Room`,`User`,`Temp_user`,`Cost`,`Direction`,`Model`) VALUES ('{name}','{image}','{room}','{user}','{temp_user}','{cost}','{direction}','{model}');", mySqlConnection);
        //        mySqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Добавление"));
        //    }
        //}
        //public static void Edit(MainWindow mainWindow, int equipment_id, string name, string image, int room, int user, int temp_user, int cost, int direction, int model)
        //{

        //    try
        //    {
        //        MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
        //        mySqlConnection.Open();
        //        MySqlDataReader addCarQuery = Connection.Query($"UPDATE `УП.02`.`Equipment` SET  `Name` = '{name}',`Image` = '{image}', `Room` = '{room}' ,`User` = '{user}',`Temp_user` = '{temp_user}',`Cost` = '{cost}',`Direction`  '{direction}',`Model` = '{model}' WHERE (`Equipment_id` = '{equipment_id}');", mySqlConnection);
        //        mySqlConnection.Close();
        //        mySqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Изменение"));
        //    }
        //}
        //public static void Delete(MainWindow mainWindow, int equipment_id, string name, string image, int room, int user, int temp_user, int cost, int direction, int model)
        //{
        //    try
        //    {
        //        MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
        //        mySqlConnection.Open();
        //        MySqlDataReader addCarQuery = Connection.Query($"DELETE FROM `УП.02`.`Equipment` WHERE (`Equipment_id` = '{equipment_id}');", mySqlConnection);
        //        mySqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {

        //        // mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Удаление"));
        //    }
        //}
    }

}
