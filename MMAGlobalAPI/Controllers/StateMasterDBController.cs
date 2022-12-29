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
    public class StateMasterDBController : ControllerBase
    {

        private readonly DB_statemaster _db;
        public StateMasterDBController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_statemaster(eF_DataContext);
        }

        [HttpPost]
        [Route("api/[controller]/Savestatemaster")]
        public IActionResult Post([FromBody] state_masterdb model)
        {
            try
            {

                ManageStateMasterDb masterDb = new ManageStateMasterDb();
                bool isSuccess = masterDb.Savestatemaster(model, _db);
                return Ok(true);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("Savestatemaster : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetStateMaterDB")]
        public IActionResult Get()
        {
            try
            {
                ManageStateMasterDb _Manage = new ManageStateMasterDb();

                var result = _Manage.GetData(_db);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("GetStateMasterDB : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

    }
}


   