using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalBAL.Model
{
   public class user_master_model
    {
        public int id { get; set; }
        public string username_emailid { get; set; }
        public int roleid { get; set; }
        public string password { get; set; }
        public Boolean flag { get; set; }
        public string rolename { get; set; }
    }

    //model entities for update change password
    public class update_password_model
    {
        public int id { get; set; }
        public string password { get; set; }
    }
}
