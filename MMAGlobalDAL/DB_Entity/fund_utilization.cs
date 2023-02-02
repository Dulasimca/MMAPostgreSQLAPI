using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalDAL.Database.DB_Entity
{
    [Table("fund_utilization")]
    public class fund_utilization
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int slno { get; set; }
        public int project_name { get; set; }
        public int budget_amount { get; set; }
        public int person_name { get; set; }
        public string payment_by { get; set; }
        public int amount { get; set; }
        public string day_or_call { get; set; }
        public string total_amount { get; set; }
        public DateTime created_date { get; set; }
    }
}
