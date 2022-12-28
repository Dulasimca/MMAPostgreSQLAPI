using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;

namespace MMAGlobalDAL.Database.DB_Helper
{
    public class DB_trainingdb
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_trainingdb(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }

        ///<summary>
        ///inseert and update
        /// </summary>
        /// <returns></returns>

        public bool SaveTrainingDB(trainingdb trainingdb)

        {
            bool isSuccess = false;
            try
            {
                 trainingdb.id = (_DataContext.trainingdb.Max(u => u.id)) + 1;
                _DataContext.trainingdb.Add(trainingdb);
                _DataContext.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSuccess;
        }

        public List<trainingdb> Getdata()
        {
            return _DataContext.trainingdb.ToList();
        }

    }
}
