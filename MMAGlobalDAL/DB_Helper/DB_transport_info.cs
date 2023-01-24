using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using Microsoft.EntityFrameworkCore;

namespace MMAGlobalDAL.Database.DB_Helper
{
    public class DB_transport_info
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_transport_info(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public DB_transport_info()
        {

        }

        public bool Savetransportinfo(transport_info transport_info)

        {
            bool isSuccess = false;
            try
            {
                _DataContext.transport_info.Add(transport_info);
                if (transport_info.slno > 0)
                {
                    _DataContext.Entry(transport_info).State = EntityState.Modified;
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

        public List<transport_info> Getdata()
        {
            return _DataContext.transport_info.ToList();
        }
    }
}

