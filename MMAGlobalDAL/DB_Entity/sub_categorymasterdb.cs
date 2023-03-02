using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalDAL.Database.DB_Entity
{
    [Table("sub_category")]
    public class sub_categorymasterdb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int sino { get; set; }
        public string categoryname { get; set; }
        public int maincategorycode { get; set; }
        public Boolean flag { get; set; }
    }
}
