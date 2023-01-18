using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MMAGlobalDAL.Database.DB_Entity
{
    [Table("daily_expenses")]
    public class daily_expenses
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int slno { get; set; }
        public int project_name { get; set; }
        public int budget_amount { get; set; }
        public DateTime date { get; set; }
        public string  invoice_number { get; set; }
        public int expenses_category { get; set; }
        public int amount { get; set; }
        public DateTime created_date { get; set; }
    }
}
