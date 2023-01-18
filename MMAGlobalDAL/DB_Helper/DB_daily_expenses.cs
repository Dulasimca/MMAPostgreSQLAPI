using System;
using System.Collections.Generic;
using System.Linq;
using MMAGlobalDAL.Database.DB_Entity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalDAL.Database.DB_Helper
{
    public class DB_daily_expenses
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_daily_expenses(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public bool SaveDailyexpensesDB(daily_expenses daily_expenses)

        {
            bool isSuccess = false;
            try
            {
                // trainingdb.id = (_DataContext.trainingdb.Max(u => u.id)) + 1;
                _DataContext.daily_expenses.Add(daily_expenses);
                if (daily_expenses.slno > 0)
                {
                    _DataContext.Entry(daily_expenses).State = EntityState.Modified;
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
        public List<daily_expenses> Getdata()
        {
            return _DataContext.daily_expenses.ToList();
        }
    }
}
