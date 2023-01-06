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
using CommonUtilities;

namespace MMAGlobalBAL.ManageDB
{
   public class Manage_user_master
    {
        Security security = new Security();

        /// <summary>
        /// This method will store the user master data in to database. we can use same method for insert and update.
        /// </summary>
        /// <param name="model">we have to send the user master properties with values</param>
        /// <param name="_db">Database connectoin property for user master</param>
        /// <returns>return boolean values. true or false</returns>

        public bool Save(user_master_model model, DB_user_master _db)
        {
            bool isSuccess = false;
            try
            {
                user_master _user_masters = new user_master
                {
                    id = model.id,
                    username_emailid = model.username_emailid,
                    roleid = model.roleid,
                    password = security.Decryptword(model.password),
                    flag = model.flag,
                    };
                isSuccess = _db.SaveUserMaster(_user_masters);
                return isSuccess;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageUserMaster save method: " + ex.Message);
                return isSuccess;
            }

        }
        public List<user_master_model> GetData(DB_user_master _db, DB_role_master _rolemaster)
        {
            try
            {
                List<user_master_model> _Model = new List<user_master_model>();
                var result = _db.Getdata();
                var _role = _rolemaster.Getdata();
                _Model = (from user in result
                          join role in _role on user.roleid equals role.roleid
                          select new user_master_model
                          {
                             
                              id = user.id,
                              username_emailid = user.username_emailid,
                              roleid = user.roleid,
                              password = security.Decryptword (user.password),
                              flag = user.flag,
                              rolename = role.rolename
                          }).ToList();
               
                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageUserMaster save method: " + ex.Message);
                return null;
            }

        }
    }
}
