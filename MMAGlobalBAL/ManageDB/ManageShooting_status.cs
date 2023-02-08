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
    public class ManageShooting_status
    {

        public bool Save(shooting_status_model model, DB_shooting_status _db)
        {
            bool isSuccess = false;
            try
            {
                shooting_status shooting_Status = new shooting_status
                {
                    slno = model.slno,
                    status = model.status,
                    flag = model.flag

                };
                isSuccess = _db.Saveshootingstatus(shooting_Status);

            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageTraningDB save method: " + ex.Message);
            }
            return isSuccess;
        }

        public List<shooting_status_model> GetData(DB_shooting_status _db)
        {
            try
            {
                List<shooting_status_model> _Model = new List<shooting_status_model>();
                var restul = _db.Getdata();
                restul.ForEach(model => _Model.Add(new shooting_status_model()
                {
                    slno = model.slno,
                    status = model.status,
                    flag = model.flag

                }));

                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageShooting_status save method: " + ex.Message);
                return null;
            }

        }

    }
}
