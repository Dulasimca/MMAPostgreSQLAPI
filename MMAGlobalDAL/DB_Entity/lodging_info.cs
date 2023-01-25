using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace MMAGlobalDAL.Database.DB_Entity
{
    [Table("lodging_info")]
    public class lodging_info
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int slno { get; set; }
        public string location { get; set; }
        public string address { get; set; }
        public string note { get; set; }
    }
}
