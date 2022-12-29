using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;

namespace MMAGlobalDAL.Database.DB_Helper
{
   public class DB_expensescategory_master
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_expensescategory_master(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public bool SaveExpensesCategoryMaster(expensescategory_master expensescategory_master)
        {
            bool isSuccess = false;
            try
            {
                _DataContext.expensescategorymaster.Add(expensescategory_master);
                _DataContext.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSuccess;
        }
        public List<expensescategory_master> Getdata()
        {
            return _DataContext.expensescategorymaster.ToList();
        }
    }
}
