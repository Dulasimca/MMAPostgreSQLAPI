using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MMAGlobalDAL.Database.DB_Entity
{
    [Table("call_character")]

    public class call_character
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int callcharacter_id { get; set; }
        public int callinfo_id { get; set; }
        public int contactlist_id { get; set; }
        public Boolean flag { get; set; }
    }
}
