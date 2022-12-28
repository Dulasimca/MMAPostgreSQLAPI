using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalBAL.Model
{
    public class trainingdb_Model
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public float salary { get; set; }
        public DateTime join_date { get; set; }
        public Boolean flag { get; set; }
    }
}
