using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beautiz_server.Models
{
    public class typeOfTreat
    {
        public int typeId { get; set; }
        public string name { get; set; }
        public string photo { get; set; }


        public typeOfTreat()
        {

        }
        public typeOfTreat(int id, string name,string photo)
        {
            this.typeId = id;
            this.name = name;
            this.photo = photo;
        }
    }
}