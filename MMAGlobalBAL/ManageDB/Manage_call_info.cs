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
        public bool Save(callinfodetails_Model model, DB_call_info _db,DB_lodging_info _dblodging,DB_transport_info dB_Transport,DB_call_character _dbCall)
        {
            bool isSuccess = false;
            try
            {
                call_info db = new call_info
                {
                   slno = model.callinfo.slno,
                   project_name = model.callinfo.project_name,
                   role_id=model.callinfo.role_id,
                   main_category_id=model.callinfo.main_category_id,
                   sub_category_id=model.callinfo.sub_category_id,
                   date=model.callinfo.date,
                   general_call_time=model.callinfo.general_call_time,
                   shooting_call_time=model.callinfo.shooting_call_time,
                   location_id=model.callinfo.location_id,
                   phone_number=model.callinfo.phone_number,
                   created_date=model.callinfo.created_date,
                    flag = model.callinfo.flag
                };
                int callid = _db.SaveCallinfo(db);
                //
                if(callid>0)
                {
                    Manage_lodging_info manage_Lodging = new Manage_lodging_info();
                    model.lodging.callinfoid = callid;
                    manage_Lodging.Save(model.lodging, _dblodging);

                    Manage_transport_info manage_transport = new Manage_transport_info();
                    model.transport.callinfoid = callid;
                    manage_transport.Save(model.transport, dB_Transport);

                    //contactus info
                    foreach (int item in model.contactusid)
                    {
                        call_character _Character = new call_character
                        {
                            callinfo_id = callid,
                            contactlist_id = item,
                            flag =true
                        };
                        _dbCall.Savecallcharacter(_Character);
                    }
                }
                // Task.Run(()=> _db.SaveTrainingDB(_traningdb));
                return isSuccess;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageCallinfo save method: " + ex.Message);
                return isSuccess;
            }

        }
        public List<call_info_Model> GetData(DB_call_info _db, DB_projectcreation _dailyprojectname, DB_role_master _rolemaster, DB_maincategorymaster _Maincategorymaster)
        {
            try
            {
                List<call_info_Model> _Model = new List<call_info_Model>();
                var restul = _db.Getdata();
                var _projectname = _dailyprojectname.Getdata();
                var _role = _rolemaster.Getdata();
                var _maincategory = _Maincategorymaster.Getdata();

                _Model = (from model in restul
                          join projectname in _projectname on model.project_name equals projectname.project_id
                          join role in _role on model.role_id equals role.roleid
                          join main_category_id in _maincategory on model.main_category_id equals main_category_id.sino
                          select new call_info_Model
                          //restul.ForEach(model => _Model.Add(new call_info_Model()
                          {
                    slno = model.slno,
                    project_name = model.project_name,
                    role_id = model.role_id,
                    main_category_id = model.main_category_id,
                    date = model.date,
                    general_call_time = model.general_call_time,
                    shooting_call_time = model.shooting_call_time,
                    location_id = model.location_id,
                    phone_number = model.phone_number,
                    created_date = model.created_date,
                    flag = model.flag,
                    projectname = projectname.project_name,
                    rolename = role.rolename,
                          }).ToList();

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