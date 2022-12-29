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
    public class ManageCountrymaster
    {
        public bool Save(country_master_Model model, DB_country_master _db)
        {
            bool isSuccess = false;
            try
            {
                country_master db = new country_master
                {
                    countrycode = model.countrycode,
                    countryname = model.countryname,
                    flag = model.flag
                };
                isSuccess = _db.SaveCountrymasterDB(db);
                // Task.Run(()=> _db.SaveTrainingDB(_traningdb));
                return isSuccess;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageCountrymaster save method: " + ex.Message);
                return isSuccess;
            }

        }
        public List<country_master_Model> GetData(DB_country_master _db)
        {
            try
            {
                List<country_master_Model> _Model = new List<country_master_Model>();
                var restul = _db.Getdata();
                restul.ForEach(model => _Model.Add(new country_master_Model()
                {
                    countrycode = model.countrycode,
                    countryname = model.countryname,
                    flag = model.flag
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