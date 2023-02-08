using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalBAL.Model
{
    public class call_info_Model
    {
        public int slno { get; set; } 
        public int project_name { get; set; }
        public int role_id { get; set; }
        public int main_category_id { get; set; }
        public int sub_category_id { get; set; }
        public DateTime date { get; set; }
        public DateTime general_call_time { get; set; }
        public DateTime shooting_call_time { get; set; }
        public int location_id { get; set; }
        public string phone_number { get; set; }
        public DateTime created_date { get; set; }
        public Boolean flag { get; set; }
        public string projectname { get; set; }
        public string rolename { get; set; }
        public string categoryname { get; set; }
    }

    public class callinfodetails_Model
    {
        public call_info_Model callinfo { get; set; }
        public lodging_info_Model lodging { get; set; }
        public transport_info_Model transport { get; set; }

        public List<int> contactusid { get; set; }

    }

}
