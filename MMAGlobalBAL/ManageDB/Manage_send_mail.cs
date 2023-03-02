using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using MMAGlobalBAL.Model;
using MMAGlobalDAL.Database.DB_Helper;
using MMAGlobalAPI.common;
using MMAGlobalDAL;

namespace MMAGlobalBAL.ManageDB
{
   public class Manage_send_mail
    {
        public send_mail_model GetData(DB_send_mail _db, int mailtype)
        {
            try
            {
               
                var model = _db.Getdata(mailtype);
               
                   send_mail_model _Model = new send_mail_model
                   {
                 slno = model.slno,
                    from_mailid = model.from_mailid,
                    cc_mailid = model.cc_mailid,
                    bcc_mailid =model.bcc_mailid,
                    subject =model.subject,
                    port = model.port,
                    smtp = model.smtp,
                    from_password = model.from_password,
                    mail_type = model.mail_type,
                    flag = model.flag
                   };

                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageSendMail save method: " + ex.Message);
                return null;
            }

        }
    }
}
