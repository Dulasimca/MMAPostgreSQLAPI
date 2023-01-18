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
    public class ManageRegistration
    {
        /// <summary>
        /// This method will store the registration data in to database. we can use same method for insert and update.
        /// </summary>
        /// <param name="model">we have to send the registration properties with values</param>
        /// <param name="_db">Database connectoin property for registration</param>
        /// <returns>return boolean values. true or false</returns>
        public bool Save(registration_Model model, DB_registration _db)
        {
            bool isSuccess = false;
            try
            {
                registration db = new registration
                {
                    slno = model.slno,
                    production_house_name = model.production_house_name,
                    first_name = model.first_name,
                    last_name = model.last_name,
                    dob = model.dob,
                    mobile_number=model.mobile_number,
                    email_id=model.email_id,
                    country=model.country,
                    state=model.state,
                    city=model.city,
                    address1=model.address1,
                    address2=model.address2,
                    pincode=model.pincode,
                    created_date=model.created_date,
                    flag = model.flag
                };
                isSuccess = _db.SaveRegistrationDB(db);
                // Task.Run(()=> _db.SaveTrainingDB(_traningdb));
                return isSuccess;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageRegistration save method: " + ex.Message);
                return isSuccess;
            }

        }
        public List<registration_Model> GetData(DB_registration _db, DB_country_master _Countrymaster,DB_statemaster _Statemaster,DB_city_master _City_Master)
        {
            try
            {
                List<registration_Model> _Model = new List<registration_Model>();
                var restul = _db.Getdata();
                var _country = _Countrymaster.Getdata();
                var _state = _Statemaster.Getdata();
                var _city = _City_Master.Getdata();
                _Model = (from registration in restul
                          join country in _country on registration.country equals country.countrycode
                          join state in _state on registration.state equals state.statecode
                          join city in _city on registration.city equals city.citycode
                          select new registration_Model
                //restul.ForEach(model => _Model.Add(new registration_Model()
                {
                    slno = registration.slno,
                    production_house_name = registration.production_house_name,
                    first_name = registration.first_name,
                    last_name = registration.last_name,
                    dob = registration.dob,
                    mobile_number = registration.mobile_number,
                    email_id = registration.email_id,
                    country = registration.country,
                    state = registration.state,
                    city = registration.city,
                    address1 = registration.address1,
                    address2 = registration.address2,
                    pincode = registration.pincode,
                    created_date = registration.created_date,
                    flag = registration.flag,
                     countryname = country.countryname,
                     statename=state.statename,
                     cityname=city.cityname
                          }).ToList();

                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageRegistrationDB save method: " + ex.Message);
                return null;
            }

        }

    }
}

