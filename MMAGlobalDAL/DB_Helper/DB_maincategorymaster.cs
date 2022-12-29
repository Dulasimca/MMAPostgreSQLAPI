using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;


namespace MMAGlobalDAL.Database.DB_Helper
{
    public class DB_maincategorymaster
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_maincategorymaster(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }

        public bool SaveMainCategoryMaster(main_categorymasterdb maincategorymasters)

        {
            bool isSuccess = false;
            try
            {
                _DataContext.maincategory_master.Add(maincategorymasters);
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