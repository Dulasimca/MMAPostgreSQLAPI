using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalBAL.Model
{
   public class menu_master_model
    {
        public int menuid { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public int parentid { get; set; }
        public string icon { get; set; }
        public int roleid { get; set; }
        public Boolean isactive { get; set; }
        public string priorities { get; set; }
    }
}
