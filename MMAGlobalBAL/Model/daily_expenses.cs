using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalBAL.Model
{
    public class daily_expenses_Model
    {
        public int slno { get; set; }
        public int project_name { get; set; }
        public int budget_amount { get; set; }
        public DateTime date { get; set; }
        public string invoice_number { get; set; }
        public int expenses_category { get; set; }
        public int amount{ get; set; }
        public DateTime created_date { get; set; }
        public string name { get; set; }
    }
}
