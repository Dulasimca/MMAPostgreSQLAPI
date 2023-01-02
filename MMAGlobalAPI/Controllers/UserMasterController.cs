using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MMAGlobalBAL.Model;
using MMAGlobalBAL.ManageDB;
using MMAGlobalDAL;
using MMAGlobalDAL.Database.DB_Helper;
using MMAGlobalAPI.common;

namespace MMAGlobalAPI.Controllers
{
    [ApiController]
    public class UserMasterController : Controller
    {
        private readonly DB_user_master _db;
        private readonly DB_role_master _role;
        public UserMasterController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_user_master(eF_DataContext);
            _role = new DB_role_master(eF_DataContext);
        }
        [HttpPost]
        [Route("api/[controller]/SaveUserMaster")]
        public IActionResult Post([FromBody] user_master_model model)
        {
            try
            {
                Manage_user_master _Manage = new Manage_user_master();

                bool isSuccess = _Manage.Save(model, _db);
                return Ok(true);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveUserMaster : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetUserMaster")]
        public IActionResult Get()
        {
            try
            {
                Manage_user_master _Manage = new Manage_user_master();

                var result = _Manage.GetData(_db, _role);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("GetUserMasterDB : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

    }
}
