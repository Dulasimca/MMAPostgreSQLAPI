using System;
using System.Collections.Generic;
using System.Linq;
using MMAGlobalDAL.Database.DB_Entity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalDAL.Database.DB_Helper
{
    public class DB_registration
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_registration(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public bool SaveRegistrationDB(registration registration)

        {
            bool isSuccess = false;
            try
            {
                // trainingdb.id = (_DataContext.trainingdb.Max(u => u.id)) + 1;
                _DataContext.registration.Add(registration);
                if (registration.slno > 0)
                {
                    _DataContext.Entry(registration).State = EntityState.Modified;
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
        public List<registration> Getdata()
        {
            return _DataContext.registration.ToList();
        }
    }
}
