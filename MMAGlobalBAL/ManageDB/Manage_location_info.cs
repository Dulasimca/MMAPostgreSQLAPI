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
    public class Manage_location_info
    {
        /// <summary>
        /// This method will store the location info data in to database. we can use same method for insert and update.
        /// </summary>
        /// <param name="model">we have to send the location info  properties with values</param>
        /// <param name="_db">Database connectoin property for location info</param>
        /// <returns>return boolean values. true or false</returns>

        public bool Save(location_info_model model, DB_location_info _db)
        {
            bool isSuccess = false;
            try
            {
                location_info _location_info = new location_info
                {
                    slno = model.slno,
                    location_name = model.location_name,
                    location_managerid = model.location_managerid,
                    local_epid = model.local_epid,
                    country_id = model.country_id,
                    state_id = model.state_id,
                    city_id = model.city_id,
                    address1 = model.address1,
                    address2 = model.address2,
                    phonenumber = model.phonenumber,
                    parking_facility = model.parking_facility,
                    parking_note = model.parking_note,
                    created_date = model.created_date,
                    pincode = model.pincode,
                    flag = model.flag,

                };
                isSuccess = _db.SaveLocationInfo(_location_info);
                return isSuccess;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageLocationInfo save method: " + ex.Message);
                return isSuccess;
            }

        }
        public List<location_info_model> GetData(DB_location_info _db, DB_country_master _Countrymaster, DB_statemaster _Statemaster, DB_city_master _City_Master, DB_contacts_list _contacts_list)
        {
            try
            {
                List<location_info_model> _Model = new List<location_info_model>();
                var restul = _db.Getdata();
                var _country = _Countrymaster.Getdata();
                var _state = _Statemaster.Getdata();
                var _city = _City_Master.Getdata();
                var _contact = _contacts_list.Getdata();
                //  restul.ForEach(model => _Model.Add(new location_info_model()
                _Model = (from location in restul
                          join country in _country on location.country_id equals country.countrycode
                          join state in _state on location.state_id equals state.statecode
                          join city in _city on location.city_id equals city.citycode
                          join contacts in _contact on location.location_managerid equals contacts.slno
                          select new location_info_model
                          {
                              slno = location.slno,
                              location_name = location.location_name,
                              location_managerid = location.location_managerid,
                              local_epid = location.local_epid,
                              country_id = location.country_id,
                              state_id = location.state_id,
                              city_id = location.city_id,
                              address1 = location.address1,
                              address2 = location.address2,
                              phonenumber = location.phonenumber,
                              parking_facility = location.parking_facility,
                              parking_note = location.parking_note,
                              created_date = location.created_date,
                              pincode = location.pincode,
                              flag = location.flag,
                              countryname = country.countryname,
                              statename = state.statename,
                              cityname = city.cityname,
                              first_name = contacts.first_name

                          }).ToList();
                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("LocationInfoGet get method: " + ex.Message);
                return null;
            }

        }
    }
}
