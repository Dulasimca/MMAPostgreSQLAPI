using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
namespace MMAGlobalDAL.Database.DB_Helper
{
   public class DB_statemaster
  
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_statemaster(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }

        ///<summary>
        ///inseert and update
        /// </summary>
        /// <returns></returns>

        public bool Savestatemaster(statemasterdb state_master)

        {
            bool isSuccess = false;
            try
            {
               
                _DataContext.state_master.Add(state_master);
                _DataContext.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSuccess;
       
        }
        public List<statemasterdb> Getdata()
        {
            return _DataContext.state_master.ToList();
        }
    }
}
