using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalBAL.Model
{
    public class shooting_schedule_model
    {
        public int slno { get; set; }
        public int project_name { get; set; }
        public int role_id { get; set; }
        public int main_category_id { get; set; }

        public int sub_category_id { get; set; }

        public int phone_number { get; set; }
        public DateTime date { get; set; }

        public int schedule_day { get; set; }
        public DateTime schedule_date { get; set; }
        public Boolean day_night { get; set; }

        public string interior_exterior { get; set; }

        public string scene { get; set; }

        public string characters { get; set; }

        public string status { get; set; }

        public DateTime created_date { get; set; }

        public Boolean flag { get; set; }

        public string rolename { get; set; }

        public string categoryname { get; set; }


    }
}

    