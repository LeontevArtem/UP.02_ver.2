using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP._02_ver._2.Classes
{
    public class Inventory
    {
        public int Inventory_id { get; set; }
        public DateTime Date_start { get; set; }
        public DateTime Date_end { get; set; }
        public Inventory(int inventory_id, DateTime date_start, DateTime date_end )
        {
            this.Inventory_id = inventory_id;
            this.Date_start = date_start;
            this.Date_end = date_end;
        }
        //public static void Add(MainWindow mainWindow, DateTime date_start, DateTime date_end)
        //{

        //    try
        //    {
        //        MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
        //        mySqlConnection.Open();
        //        MySqlDataReader addCarQuery = Connection.Query($"INSERT INTO `УП.02`.`Inventory` (`Date_start`,`Date_end`) VALUES ('{date_start}','{date_end}');", mySqlConnection);
        //        mySqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Добавление"));
        //    }
        //}
        //public static void Edit(MainWindow mainWindow, int inventory_id, DateTime date_start, DateTime date_end)
        //{

        //    try
        //    {
        //        MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
        //        mySqlConnection.Open();
        //        MySqlDataReader addCarQuery = Connection.Query($"UPDATE `УП.02`.`Inventory` SET  `Date_start` = '{date_start}' , `Date_end` = '{date_end}' WHERE (`Inventory_id` = '{inventory_id}');", mySqlConnection);
        //        mySqlConnection.Close();
        //        mySqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Изменение"));
        //    }
        //}
        //public static void Delete(MainWindow mainWindow, int inventory_id)
        //{
        //    try
        //    {
        //        MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
        //        mySqlConnection.Open();
        //        MySqlDataReader addCarQuery = Connection.Query($"DELETE FROM `УП.02`.`Inventory` WHERE (`Inventory_id` = '{inventory_id}');", mySqlConnection);
        //        mySqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {

        //        // mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Удаление"));
        //    }
        //}
    }
}
