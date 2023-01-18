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
    public class Manage_fund_utilization
    {

        public bool Save(fund_utilization_model model, DB_fund_utilization _db)
        {
            bool isSuccess = false;
            try
            {
                   fund_utilization fund_utilization = new fund_utilization
                     {
                    slno = model.slno,
                    person_name = model.person_name,
                    payment_by = model.payment_by,
                    amount = model.amount,
                    day_or_call = model.day_or_call,
                    total_amount = model.total_amount,
                    created_date = model.created_date,

                };
                isSuccess = _db.SaveFundutilization(fund_utilization);

                return isSuccess;

            }

            catch (Exception ex)
            {
                AuditLog.WriteError("ManageTraningDB save method: " + ex.Message);
                return isSuccess;
            }

        }
        public List<fund_utilization_model> GetData(DB_fund_utilization _db)
        {
            try
            {
                List<fund_utilization_model> _Model = new List<fund_utilization_model>();
                var restul = _db.Getdata();
                restul.ForEach(model => _Model.Add(new fund_utilization_model()
                {
                    slno = model.slno,
                    person_name = model.person_name,
                    payment_by = model.payment_by,
                    amount = model.amount,
                    day_or_call = model.day_or_call,
                    total_amount = model.total_amount,
                    created_date = model.created_date,
                }));

                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("Managefundutilization save method: " + ex.Message);
                return null;
            }

        }

    }
}
