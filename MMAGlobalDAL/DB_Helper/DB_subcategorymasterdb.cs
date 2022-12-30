using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using Microsoft.EntityFrameworkCore;


namespace MMAGlobalDAL.Database.DB_Helper
{
    public class DB_subcategorymasterdb
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_subcategorymasterdb(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }

        public bool SaveSubCategory(sub_categorymasterdb subcategorymasters)

        {
            bool isSuccess = false;
            try
            {    
                _DataContext.sub_category.Add(subcategorymasters);
                if (subcategorymasters.sino > 0)
                {
                    _DataContext.Entry(subcategorymasters).State = EntityState.Modified;
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

        public List<sub_categorymasterdb> Getdata()
        {
            return _DataContext.sub_category.ToList();
        }

    }
}