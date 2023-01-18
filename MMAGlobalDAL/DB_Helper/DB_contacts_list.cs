using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using Microsoft.EntityFrameworkCore;

namespace MMAGlobalDAL.Database.DB_Helper
{
   public class DB_contacts_list
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_contacts_list(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public DB_contacts_list()
        {

        }

        public bool SaveContactlist(contacts_list contactlists)

        {
            bool isSuccess = false;
            try
            {
                _DataContext.contactslist.Add(contactlists);
                if (contactlists.slno > 0)
                {
                    _DataContext.Entry(contactlists).State = EntityState.Modified;
                }
                _DataContext.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSuccess;
        }

        public List<contacts_list> Getdata()
        {
            return _DataContext.contactslist.ToList();
        }
    }
}
