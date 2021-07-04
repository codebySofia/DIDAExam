using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using DIDAWebApplication.Models;

namespace DIDAWebApplication.Services
{
    public class UserService
    {
        private SqlConnection connection;
        private void Connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["connectionString"].ToString();
            connection = new SqlConnection(constring);
        }

        //insert User
        public bool InsertUser(User user)
        {
            Connection();

            string sql = "INSERT User VALUES(" +
                        user.Citize + "," + user.NameSurname + "," + user.Telephone + "," + user.Source + "," + user.Destination
                        + ")";
            SqlCommand cmd = new SqlCommand(sql, connection);
            connection.Open();
            int result = cmd.ExecuteNonQuery();
            connection.Close();

            if (result >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // lists of user
        public List<User> GetLists()
        {
            Connection();

            string sql = "SELECT * FROM Users";
            SqlCommand cmd = new SqlCommand(sql, connection);
            connection.Open();
            List<User> users = new List<User>() { };
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int i = 0;
                while (reader.Read())
                {
                    users.Add((User)reader.GetValue(i));
                    i++;
                }
            }
            connection.Close();

            return users;
        }

        // get number 
        public int GetUserFromAboard()
        {
            Connection();

            string sql = "SELECT COUNT(*) as Sumary FROM Users WHERE Source NOT LIKE  ('%Thailand')";
            SqlCommand cmd = new SqlCommand(sql, connection);
            connection.Open();
            int users = (int)cmd.ExecuteScalar();
            connection.Close();

            return users;
        }

        // get number 
        public int GetUserFromProvince(string province)
        {
            Connection();

            string sql = "SELECT COUNT(*) as Sumary FROM Users WHERE Source LIKE  ('%" + province + "%')";
            SqlCommand cmd = new SqlCommand(sql, connection);
            connection.Open();
            int users = (int)cmd.ExecuteScalar();
            connection.Close();

            return users;
        }

    }
}
