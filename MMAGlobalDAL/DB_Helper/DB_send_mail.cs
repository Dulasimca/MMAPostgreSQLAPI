using System;
using System.Collections.Generic;
using System.Linq;
using MMAGlobalDAL.Database.DB_Entity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;


namespace MMAGlobalDAL.Database.DB_Helper
{
   public class DB_send_mail
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_send_mail(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public Mail_Entity Getdata(int mailtype)
        {
            return _DataContext.Mail_Entity.Where(a=>a.mail_type == mailtype).FirstOrDefault();
        }
    }
}
