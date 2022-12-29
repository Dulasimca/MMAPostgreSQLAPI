using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalDAL.Database.DB_Entity
{
    [Table("city_master")]
   public class city_master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int citycode { get; set; }
        public string cityname { get; set; }
        public int statecode { get; set; }
        public Boolean flag { get; set; }
    }
}
