using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MMAGlobalDAL.Database.DB_Entity;

namespace MMAGlobalDAL.Database.DB_Helper
{
    public class DB_shooting_schedule
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_shooting_schedule(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public bool Saveshootingschedule(shooting_schedule shooting_schedule)
        {
            bool isSuccess = false;
            try
            {

                _DataContext.shooting_schedule.Add(shooting_schedule);
                if (shooting_schedule.slno > 0)
                {
                    _DataContext.Entry(shooting_schedule).State = EntityState.Modified;
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
        public List<shooting_schedule> Getdata()
        {
            return _DataContext.shooting_schedule.ToList();
        }

    }
}

    