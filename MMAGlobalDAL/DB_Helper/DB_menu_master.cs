using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using Microsoft.EntityFrameworkCore;


namespace MMAGlobalDAL.Database.DB_Helper
{
   public class DB_menu_master
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_menu_master(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public bool SaveMenuMaster(menu_master menu_master)
        {
            bool isSuccess = false;
            try
            {
                if(menu_master.menuid==0) /// id increment if menuid =0
                {
                    menu_master.id = (_DataContext.menumaster.Max(m => (int?)m.id) ?? 0 )+1;
                }
                _DataContext.menumaster.Add(menu_master);
                if (menu_master.menuid > 0) // update the menu if menu id available
                {
                    _DataContext.Entry(menu_master).State = EntityState.Modified;
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
        public List<menu_master> Getdata()
        {
            return _DataContext.menumaster.ToList();
        }
    }
}
