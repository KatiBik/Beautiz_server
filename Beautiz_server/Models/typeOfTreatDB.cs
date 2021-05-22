using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Beautiz_server.Models
{
    public class typeOfTreatDB
    {
        static string strCon = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;

        public static List<typeOfTreat> GetAlltypeOfTreat()
        {
            string strComm = "SELECT * FROM typeOfTreat";
            return ExcReader(strComm);
        }

        private static List<typeOfTreat> ExcReader(string comm2Run)
        {
            List<typeOfTreat> ul = new List<typeOfTreat>();
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand comm = new SqlCommand(comm2Run, con);
            comm.Connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                typeOfTreat s = new typeOfTreat(
                    (int)reader["typeId"],
                    (string)reader["name"],
                    (string)reader["photo"]);
                ul.Add(s);
            }
            comm.Connection.Close();
            return ul;
        }
    }
}