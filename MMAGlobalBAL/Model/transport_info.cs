using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalBAL.Model
{
    public class transport_info_Model
    {
        public int slno { get; set; }
        public string driver_name { get; set; }
        public DateTime pickup_time { get; set; }
        public string pickup_location { get; set; }
        public string drop_location { get; set; }
        public int passenger_id { get; set; }
        public int callinfoid { get; set; }
        public string passengername { get; set; }
    }
}
