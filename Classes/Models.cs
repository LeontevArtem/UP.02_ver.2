using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP._02_ver._2.Classes
{
    public class Models
    {
        public int Model_id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public Models(int model_id, string name, int type)
        {
            this.Model_id = model_id;
            this.Name = name;
            this.Type = type;
        }
        //public static void Add(MainWindow mainWindow, string name, int type)
        //{

        //    try
        //    {
        //        MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
        //        mySqlConnection.Open();
        //        MySqlDataReader addCarQuery = Connection.Query($"INSERT INTO `УП.02`.`Models` (`Name`,`Type`) VALUES ('{name}','{type}');", mySqlConnection);
        //        mySqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Добавление"));
        //    }
        //}
        //public static void Edit(MainWindow mainWindow, int model_id, string name, int type)
        //{

        //    try
        //    {
        //        MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
        //        mySqlConnection.Open();
        //        MySqlDataReader addCarQuery = Connection.Query($"UPDATE `УП.02`.`Models` SET  `Name` = '{name}' , `Type` = '{type}' WHERE (`Model_id` = '{model_id}');", mySqlConnection);
        //        mySqlConnection.Close();
        //        mySqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Изменение"));
        //    }
        //}
        //public static void Delete(MainWindow mainWindow, int model_id)
        //{
        //    try
        //    {
        //        MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
        //        mySqlConnection.Open();
        //        MySqlDataReader addCarQuery = Connection.Query($"DELETE FROM `УП.02`.`Models` WHERE (`Model_id` = '{model_id}');", mySqlConnection);
        //        mySqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {

        //        // mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Удаление"));
        //    }
        //}
    }
}
