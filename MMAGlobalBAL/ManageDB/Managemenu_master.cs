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
        /// <summary>
        /// This method will store the menu master data in to database. we can use same method for insert and update.
        /// </summary>
        /// <param name="model">we have to send the menu master properties with values</param>
        /// <param name="_db">Database connectoin property for menu master</param>
        /// <returns>return boolean values. true or false</returns>
        public bool Save(menu_master_model model, DB_menu_master _db)
        {
            bool isSuccess = false;
            try
            {
                menu_master _menu_masters = new menu_master
                {
                    menuid=model.menuid,
                    id = model.id, 
                    name = model.name,
                    url = model.url,
                    parentid =model.parentid,
                    icon=model.icon,
                    roleid=model.roleid,
                    isactive=model.isactive,
                    priorities=model.priorities,

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
        public List<menu_master_model> GetData(DB_menu_master _db, DB_role_master _rolemaster )
        {
            try
            {
                List<menu_master_model> _Model = new List<menu_master_model>();
                var result = _db.Getdata();
                var _role = _rolemaster.Getdata();
                _Model = (from menu in result
                          join role in _role on menu.roleid equals role.roleid
                          select new menu_master_model
                          {
                              menuid = menu.menuid,
                              id = menu.id,
                              name = menu.name,
                              url = menu.url,
                              parentid = menu.parentid,
                              icon = menu.icon,
                              roleid = menu.roleid,
                              isactive = menu.isactive,
                              priorities = menu.priorities,
                              rolename = role.rolename
                          }).ToList();
              //  restul.ForEach(model => _Model.Add(new menu_master_model()
              //  {
              //      }));

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
