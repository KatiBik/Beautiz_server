using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beautiz_server.Models
{
    public class Treatment
    {
        public int treatmentId { get; set; }
        public string Treatment_name { get; set; }
        public string Summary { get; set; }
        public int Treatment_duration { get; set; }
        public int Cost { get; set; }
        public int typeId { get; set; }
        public int Bussiness_Id { get; set; }


        public Treatment()
        {

        }
        public Treatment(int id, string tn,string sum,int td,int c,int tid,int bid)
        {
            this.treatmentId = id;
            this.Treatment_name = tn;
            this.Summary = sum;
            this.Treatment_duration = td;
            this.Cost = c;
            this.typeId = tid;
            this.Bussiness_Id = bid;
        }
    }
}