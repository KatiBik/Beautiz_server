using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Beautiz_server.Models
{
    public class TreatmentDB
    {
        static string strCon = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;


        public static List<Treatment> GetAllTreatment()
        {
            string strComm = "SELECT * FROM Treatment";
            return ExcReader(strComm);
        }
        public static List<Treatment> GetTreatmentByID(int id)
        {
            string strComm = $"SELECT * FROM Treatment " +
                             $" WHERE typeId={id}";
            List<Treatment> lu = ExcReader(strComm);
            if (lu.Count >= 1)
                return lu;
            return null;
        }

        public static int InsertTreatment(Treatment treatment2Insert)
        {
            string strComm =
                $" INSERT INTO Treatment(Treatment_name , Summary, Treatment_duration, Cost, typeId, Bussiness_Id)" +
                $" VALUES('{treatment2Insert.Treatment_name}', " +
                $" '{treatment2Insert.Summary}', " +
                $" '{treatment2Insert.Treatment_duration}', " +
                $" '{treatment2Insert.Cost}', " +
                $" '{treatment2Insert.typeId}', " +
                $" '{treatment2Insert.Bussiness_Id}'); ";

            strComm +=
               " SELECT SCOPE_IDENTITY() as [SCOPE_IDENTITY] ; ";

            return ExcReaderInsertTreatment(strComm);
        }
        private static int ExcReaderInsertTreatment(string comm2Run)
        {
            int treatmentID = -1;

            SqlConnection con = new SqlConnection(strCon);
            SqlCommand comm = new SqlCommand(comm2Run, con);
            comm.Connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                treatmentID = int.Parse(reader["SCOPE_IDENTITY"].ToString());
            }
            comm.Connection.Close();
            return treatmentID;
        }
        private static List<Treatment> ExcReader(string comm2Run)
        {
            List<Treatment> ul = new List<Treatment>();
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand comm = new SqlCommand(comm2Run, con);
            comm.Connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Treatment s = new Treatment(
                    (int)reader["treatmentId"],
                    (string)reader["Treatment_name"],
                    (string)reader["Summary"],
                    (int)reader["Treatment_duration"],
                    (int)reader["Cost"],
                    (int)reader["typeId"],
                    (int)reader["Bussiness_Id"]);
                ul.Add(s);
            }
            comm.Connection.Close();
            return ul;
        }
    }
}