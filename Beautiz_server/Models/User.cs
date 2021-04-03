using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beautiz_server.Models
{
    public class User
    {
        public string email { get; set; }
        public string full_name { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string U_Address { get; set; }
        public int points { get; set; }
        public string credit_number { get; set; }
        public string credit_validate { get; set; }
        public string credit_cvv { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }


        public User()
        {

        }
        public User(string mail, string fn, string pass, string pn, string address, int poin, string cn, string cv, string cc, string la, string lo)
        {
            this.email = mail;
            this.full_name = fn;
            this.password = pass;
            this.phone = pn;
            this.U_Address = address;
            this.points = poin;
            this.credit_number = cn;
            this.credit_validate = cv;
            this.credit_cvv = cc;
            this.latitude = la;
            this.longitude = lo;
        }
    }
}