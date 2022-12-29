using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using MMAGlobalBAL.Model;
using MMAGlobalDAL.Database.DB_Helper;
using MMAGlobalAPI.common;
using MMAGlobalDAL;

namespace MMAGlobalBAL.ManageDB
{
    public class Managemenu_master
    {
        public bool Save(menu_master_model model, DB_menu_master _db)
        {
            bool isSuccess = false;
            try
            {
                menu_master _menu_masters = new menu_master
                {
                    menuid = model.menuid,
                    id = model.id,
                    name = model.name,
                    url = model.url,
                    parentid =model.parentid,
                    icon=model.icon,
                    roleid=model.roleid,
                    isactive=model.isactive,
                    priorities=model.priorities

                };
                isSuccess = _db.SaveMenuMaster(_menu_masters);
                return isSuccess;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageMenuMaster save method: " + ex.Message);
                return isSuccess;
            }

        }
        public List<menu_master_model> GetData(DB_menu_master _db)
        {
            try
            {
                List<menu_master_model> _Model = new List<menu_master_model>();
                var restul = _db.Getdata();
                restul.ForEach(model => _Model.Add(new menu_master_model()
                {
                    menuid = model.menuid,
                    id = model.id,
                    name = model.name,
                    url = model.url,
                    parentid = model.parentid,
                    icon = model.icon,
                    roleid = model.roleid,
                    isactive = model.isactive,
                    priorities = model.priorities
                }));

                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageMenuMaster save method: " + ex.Message);
                return null;
            }

        }
    }
}
