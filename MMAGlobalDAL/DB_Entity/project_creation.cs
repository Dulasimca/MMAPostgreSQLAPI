using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalDAL.Database.DB_Entity
{

    [Table("projectcreation")]
    public class project_creation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int project_id { get; set; }
        public string project_name { get; set; }
        public int duration_in_days { get; set; }
        public int budget { get; set; }
        public DateTime project_start_date { get; set; }

        public string production_id { get; set; }
        public DateTime created_date { get; set; }
        public Boolean flag { get; set; }
    }
}
