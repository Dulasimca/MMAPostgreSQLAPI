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
                    countrycode = model.countrycode,
                    statecode = model.statecode,
                    citycode = model.citycode,
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
  public List<contacts_list_model> GetData(DB_contacts_list _db, DB_country_master _Countrymaster, DB_statemaster _Statemaster, DB_city_master _City_Master, DB_role_master _rolemaster
      , DB_union_masters _Union_Masters, DB_maincategorymaster _Maincategorymaster, DB_subcategorymasterdb _subcategorymaster )
        {
            try
            {
                List<contacts_list_model> _Model = new List<contacts_list_model>();
                var restul = _db.Getdata();
                var _country = _Countrymaster.Getdata();
                var _state = _Statemaster.Getdata();
                var _city = _City_Master.Getdata();
                var _role = _rolemaster.Getdata();
                var _union = _Union_Masters.Getdata();
                var _maincategory = _Maincategorymaster.Getdata();
                var _subcategory = _subcategorymaster.Getdata();


                _Model = (from contactslist in restul
                          join countrycode in _country on contactslist.countrycode equals countrycode.countrycode
                          join statecode in _state on contactslist.statecode equals statecode.statecode
                          join citycode in _city on contactslist.citycode equals citycode.citycode
                          join roleid in _role on contactslist.roleid equals roleid.roleid
                          join unionid in _union on contactslist.unionid equals unionid.sino
                          join maincategory_id in _maincategory on contactslist.maincategory_id equals maincategory_id.sino  
                          join subcategory_id  in _subcategory on contactslist.subcategory_id equals subcategory_id.sino
                          select new contacts_list_model
                          //  restul.ForEach(model => _Model.Add(new contacts_list_model()
                          { 
                    slno = contactslist.slno,
                    first_name = contactslist.first_name,
                    last_name = contactslist.last_name,
                    roleid = contactslist.roleid,
                    maincategory_id = contactslist.maincategory_id,
                    subcategory_id = contactslist.subcategory_id,
                    dob = contactslist.dob,
                    phonenumber = contactslist.phonenumber,
                    whatsappnumber = contactslist.whatsappnumber,
                    email_id = contactslist.email_id,
                    countrycode = contactslist.countrycode,
                    statecode = contactslist.statecode,
                    citycode = contactslist.citycode,
                    address1 = contactslist.address1,
                    address2 = contactslist.address2,
                    pincode = contactslist.pincode,
                    isunion = contactslist.isunion,
                    unionid = contactslist.unionid,
                    flag = contactslist.flag,
                    countryname = countrycode.countryname,
                    statename = statecode.statename,
                    cityname = citycode.cityname,
                    rolename= roleid.rolename,
                    unionname = unionid.unionname,
                    maincategoryname=maincategory_id.categoryname,
                    subcategoryname=subcategory_id.categoryname,

                          }).ToList();

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
