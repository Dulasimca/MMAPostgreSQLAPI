using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalBAL.Model
{
    public class fund_utilization_model
    {
        public int slno { get; set; }
        public int project_name { get; set; }
        public int budget_amount { get; set; }
        public int person_name { get; set; }
        public string payment_by { get; set; }
        public int amount { get; set; }
        public string day_or_call { get; set; }
        public string total_amount { get; set; }
        public DateTime created_date { get; set; }
        public string first_name { get; set; }
         
    }
}

   