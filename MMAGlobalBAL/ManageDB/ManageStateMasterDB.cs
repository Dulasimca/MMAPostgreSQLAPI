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
        //private readonly DB_trainingdb _db;
        //public ManageTraningDB(EF_MMADatabaseContext eF_DataContext)
        //{
        //    _db = new DB_trainingdb(eF_DataContext);
        //}


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
                    flag = model.flag

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
        public List<state_masterdb> GetData(DB_statemaster _db)
        {
            try
            {
                List<state_masterdb> _Model = new List<state_masterdb>();
                var restul = _db.Getdata();
                restul.ForEach(model => _Model.Add(new state_masterdb()
                {
                    statecode = model.statecode,
                    statename = model.statename,
                    countrycode = model.countrycode,
                    flag = model.flag
                }));

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

    
