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
   public class Manage_city_master
    {
        public bool Save(city_master_model model, DB_city_master _db)
        {
            bool isSuccess = false;
            try
            {
                city_master _city_master = new city_master
                {
                    citycode = model.citycode,
                    cityname = model.cityname,
                    countrycode = model.countrycode,
                    statecode = model.statecode,
                    flag = model.flag,
                   

                };
                isSuccess = _db.SaveCityMaster(_city_master);
                return isSuccess;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageCityMaster save method: " + ex.Message);
                return isSuccess;
            }

        }
        public List<city_master_model> GetData(DB_city_master _db)
        {
            try
            {
                List<city_master_model> _Model = new List<city_master_model>();
                var restul = _db.Getdata();
                restul.ForEach(model => _Model.Add(new city_master_model()
                {
                    citycode = model.citycode,
                    cityname = model.cityname,
                    countrycode = model.countrycode,
                    statecode = model.statecode,
                    flag = model.flag,
                }));

                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManagecitymasterDB get method: " + ex.Message);
                return null;
            }

        }
    }
}
