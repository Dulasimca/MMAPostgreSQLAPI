using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using Microsoft.EntityFrameworkCore;

namespace MMAGlobalDAL.Database.DB_Helper
{
    public class DB_union_masters
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_union_masters(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public bool SaveUnionMaster(union_masters union_masters)
        {
            bool isSuccess = false;
            try
            {
                _DataContext.union_master.Add(union_masters);
                if (union_masters.sino > 0)
                {
                    _DataContext.Entry(union_masters).State = EntityState.Modified;
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
        public List<union_masters> Getdata()
        {
            return _DataContext.union_master.ToList();
        }
    }
}
