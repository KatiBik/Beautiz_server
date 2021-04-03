using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Beautiz_server.Models
{
    public class BussinessDB
    {
        static string strCon = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;

        public static List<Bussiness> GetAllBussiness()
        {
            string strComm = "SELECT * FROM Bussiness";
            return ExcReader(strComm);
        }
        public static Bussiness GetBussinessByID(int id)
        {
            string strComm = $"SELECT * FROM Bussiness " +
                             $" WHERE Bussiness_Id={id}";
            List<Bussiness> lu = ExcReader(strComm);
            if (lu.Count == 1)
                return lu[0];
            return null;
        }

        public static int InsertBussiness(Bussiness bussiness2Insert)
        {
            string strComm =
                $" INSERT INTO Bussiness(Bussiness_name, summery, phone, media, b_address, points, photos, userEmail, credit_number, credit_validate, credit_cvv, latitude, longitude)" +
                $" VALUES('{bussiness2Insert.Bussiness_name}', " +
                $" '{bussiness2Insert.summery}', " +
                $" '{bussiness2Insert.phone}', " +
                $" '{bussiness2Insert.media}', " +
                $" '{bussiness2Insert.b_address}', " +
                $" '{bussiness2Insert.points}', " +
                $" '{bussiness2Insert.photos}', " +
                $" '{bussiness2Insert.userEmail}', " +
                $" '{bussiness2Insert.credit_number}', " +
                $" '{bussiness2Insert.credit_validate}', " +
                $" '{bussiness2Insert.credit_cvv}', " +
                $" '{bussiness2Insert.latitude}', " +
                $" '{bussiness2Insert.longitude}'); ";

            strComm +=
             " SELECT SCOPE_IDENTITY() as [SCOPE_IDENTITY] ; ";

            return ExcReaderInsertBussiness(strComm);
        }

        public static int UpdateBussiness(Bussiness s)
        {
            string strComm = $" UPDATE Bussiness SET " +
                             $" Bussiness_name='{s.Bussiness_name}' , " +
                             $" summery='{s.summery}' , " +
                             $" phone='{s.phone}' , " +
                             $" media='{s.media}' , " +
                             $" b_address='{s.b_address}' , " +
                             $" points='{s.points}' , " +
                             $" photos='{s.photos}' , " +
                             $" userEmail='{s.userEmail}' , " +
                             $" credit_number='{s.credit_number}' , " +
                             $" credit_validate='{s.credit_validate}' , " +
                             $" credit_cvv='{s.credit_cvv}' , " +
                             $" latitude='{s.latitude}' , " +
                             $" longitude='{s.longitude}' " +
                             $" WHERE Bussiness_Id= {s.Bussiness_Id}";

            return ExcNonQ(strComm);
        }

        private static int ExcNonQ(string comm2Run)
        {
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand comm = new SqlCommand(comm2Run, con);
            comm.Connection.Open();
            int res = comm.ExecuteNonQuery();
            comm.Connection.Close();
            return res;
        }

        private static int ExcReaderInsertBussiness(string comm2Run)
        {
            int bussinessID = -1;

            SqlConnection con = new SqlConnection(strCon);
            SqlCommand comm = new SqlCommand(comm2Run, con);
            comm.Connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                bussinessID = int.Parse(reader["SCOPE_IDENTITY"].ToString());
            }
            comm.Connection.Close();
            return bussinessID;
        }
        private static List<Bussiness> ExcReader(string comm2Run)
        {
            List<Bussiness> ul = new List<Bussiness>();
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand comm = new SqlCommand(comm2Run, con);
            comm.Connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Bussiness s = new Bussiness(
                    (int)reader["Bussiness_Id"],
                    (string)reader["Bussiness_name"],
                    (string)reader["summery"],
                    (string)reader["phone"],
                    (string)reader["media"],
                    (string)reader["b_address"],
                    (int)reader["points"],
                    (string)reader["photos"],
                    (string)reader["userEmail"],
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