using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using Microsoft.EntityFrameworkCore;


namespace MMAGlobalDAL.Database.DB_Helper
{
   public class DB_shooting_status
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_shooting_status(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public DB_shooting_status()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maincategorymasters"></param>
        /// <returns></returns>
        public bool Saveshootingstatus(shooting_status shootingstatus)

        {
            bool isSuccess = false;
            try
            {
                _DataContext.shooting_status.Add(shootingstatus);
                if (shootingstatus.slno > 0)
                {
                    _DataContext.Entry(shootingstatus).State = EntityState.Modified;
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

        public List<shooting_status> Getdata()
        {
            return _DataContext.shooting_status.ToList();
        }
    }
}