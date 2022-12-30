using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using Microsoft.EntityFrameworkCore;

namespace MMAGlobalDAL.Database.DB_Helper
{
    public class DB_maincategorymaster
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_maincategorymaster(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public DB_maincategorymaster()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maincategorymasters"></param>
        /// <returns></returns>
        public bool SaveMainCategoryMaster(main_categorymasterdb maincategorymasters)

        {
            bool isSuccess = false;
            try
            {
                _DataContext.maincategory_master.Add(maincategorymasters);
                if(maincategorymasters.sino>0)
                {
                    _DataContext.Entry(maincategorymasters).State = EntityState.Modified;
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

        public List<main_categorymasterdb> Getdata()
        {
            return _DataContext.maincategory_master.ToList();
        }
    }
}