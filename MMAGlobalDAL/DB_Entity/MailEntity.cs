using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MMAGlobalDAL.Database.DB_Entity
{
    [Table("mail_settings")]
    public class Mail_Entity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int slno { get; set; }
        public string from_mailid { get; set; }
        public string cc_mailid { get; set; }
        public string bcc_mailid { get; set; }
        public string subject { get; set; }
        public int port { get; set; }
        public string smtp { get; set; }
        public string from_password { get; set; }
        public int mail_type { get; set; }
        public Boolean flag { get; set; }
    }
}
