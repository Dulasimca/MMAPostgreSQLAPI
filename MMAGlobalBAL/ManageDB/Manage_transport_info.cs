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
    public class Manage_transport_info
    {
        // <summary>
        /// This method will store the country master data in to database. we can use same method for insert and update.
        /// </summary>
        /// <param name="model">we have to send the country master properties with values</param>
        /// <param name="_db">Database connectoin property for country master</param>
        /// <returns>return boolean values. true or false</returns>
        public bool Save(transport_info_Model model, DB_transport_info _db)
        {
            bool isSuccess = false;
            try
            {
                transport_info transport_info = new transport_info
                {
                    slno = model.slno,
                    driver_name = model.driver_name,
                    pickup_time =model.pickup_time,
                    pickup_location=model.pickup_location,
                    drop_location=model.drop_location,
                    passenger_id=model.passenger_id,
                    callinfo_id=model.callinfoid,

                };
                isSuccess = _db.Savetransportinfo(transport_info);
                // Task.Run(()=> _db.SaveTrainingDB(_traningdb));
                return isSuccess;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("Managetransportinfo save method: " + ex.Message);
                return isSuccess;
            }

        }
        public List<transport_info_Model> GetData(DB_transport_info _db,DB_contacts_list _contact)
        {
            try
            {
                List<transport_info_Model> _Model = new List<transport_info_Model>();
                var restul = _db.Getdata();
                var _passenger = _contact.Getdata();
                _Model = (from model in restul
                          join passengername in _passenger on model.passenger_id equals passengername.slno
                          select new transport_info_Model
                //restul.ForEach(model => _Model.Add(new transport_info_Model()
                {
                    slno = model.slno,
                    driver_name = model.driver_name,
                    pickup_time = model.pickup_time,
                    pickup_location = model.pickup_location,
                    drop_location = model.drop_location,
                    passenger_id = model.passenger_id,
                    callinfoid=model.callinfo_id,
                    passengername = passengername.first_name
                          }).
                ToList();

                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageTransportinfoDB save method: " + ex.Message);
                return null;
            }
        }
    }
}
    
