using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MMAGlobalDAL.Database.DB_Entity;


namespace MMAGlobalDAL.Database.DB_Helper
{
    public class DB_fund_utilization
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_fund_utilization(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public bool SaveFundutilization(fund_utilization fund_utilization)
        {
            bool isSuccess = false;
            try
            {

                _DataContext.fund_utilization.Add(fund_utilization);
                if (fund_utilization.slno > 0)
                {
                    _DataContext.Entry(fund_utilization).State = EntityState.Modified;
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
        public List<fund_utilization> Getdata()
        {
            return _DataContext.fund_utilization.ToList();
        }

    }
}
