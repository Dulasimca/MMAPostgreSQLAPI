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
   public class Manageunion_masters
    {
        public bool Save(union_masters_model model, DB_union_masters _db)
        {
            bool isSuccess = false;
            try
            {
                union_masters _union_masters = new union_masters
                {
                    sino = model.sino,
                    unionname = model.unionname,
                    registernumber = model.registernumber,
                    flag = model.flag

                };
                isSuccess = _db.SaveUnionMaster(_union_masters);
                return isSuccess;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageTraningDB save method: " + ex.Message);
                return isSuccess;
            }

        }
        public List<union_masters_model> GetData(DB_union_masters _db)
        {
            try
            {
                List<union_masters_model> _Model = new List<union_masters_model>();
                var restul = _db.Getdata();
                restul.ForEach(model => _Model.Add(new union_masters_model()
                {
                    sino = model.sino,
                    unionname = model.unionname,
                    registernumber = model.registernumber,
                    flag = model.flag
                }));

                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageunionDB get method: " + ex.Message);
                return null;
            }

        }
    }
}
