using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalDAL.Database.DB_Entity
{
    [Table("shooting_character")]
    public class shooting_character
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int character_id { get; set; }

        public int shooting_id { get; set; }

        public int contactlist_id { get; set; }

        public Boolean flag { get; set; }


    }
}
