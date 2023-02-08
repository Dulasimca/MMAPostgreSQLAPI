using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalBAL.Model
{
 public class shooting_status_model
    {
        public int slno { get; set; }
        public string status { get; set; }
        public Boolean flag { get; set; }
    }
}

    