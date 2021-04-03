using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Beautiz_server.Models
{
    public class UsersDB
    {
        static string strCon = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;

        public static List<User> GetAllUsers()
        {
            string strComm = "SELECT * FROM Users";
            return ExcReader(strComm);
        }
        public static User GetUserByEmail(string email)
        {
            string strComm = $"SELECT * FROM Users " +
                             $" WHERE email='{email}'";
            List<User> lu = ExcReader(strComm);
            if (lu.Count == 1)
                return lu[0];
            return null;
        }
        public static User GetUserByEmailAndPassword(string email,string password)
        {
            string strComm = $"SELECT * FROM Users " +
                             $" WHERE email='{email}' And password='{password}'";
            List<User> lu = ExcReader(strComm);
            if (lu.Count == 1)
                return lu[0];
            return null;
        }
        

        public static int InsertUser(User user2Insert)
        {
            string strComm =
                $" INSERT INTO Users(email , full_name, password, phone, U_Address, points, credit_number, credit_validate, credit_cvv, latitude, longitude)" +
                $" VALUES('{user2Insert.email}', " +
                $" '{user2Insert.full_name}', " +
                $" '{user2Insert.password}', " +
                $" '{user2Insert.phone}', " +
                $" '{user2Insert.U_Address}', " +
                $" '{user2Insert.points}', " +
                $" '{user2Insert.credit_number}', " +
                $" '{user2Insert.credit_validate}', " +
                $" '{user2Insert.credit_cvv}', " +
                $" '{user2Insert.latitude}', " +
                $" '{user2Insert.longitude}'); ";

            return ExcReaderInsertUser(strComm);
        }
        private static int ExcReaderInsertUser(string comm2Run)
        {
            int userID = -1;

            try
            {
                SqlConnection con = new SqlConnection(strCon);
                SqlCommand comm = new SqlCommand(comm2Run, con);
                comm.Connection.Open();
                comm.ExecuteReader();
                comm.Connection.Close();
                return userID;
            }
            catch (Exception ex)
            {
                return 0;
            }


        }
        private static List<User> ExcReader(string comm2Run)
        {
            List<User> ul = new List<User>();
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand comm = new SqlCommand(comm2Run, con);
            comm.Connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                User s = new User(
                    (string)reader["email"],
                    (string)reader["full_name"],
                    (string)reader["password"],
                    (string)reader["phone"],
                    (string)reader["U_Address"],
                    (int)reader["points"],
                    (string)reader["credit_number"],
                    (string)reader["credit_validate"],
                    (string)reader["credit_cvv"],
                    (string)reader["latitude"],
                    (string)reader["longitude"]);
                ul.Add(s);
            }
            comm.Connection.Close();
            return ul;
        }
    }
}