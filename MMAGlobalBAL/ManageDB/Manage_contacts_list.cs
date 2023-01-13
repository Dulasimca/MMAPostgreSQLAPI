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
    public class Manage_contacts_list
    {
        public bool Save(contacts_list_model model, DB_contacts_list _db)
        {
            bool isSuccess = false;
            try
            {
                contacts_list contacts_list = new contacts_list
                {
                    slno = model.slno,
                    first_name = model.first_name,
                    last_name=model.last_name,
                    roleid = model.roleid,
                    maincategory_id = model.maincategory_id,
                    subcategory_id = model.subcategory_id,
                    dob = model.dob,
                    phonenumber = model.phonenumber,
                    whatsappnumber = model.whatsappnumber,
                    email_id = model.email_id,
                    country_id = model.country_id,
                    state_id = model.state_id,
                    city_id = model.city_id,
                    address1 = model.address1,
                    address2 = model.address2,
                    pincode = model.pincode,
                    isunion = model.isunion,
                    unionid = model.unionid,
                    flag = model.flag

                };
                isSuccess = _db.SaveContactlist(contacts_list);

            }
            catch (Exception ex)
            {
                AuditLog.WriteError("Managecontactlist save method: " + ex.Message);
            }
            return isSuccess;
        }

        public List<contacts_list_model> GetData(DB_contacts_list _db)
        {
            try
            {
                List<contacts_list_model> _Model = new List<contacts_list_model>();
                var restul = _db.Getdata();
                restul.ForEach(model => _Model.Add(new contacts_list_model()
                {
                    slno = model.slno,
                    first_name = model.first_name,
                    last_name = model.last_name,
                    roleid = model.roleid,
                    maincategory_id = model.maincategory_id,
                    subcategory_id = model.subcategory_id,
                    dob = model.dob,
                    phonenumber = model.phonenumber,
                    whatsappnumber = model.whatsappnumber,
                    email_id = model.email_id,
                    country_id = model.country_id,
                    state_id = model.state_id,
                    city_id = model.city_id,
                    address1 = model.address1,
                    address2 = model.address2,
                    pincode = model.pincode,
                    isunion = model.isunion,
                    unionid = model.unionid,
                    flag = model.flag
                }));

                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("Managecontactlist save method: " + ex.Message);
                return null;
            }

        }

    }
}
