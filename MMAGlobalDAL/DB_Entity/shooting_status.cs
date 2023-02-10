using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalDAL.Database.DB_Entity
{
    [Table("shooting_status")]
    public class shooting_status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int slno { get; set; }
        public string status { get; set; }
        public Boolean flag { get; set; }
    }
}
