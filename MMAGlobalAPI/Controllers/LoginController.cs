using Microsoft.AspNetCore.Mvc;
using MMAGlobalBAL.Model;
using MMAGlobalDAL.Database.DB_Helper;
using MMAGlobalAPI.common;
using System;
using MMAGlobalDAL.Database;
using MMAGlobalDAL;
using CommonUtilities;
using MMAGlobalBAL.ManageDB;

namespace MMAGlobalAPI.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DB_user_master _db;
        public LoginController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_user_master(eF_DataContext);
       
        }
        [HttpGet]
        [Route("api/[controller]/GetUserMasterByName")]
        public Tuple<bool, string, user_master_model> GetLogin(string username, string password)
        {
      
            try
            {
                Manage_user_master _User_Master = new Manage_user_master();
                var _user = _User_Master.GetUserMasterByName(_db,username);
                if (_user == null)
                {
                    return new Tuple<bool, string, user_master_model>(false, "Username mismatch", _user);
                }
                else
                {
                    Security _security = new Security();
                    if (_security.Encryptword(password) == _user.password)
                    {
                        return new Tuple<bool, string, user_master_model>(true, "Success", _user);
                    }
                    else
                    {
                        return new Tuple<bool, string, user_master_model>(false, "Password mismatch", _user);
                    }
                }
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("GetLogin : " + ex.Message);
                return new Tuple<bool, string, user_master_model>(false, "Username mismatch", null);
            }
        }
    }
}
