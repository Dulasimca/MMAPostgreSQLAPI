using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalBAL.Model
{
    public class location_info_model
    {
        public int slno { get; set; }
        public string location_name { get; set; }
        public int location_managerid { get; set; }
        public int local_epid { get; set; }
        public int country_id { get; set; }
        public int state_id { get; set; }
        public int city_id { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string phonenumber { get; set; }
        public Boolean parking_facility { get; set; }
        public string parking_note { get; set; }
        public DateTime created_date { get; set; }
        public int pincode { get; set; }
        public Boolean flag { get; set; }
        public string countryname { get; set; }
        public string statename { get; set; }
        public string cityname { get; set; }

        public string first_name { get; set; }

    }
}