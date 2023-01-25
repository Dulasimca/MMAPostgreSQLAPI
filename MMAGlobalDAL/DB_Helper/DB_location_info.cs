using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using Microsoft.EntityFrameworkCore;

namespace MMAGlobalDAL.Database.DB_Helper
{
    public class DB_location_info
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_location_info(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public bool SaveLocationInfo(location_info _location_info)
        {
            bool isSuccess = false;
            try
            {
                _DataContext.locationinfo.Add(_location_info);
                if (_location_info.slno > 0)
                {
                    _DataContext.Entry(_location_info).State = EntityState.Modified;
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
        public List<location_info> Getdata()
        {
            return _DataContext.locationinfo.ToList();
        }

    }
}