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
        public int Saveshooting_schedule(shooting_schedule shooting_schedule)
        {
            int shooting_id = 0;
            try
            {

                _DataContext.shooting_shedule.Add(shooting_schedule);
                if (shooting_schedule.slno > 0)
                {
                    _DataContext.Entry(shooting_schedule).State = EntityState.Modified;
                }
                _DataContext.SaveChanges();
                shooting_id = shooting_schedule.slno;


            }
            catch (Exception ex)
            {
                return shooting_id;
            }
            return shooting_id;
        }
              
        public List<shooting_schedule> Getdata()
        {
            return _DataContext.shooting_shedule.ToList();
        }

    }
}

    