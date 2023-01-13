using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalBAL.Model
{
    public class registration_Model
    {
        public int slno { get; set; }
        public string production_house_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime dob { get; set; }
        public string mobile_number { get; set; }
        public string email_id { get; set; }
        public int country { get; set; }
        public int state { get; set; }
        public int city { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public int pincode { get; set; }
        public DateTime created_date { get; set; }
        public Boolean flag { get; set; }
        public string countryname { get; set; }
        public string statename { get; set; }
        public string cityname { get; set; }

    }
}
