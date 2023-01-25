using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalDAL.Database.DB_Entity
{
    [Table("locationinfo")]
    public class location_info
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int slno { get; set; }
        public string location_name { get; set; }
        public int location_managerid { get; set; }
        public int local_epid { get; set; }
        public int country_id { get; set; }
        public int state_id { get; set; }
        public int city_id { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string phonenumber { get; set; }
        public Boolean parking_facility { get; set; }
        public string parking_note { get; set; }
        public DateTime created_date { get; set; }
        public int pincode { get; set; }
        public Boolean flag { get; set; }

    }
}