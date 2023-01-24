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
    public class Manage_lodging_info
    {
        /// <summary>
        /// This method will store the expensescategory master data in to database. we can use same method for insert and update.
        /// </summary>
        /// <param name="model">we have to send the expensescategory master properties with values</param>
        /// <param name="_db">Database connectoin property for expensescategory master</param>
        /// <returns>return boolean values. true or false</returns>
        public bool Save(lodging_info_Model model,DB_lodging_info _db)
        {
            bool isSuccess = false;
            try
            {
                lodging_info lodging_info = new lodging_info
                {
                    slno = model.slno,
                    location = model.location,
                    address = model.address,
                    note = model.note,

                };
                isSuccess = _db.SaveLodginginfo(lodging_info);
                return isSuccess;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageTraningDB save method: " + ex.Message);
                return isSuccess;
            }

        }
        public List<lodging_info_Model> GetData(DB_lodging_info _db)
        {
            try
            {
                List<lodging_info_Model> _Model = new List<lodging_info_Model>();
                var restul = _db.Getdata();
                restul.ForEach(model => _Model.Add(new lodging_info_Model()
                          {

                    slno = model.slno,
                    location = model.location,
                    address = model.address,
                    note = model.note,
                }));

                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManagelodginginfoDB get method: " + ex.Message);
                return null;
            }

        }
    }
}

