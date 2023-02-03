using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalBAL.Model
{
    public class project_creation_model
    {
        public int project_id { get; set; }
        public string project_name { get; set; }
        public int duration_in_days { get; set; }

        public int budget { get; set; }

        public DateTime project_start_date { get; set; }

        public DateTime created_date { get; set; }

        public Boolean flag { get; set; }
    }
}

