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
    public class Manage_expensescategory_master
    {
        /// <summary>
        /// This method will store the expensescategory master data in to database. we can use same method for insert and update.
        /// </summary>
        /// <param name="model">we have to send the expensescategory master properties with values</param>
        /// <param name="_db">Database connectoin property for expensescategory master</param>
        /// <returns>return boolean values. true or false</returns>
        public bool Save(expensescategory_master_model model, DB_expensescategory_master _db)
        {
            bool isSuccess = false;
            try
            {
                expensescategory_master expensescategory_masters = new expensescategory_master
                {
                    sino = model.sino,
                    name = model.name,
                    notes = model.notes,
                    flag = model.flag,
                   
                };
                isSuccess = _db.SaveExpensesCategoryMaster(expensescategory_masters);
                return isSuccess;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageTraningDB save method: " + ex.Message);
                return isSuccess;
            }

        }
        public List<expensescategory_master_model> GetData(DB_expensescategory_master _db)
        {
            try
            {
                List<expensescategory_master_model> _Model = new List<expensescategory_master_model>();
                var restul = _db.Getdata();
                restul.ForEach(model => _Model.Add(new expensescategory_master_model()
                {
                    sino = model.sino,
                    name = model.name,
                    notes = model.notes,
                    flag = model.flag,
                }));

                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageexpensesmasterDB get method: " + ex.Message);
                return null;
            }

        }
    }
}
