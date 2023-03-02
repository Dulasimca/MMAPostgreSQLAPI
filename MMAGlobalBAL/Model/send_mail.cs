using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalBAL.Model
{
  public class send_mail_model
    {
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
