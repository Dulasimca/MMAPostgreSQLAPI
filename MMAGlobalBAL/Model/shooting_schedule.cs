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
        public int project_id { get; set; }

        public string scene { get; set; }
        public string interior_exterior { get; set; }
        public string day_night { get; set; }

        public int schedule_day { get; set; }

        public DateTime schedule_date { get; set; }
        public int status_id { get; set; }

        public int main_category_id { get; set; }

        public int sub_category_id { get; set; }

        public DateTime created_date { get; set; }

        public Boolean flag { get; set; }

        public string maincategoryname { get; set; }
        public string subcategoryname { get; set; }

        public string shooting_status { get; set; }

        public string project_name { get; set; }

    }
    public class shootingcharacterdetails_Model
    {
        public shooting_schedule_model shooting_Schedule { get; set; }
        public List<int> contactusid { get; set; }
    }
}

    