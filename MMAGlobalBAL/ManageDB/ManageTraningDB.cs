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
    public class ManageTraningDB
    {
        //private readonly DB_trainingdb _db;
        //public ManageTraningDB(EF_MMADatabaseContext eF_DataContext)
        //{
        //    _db = new DB_trainingdb(eF_DataContext);
        //}


        public bool Save(trainingdb_Model model, DB_trainingdb _db)
        {
            bool isSuccess = false;
            try
            {
                trainingdb _traningdb = new trainingdb
                {
                    id = model.id,
                    name = model.name,
                    age = model.age,
                    address = model.address,
                    salary = model.salary,
                    join_date = model.join_date,
                    flag = model.flag

                };
                isSuccess=_db.SaveTrainingDB(_traningdb);
               // Task.Run(()=> _db.SaveTrainingDB(_traningdb));
                return isSuccess;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageTraningDB save method: " + ex.Message);
                return isSuccess;
            }
         
        }

        public List<trainingdb_Model> GetData(DB_trainingdb _db)
        {
            try
            {
                List<trainingdb_Model> _Model = new List<trainingdb_Model>();
                var restul = _db.Getdata();
                restul.ForEach(model => _Model.Add(new trainingdb_Model()
                {
                    id = model.id,
                    name = model.name,
                    age = model.age,
                    address = model.address,
                    salary = model.salary,
                    join_date = model.join_date,
                    flag = model.flag
                }));
             
                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageTraningDB save method: " + ex.Message);
                return null;
            }

        }

    }
}
