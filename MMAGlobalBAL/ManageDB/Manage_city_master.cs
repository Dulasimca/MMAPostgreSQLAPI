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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="_db"></param>
        /// <returns></returns>
        public bool Save(city_master_model model, DB_city_master _db)
        {
            bool isSuccess = false;
            try
            {
                city_master _city_master = new city_master
                {
                    citycode = model.citycode,
                    cityname = model.cityname,
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
        public List<city_master_model> GetData(DB_city_master _db,DB_statemaster _Statemaster)
        {
            try
            {
                List<city_master_model> _Model = new List<city_master_model>();
                var result = _db.Getdata();
                var _state = _Statemaster.Getdata();
                _Model = (from city in result
                             join state in _state on city.statecode equals state.statecode
                             select new city_master_model
                             {
                                 citycode = city.citycode,
                                 cityname = city.cityname,
                                 statecode = city.statecode,
                                 flag = city.flag,
                                 statename =state.statename
                             }).ToList();

                //result.ForEach(model => _Model.Add(new city_master_model()
                //{
                    
                //}));

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
