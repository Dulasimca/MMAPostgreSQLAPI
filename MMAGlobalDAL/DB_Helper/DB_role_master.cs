using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MMAGlobalDAL.Database.DB_Entity;


namespace MMAGlobalDAL.Database.DB_Helper
{
    public class DB_role_master
    {

        private EF_MMADatabaseContext _DataContext;
        public DB_role_master(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public bool SaveRolemasterDB(role_master role_master)

        {
            bool isSuccess = false;
            try
            {
               // trainingdb.id = (_DataContext.trainingdb.Max(u => u.id)) + 1;
                _DataContext.role_master.Add(role_master);
                if (role_master.roleid > 0)
                {
                    _DataContext.Entry(role_master).State = EntityState.Modified;
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
        public List<role_master> Getdata()
        {
            return _DataContext.role_master.ToList();
        }
    }
}