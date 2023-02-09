using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalDAL.Database.DB_Entity
{
    [Table("shooting_shedule")]
    public class shooting_schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int slno { get; set; }
        public int project_id { get; set; }

        public string scene { get; set; }
        public string interior_exterior { get; set; }
        public string day_night { get; set; }

        public int schedule_day { get; set; }

        public DateTime schedule_date { get; set; }
        public int status_id { get; set; }

        public int main_category_id { get; set; }

        public int sub_category_id { get; set; }

        public DateTime created_date { get; set; }

        public Boolean flag { get; set; }

    }
}
