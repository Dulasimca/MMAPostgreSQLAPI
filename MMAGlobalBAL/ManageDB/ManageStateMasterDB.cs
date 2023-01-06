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
    public class ManageStateMasterDb
    {
        /// <summary>
        /// This method will store the state master data in to database. we can use same method for insert and update.
        /// </summary>
        /// <param name="model">we have to send the state master properties with values</param>
        /// <param name="_db">Database connectoin property for state master</param>
        /// <returns>return boolean values. true or false</returns>
        public bool Savestatemaster(state_masterdb model, DB_statemaster _db)
        {
            bool isSuccess = false;
            try
            {
                statemasterdb state_master = new statemasterdb
                {
                    statecode = model.statecode,
                    statename = model.statename,
                    countrycode = model.countrycode,
                    flag = model.flag,

                };
                isSuccess = _db.Savestatemaster(state_master);
                return isSuccess;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageStateMasterDb save method: " + ex.Message);
                return isSuccess;
            }

        }
        public List<state_masterdb> GetData(DB_statemaster _db, DB_country_master _Countrymaster)
        {
            try
            {
                List<state_masterdb> _Model = new List<state_masterdb>();
                var restul = _db.Getdata();
                var _country = _Countrymaster.Getdata();
                _Model = (from state in restul
                          join country in _country on state.countrycode equals country.countrycode
                          select new state_masterdb
                          {
                              statecode = state.statecode,
                              statename = state.statename,
                              countrycode = state.countrycode,
                              flag = state.flag,
                              countryname = country.countryname
                          }).ToList();
                        

               // restul.ForEach(model => _Model.Add(new state_masterdb()
                //{
                   
              //  }));

                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageStateMasterDB save method: " + ex.Message);
                return null;
            }

        }

    }
}

    
