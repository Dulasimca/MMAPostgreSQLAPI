using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MMAGlobalDAL.Database.DB_Entity
{
    [Table("state_master")]
    public class statemasterdb
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int statecode { get; set; }
        public string statename { get; set; }
        public int countrycode { get; set; }
        public Boolean flag { get; set; }
    }
}


