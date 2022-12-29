using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalDAL.Database.DB_Entity
{
    [Table("expensescategory_master")]
    public class expensescategory_master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int sino { get; set; }
        public string name { get; set; }
        public string notes { get; set; }
        public Boolean flag { get; set; }
    }
}
