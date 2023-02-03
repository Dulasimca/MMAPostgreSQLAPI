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
                    project_name = model.project_name,
                    budget_amount = model.budget_amount,
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
        public List<fund_utilization_model> GetData(DB_fund_utilization _db, DB_contacts_list _contactslist)
        {
            try
            {
                List<fund_utilization_model> _Model = new List<fund_utilization_model>();
                var restul = _db.Getdata();
                var _contact = _contactslist.Getdata();
                //  restul.ForEach(model => _Model.Add(new fund_utilization_model()
                _Model = (from fund_utilization in restul
                          join person_name in _contact on fund_utilization.person_name equals person_name.slno
                          select new fund_utilization_model
                          {
                              slno = fund_utilization.slno,
                              project_name = fund_utilization.project_name,
                              budget_amount = fund_utilization.budget_amount,
                              person_name = fund_utilization.person_name,
                              payment_by = fund_utilization.payment_by,
                              amount = fund_utilization.amount,
                              day_or_call = fund_utilization.day_or_call,
                              total_amount = fund_utilization.total_amount,
                              created_date = fund_utilization.created_date,
                              first_name=person_name.first_name,
                          }).ToList();

                //}));

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
