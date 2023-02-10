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
    public class Manage_call_character
    {
        public bool Savecallcharacter(call_character_Model model, DB_call_character _db)
        {
            bool isSuccess = false;
            try
            {
                call_character call_character = new call_character
                {
                    callcharacter_id = model.callcharacter_id,
                    callinfo_id = model.callinfo_id,
                    contactlist_id = model.contactlist_id,
                    flag = model.flag,


                };
                isSuccess = _db.Savecallcharacter(call_character);
                return isSuccess;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageCallcharacter save method: " + ex.Message);
                return isSuccess;
            }

        }
        public List<call_character_Model> GetData(DB_call_character _db)
        {
            try
            {
                List<call_character_Model> _Model = new List<call_character_Model>();
                var restul = _db.Getdata();
                restul.ForEach(model => _Model.Add(new call_character_Model()
                {
                    callcharacter_id = model.callcharacter_id,
                    callinfo_id = model.callinfo_id,
                    contactlist_id = model.contactlist_id,
                    flag = model.flag,
                }));

                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageCountrymasterDB save method: " + ex.Message);
                return null;
            }
        }
    }
}
