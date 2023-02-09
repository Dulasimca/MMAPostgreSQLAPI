using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalBAL.Model
{
    public class contacts_list_model
    {
        public int slno { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int roleid { get; set; }
        public int maincategory_id { get; set; }
        public int subcategory_id { get; set; }
        public DateTime dob { get; set; }
        public string phonenumber { get; set; }
        public string whatsappnumber { get; set; }
        public string email_id { get; set; }
        public int countrycode { get; set; }
        public int statecode { get; set; }
        public int citycode { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string pincode { get; set; }
        public Boolean isunion { get; set; }
        public int? unionid { get; set; }
        public Boolean flag { get; set; }
        public string countryname { get; set; }
        public string statename { get; set; }
        public string cityname { get; set; }
        public string rolename { get; set; }
        public string unionname { get; set; }
        public string maincategoryname { get; set; }
        public string subcategoryname { get; set; }


    }
}
