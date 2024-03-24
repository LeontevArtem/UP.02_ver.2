using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP._02_ver._2.Classes
{
    public class Consumables
    {
        public int Consumable_id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Image { get; set; }
        public int Count { get; set; }
        public Users User { get; set; }
        public Users Temp_user { get; set; }
        public Equipment EquipmentID { get; set; }

        public Consumables(int consumable_id,string name, string description, string date, string image,int count,Users user, Users temp_user, Equipment EquipmentID)
        {
            this.Consumable_id = consumable_id;
            this.Name = name;
            this.Description = description;
            this.Date = date;
            this.Image = image;
            this.Count = count;
            this.User = user;
            this.Temp_user = temp_user;
            this.EquipmentID = EquipmentID;
        }
        //public static void Add(MainWindow mainWindow, string name, string description, DateTime date, string image, int count, int user, int temp_user, string material_type)
        //{

        //    try
        //    {
        //        MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
        //        mySqlConnection.Open();
        //        MySqlDataReader addCarQuery = Connection.Query($"INSERT INTO `УП.02`.`Consumables` (`Name`, `Description`, `Date`, `Image`, `Count`, `User`, `Temp_user`, `Material_type`) VALUES ('{name}', '{description}', '{date}', '{image}', '{count}', '{user}', '{temp_user}', '{material_type}');", mySqlConnection);
        //        mySqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Добавление"));
        //    }
        //}
        //public static void Edit(MainWindow mainWindow, int consumable_id, string name, string description, DateTime date, string image, int count, int user, int temp_user, string material_type)
        //{

        //    try
        //    {
        //        MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
        //        mySqlConnection.Open();
        //        MySqlDataReader addCarQuery = Connection.Query($"UPDATE `УП.02`.`Consumables` SET  `Name` = '{name}', `Description` = '{description}', `Date` = '{date}', `Image` = '{image}', `Count` = '{count}', `User` = '{user}', `Temp_user` = '{temp_user}', `Material_type` = '{material_type}' WHERE (`Consumable_id` = '{consumable_id}');", mySqlConnection);
        //        mySqlConnection.Close();
        //        mySqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Изменение"));
        //    }
        //}
        //public static void Delete(MainWindow mainWindow, int consumable_id)
        //{
        //    try
        //    {
        //        MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
        //        mySqlConnection.Open();
        //        MySqlDataReader addCarQuery = Connection.Query($"DELETE FROM `УП.02`.`Consumables` WHERE (`Consumable_id` = '{consumable_id}');", mySqlConnection);
        //        mySqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {

        //       // mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Удаление"));
        //    }
        //}
    }
}
