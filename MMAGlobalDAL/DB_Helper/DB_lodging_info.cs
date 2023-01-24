using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using Microsoft.EntityFrameworkCore;

namespace MMAGlobalDAL.Database.DB_Helper
{
    public class DB_lodging_info
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_lodging_info(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public bool SaveLodginginfo(lodging_info lodging_info)
        {
            bool isSuccess = false;
            try
            {

                _DataContext.lodging_info.Add(lodging_info);
                if (lodging_info.slno > 0)
                {
                    _DataContext.Entry(lodging_info).State = EntityState.Modified;
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
        public List<lodging_info> Getdata()
        {
            return _DataContext.lodging_info.ToList();
        }

    }
}