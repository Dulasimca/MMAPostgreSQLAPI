using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace MMAGlobalDAL.Database.DB_Entity
{
    [Table("transport_info")]
    public  class transport_info
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int slno { get; set; }
        public string  driver_name{ get; set; }
        public DateTime pickup_time{ get; set; }
        public string pickup_location { get; set; }
        public string drop_location { get; set; }
        public int passenger_id { get; set; }
    }
}
