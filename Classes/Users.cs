using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP._02_ver._2.Classes
{
    public class Users
    {
        public int User_id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Users(int user_id, string login, string password, int role, string email, string name, string surname, string patronymic, string phone, string address)
        {
            this.User_id = user_id;
            this.Login = login;
            this.Password = password;
            this.Role = role;
            this.Email = email;
            this.Name = name;
            this.Surname = surname;
            this.Patronymic = patronymic;
            this.Phone = phone;
            this.Address = address;
        }
        public Users()
        {

        }
        //public static void Add(MainWindow mainWindow, string login, string password, int role, string email, string name, string surname, string patronumic, long phone, string address)
        //{

        //    try
        //    {
        //        MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
        //        mySqlConnection.Open();
        //        MySqlDataReader addCarQuery = Connection.Query($"INSERT INTO `УП.02`.`Users` (`Login`,`Password`,`Role`,`Email`,`Name`,`Surname`,`Patronumic`,`Phone`,`Address`) VALUES ('{login}','{password}','{role}','{email}','{name}','{surname}','{patronumic}','{phone}','{address}');", mySqlConnection);
        //        mySqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Добавление"));
        //    }
        //}
        //public static void Edit(MainWindow mainWindow, int user_id, string login, string password, int role, string email, string name, string surname, string patronumic, long phone, string address)
        //{

        //    try
        //    {
        //        MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
        //        mySqlConnection.Open();
        //        MySqlDataReader addCarQuery = Connection.Query($"UPDATE `УП.02`.`Users` SET  `Login` = '{login}',`Password` ='{password}',`Role` = '{role}',`Email` = '{email}',`Name` = '{name}',`Surname` = '{surname}',`Patronumic` = '{patronumic}',`Phone` = '{phone}',`Address` = '{address}' WHERE (`User_id` = '{user_id}');", mySqlConnection);
        //        mySqlConnection.Close();
        //        mySqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        //mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Изменение"));
        //    }
        //}
        //public static void Delete(MainWindow mainWindow, int user_id)
        //{
        //    try
        //    {
        //        MySqlConnection mySqlConnection = new MySqlConnection(MainWindow.GetConnectionString());
        //        mySqlConnection.Open();
        //        MySqlDataReader addCarQuery = Connection.Query($"DELETE FROM `УП.02`.`Users` WHERE (`User_id` = '{user_id}');", mySqlConnection);
        //        mySqlConnection.Close();
        //    }
        //    catch (Exception ex)
        //    {

        //        // mainWindow.Errors.Add(new Classes.ErrorMessage(DateTime.Now, ex, "Удаление"));
        //    }
        //}
    }
}
