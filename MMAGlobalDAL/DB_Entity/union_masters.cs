using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MMAGlobalDAL.Database.DB_Entity
{
    [Table("union_master")]
   public class union_masters
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int sino { get; set; }
        public string unionname { get; set; }
        public string registernumber { get; set; }
        public Boolean flag { get; set; }


    }
}
