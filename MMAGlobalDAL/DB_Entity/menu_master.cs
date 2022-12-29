using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalDAL.Database.DB_Entity
{
    [Table("menumaster")]
    public class menu_master
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int menuid { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public int parentid { get; set; }
        public string icon { get; set; }
        public int roleid { get; set; }
        public Boolean isactive { get; set; }
        public string priorities { get; set; }

    }
}
