using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Beautiz_server.Models
{
    public class AppointmentDB
    {
        static string strCon = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;

        public static List<Appointment> GetAllAppointment()
        {
            string strComm = "SELECT * FROM Appointment";
            return ExcReader(strComm);
        }
        public static List<Appointment> GetAppointmentByID(int id)
        {
            string strComm = $"SELECT * FROM Appointment " +
                             $" WHERE appointmentID={id}";
            List<Appointment> lu = ExcReader(strComm);
            if (lu.Count >= 1)
                return lu;
            return null;
        }

        public static int InsertAppointment(Appointment appointment2Insert)
        {
            string strComm =
                $" INSERT INTO Appointment(appDate , UserEmail, BussID, TreatID)" +
                $" VALUES('{appointment2Insert.appDate}', " +
                $" '{appointment2Insert.UserEmail}', " +
                $" '{appointment2Insert.BussID}', " +
                $" '{appointment2Insert.TreatID}'); ";

            strComm +=
               " SELECT SCOPE_IDENTITY() as [SCOPE_IDENTITY] ; ";

            return ExcReaderInsertAppointment(strComm);
        }
        private static int ExcReaderInsertAppointment(string comm2Run)
        {
            int appointmentID = -1;

            SqlConnection con = new SqlConnection(strCon);
            SqlCommand comm = new SqlCommand(comm2Run, con);
            comm.Connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                appointmentID = int.Parse(reader["SCOPE_IDENTITY"].ToString());
            }
            comm.Connection.Close();
            return appointmentID;
        }
        private static List<Appointment> ExcReader(string comm2Run)
        {
            List<Appointment> ul = new List<Appointment>();
            SqlConnection con = new SqlConnection(strCon);
            SqlCommand comm = new SqlCommand(comm2Run, con);
            comm.Connection.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Appointment s = new Appointment(
                    (int)reader["appointmentID"],
                    (DateTime)reader["appDate"],
                    (string)reader["UserEmail"],
                    (int)reader["BussID"],
                    (int)reader["TreatID"]);
                ul.Add(s);
            }
            comm.Connection.Close();
            return ul;
        }
    }
}