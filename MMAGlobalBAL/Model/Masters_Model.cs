using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalBAL.Model
{
   public class Masters_Model
    {   
        public List<maincategorymaster_Model> main_category_master { get; set; }
        public List<subcategorymaster_Model> sub_master { get; set; }
    }
}
