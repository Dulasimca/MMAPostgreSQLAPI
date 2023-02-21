using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;

namespace MMAGlobalDAL.Database.DB_Helper
{
  public class DB_masters
    {
        private readonly EF_MMADatabaseContext _DataContext;

        public DB_masters (EF_MMADatabaseContext datacontext)
        {
            _DataContext = datacontext;
        }
        //public List<role_master> Getdata()
        //{
        //    return _DataContext.role_master.ToList();
        //}
        public DB_MasterEntity Getdata()
        {

            DB_MasterEntity dB_Master = new DB_MasterEntity();
            dB_Master.main_Categorymasters = _DataContext.maincategory_master.ToList();
            dB_Master.sub_Categorymasters = _DataContext.sub_category.ToList();
            dB_Master.role_Masters = _DataContext.role_master.ToList();
            dB_Master.statemasters = _DataContext.state_master.ToList();
            dB_Master.city_Masters = _DataContext.citymaster.ToList();
            dB_Master.union_Masters = _DataContext.union_master.ToList();
            dB_Master.expensescategory_Masters = _DataContext.expensescategorymaster.ToList();
            dB_Master.country_Masters = _DataContext.country_master.ToList();
            dB_Master.shooting_Statuses = _DataContext.shooting_status.ToList();

            return dB_Master;
        }


    }
}
