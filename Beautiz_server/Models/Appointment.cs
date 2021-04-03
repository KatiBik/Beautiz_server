using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beautiz_server.Models
{
    public class Appointment
    {
        public int appointmentID { get; set; }
        public DateTime appDate { get; set; }
        public string UserEmail { get; set; }
        public int BussID { get; set; }
        public int TreatID { get; set; }
     


        public Appointment()
        {

        }
        public Appointment(int id, DateTime date, string mail, int bid, int tid )
        {
            this.appointmentID = id;
            this.appDate = date;
            this.UserEmail = mail;
            this.BussID = bid;
            this.TreatID = tid;
        }
    }
}