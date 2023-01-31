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
    public class Manage_call_info
    {

        /// <summary>
        /// This method will store the callinfo  data in to database. we can use same method for insert and update.
        /// </summary>
        /// <param name="model">we have to send the callinfo properties with values</param>
        /// <param name="_db">Database connectoin property for callinfo</param>
        /// <returns>return boolean values. true or false</returns>
        public bool Save(call_info_Model model, DB_call_info _db)
        {
            bool isSuccess = false;
            try
            {
                call_info db = new call_info
                {
                   slno = model.slno,
                   project_name = model.project_name,
                   role_id=model.role_id,
                   main_category_id=model.main_category_id,
                   sub_category_id=model.sub_category_id,
                   date=model.date,
                   general_call_time=model.general_call_time,
                   shooting_call_time=model.shooting_call_time,
                   location_id=model.location_id,
                   phone_number=model.phone_number,
                   created_date=model.created_date,
                    flag = model.flag
                };
                isSuccess = _db.SaveCallinfo(db);
                // Task.Run(()=> _db.SaveTrainingDB(_traningdb));
                return isSuccess;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageCallinfo save method: " + ex.Message);
                return isSuccess;
            }

        }
        public List<call_info_Model> GetData(DB_call_info _db)
        {
            try
            {
                List<call_info_Model> _Model = new List<call_info_Model>();
                var restul = _db.Getdata();
                restul.ForEach(model => _Model.Add(new call_info_Model()
                {
                    slno = model.slno,
                    project_name = model.project_name,
                    role_id = model.role_id,
                    main_category_id = model.main_category_id,
                    sub_category_id = model.sub_category_id,
                    date = model.date,
                    general_call_time = model.general_call_time,
                    shooting_call_time = model.shooting_call_time,
                    location_id = model.location_id,
                    phone_number = model.phone_number,
                    created_date = model.created_date,
                    flag = model.flag
                }));

                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageCallinfo save method: " + ex.Message);
                return null;
            }
        }
    }
}