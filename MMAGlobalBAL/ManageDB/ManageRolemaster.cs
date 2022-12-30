using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using MMAGlobalBAL.Model;
using MMAGlobalDAL.Database.DB_Helper;
using MMAGlobalAPI.common;


namespace MMAGlobalBAL.ManageDB
{
    public class ManageRolemaster
    {
        /// <summary>
        /// This method will store the role master data in to database. we can use same method for insert and update.
        /// </summary>
        /// <param name="model">we have to send the role master properties with values</param>
        /// <param name="_db">Database connectoin property for role master</param>
        /// <returns>return boolean values. true or false</returns>
        public bool Save(role_master_Model model, DB_role_master _db)
        {
            bool isSuccess = false;
            try
            {
                role_master db = new role_master
                {
                    roleid = model.roleid,
                    rolename = model.rolename,
                    flag = model.flag
                };
                isSuccess = _db.SaveRolemasterDB(db);
                // Task.Run(()=> _db.SaveTrainingDB(_traningdb));
                return isSuccess;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageRolemaster save method: " + ex.Message);
                return isSuccess;
            }

        }
        public List<role_master_Model> GetData(DB_role_master _db)
        {
            try
            {
                List<role_master_Model> _Model = new List<role_master_Model>();
                var restul = _db.Getdata();
                restul.ForEach(model => _Model.Add(new role_master_Model()
                {
                    roleid = model.roleid,
                    rolename = model.rolename,
                    flag = model.flag
                }));

                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageRolemasterDB save method: " + ex.Message);
                return null;
            }

        }

    }
}
