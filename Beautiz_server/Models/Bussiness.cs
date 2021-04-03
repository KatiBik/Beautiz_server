using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beautiz_server.Models
{
    public class Bussiness
    {
        public int Bussiness_Id { get; set; }
        public string Bussiness_name { get; set; }
        public string summery { get; set; }
        public string phone { get; set; }
        public string media { get; set; }
        public string b_address { get; set; }
        public int points { get; set; }
        public string photos { get; set; }
        public string userEmail { get; set; }
        public string credit_number { get; set; }
        public string credit_validate { get; set; }
        public string credit_cvv { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }


        public Bussiness()
        {

        }
        public Bussiness(int id, string name, string sum, string pn, string med, string address, int poin, string ph, string mail, string cn, string cv, string cc, string la, string lo)
        {
            this.Bussiness_Id = id;
            this.Bussiness_name = name;
            this.summery = sum;
            this.phone = pn;
            this.media = med;
            this.b_address = address;
            this.points = poin;
            this.photos = ph;
            this.userEmail = mail;
            this.credit_number = cn;
            this.credit_validate = cv;
            this.credit_cvv = cc;
            this.latitude = la;
            this.longitude = lo;
        }
    }
}