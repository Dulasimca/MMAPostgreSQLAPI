using System;
using System.Collections.Generic;
using System.Linq;
using MMAGlobalDAL.Database.DB_Entity;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalDAL.Database.DB_Helper
{
    public class DB_registration
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_registration(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public bool SaveRegistrationDB(registration registration)

        {
            bool isSuccess = false;
            try
            {
                // trainingdb.id = (_DataContext.trainingdb.Max(u => u.id)) + 1;
                _DataContext.registration.Add(registration);
                if (registration.production_id > 0)
                {
                    _DataContext.Entry(registration).State = EntityState.Modified;
                }
                _DataContext.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSuccess;
        }

        public bool UpdateStatus(registration registration)

        {
            bool isSuccess = false;
            try
            {
                // trainingdb.id = (_DataContext.trainingdb.Max(u => u.id)) + 1;
              var result =  _DataContext.registration.Where(a=> a.production_id== registration.production_id).FirstOrDefault();
              
                if(result !=null)
                {
                    result.approvalstatus = registration.approvalstatus;
                }
              _DataContext.SaveChanges();

                if (result.approvalstatus == 1)
                {
                    user_master user = new user_master
                    {
                        username_emailid = result.email_id,
                        roleid=2,
                        password = "cHbJet7yXQohaZQH0OkFnw==",
                        flag=true
                    };
                    DB_user_master users = new DB_user_master(_DataContext);
                    users.SaveUserMasterForApproval(user);
                }

                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSuccess;
        }
        public List<registration> Getdata()
        {
            return _DataContext.registration.ToList();
        }
    }
}
