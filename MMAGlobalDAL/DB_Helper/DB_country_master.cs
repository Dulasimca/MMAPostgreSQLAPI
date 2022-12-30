using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using Microsoft.EntityFrameworkCore;
namespace MMAGlobalDAL.Database.DB_Helper

{
   public class DB_country_master
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_country_master(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public bool SaveCountrymasterDB(country_master country_master)

        {
            bool isSuccess = false;
            try
            {
                // trainingdb.id = (_DataContext.trainingdb.Max(u => u.id)) + 1;
                _DataContext.country_master.Add(country_master);
                if(country_master.countrycode > 0)
                {
                    _DataContext.Entry(country_master).State = EntityState.Modified;
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
        public List<country_master> Getdata()
        {
            return _DataContext.country_master.ToList();
        }
    }
}