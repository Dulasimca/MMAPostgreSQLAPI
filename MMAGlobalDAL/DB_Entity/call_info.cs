using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MMAGlobalDAL.Database.DB_Entity
{
    [Table("call_info")]
    public class call_info
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int slno  { get; set; }
        public int project_name { get; set; }
        public int role_id { get; set; }
        public int main_category_id { get; set; }
        public int sub_category_id { get; set; }
        public DateTime date { get; set; }
        public TimeSpan general_call_time { get; set; }
        public TimeSpan shooting_call_time { get; set; }
        public int location_id { get; set; }
        public string phone_number { get; set; }
        public DateTime created_date{ get; set; }
        public Boolean flag { get; set; }
    }
}