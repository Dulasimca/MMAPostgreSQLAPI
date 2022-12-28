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
    public class TraningDBController : ControllerBase
    {

        private readonly DB_trainingdb _db;
        public TraningDBController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_trainingdb(eF_DataContext);
        }

        [HttpPost]
        [Route("api/[controller]/SaveTrainingDB")]
        public IActionResult Post([FromBody] trainingdb_Model model)
        {
            try
            {
                ManageTraningDB _Manage = new ManageTraningDB();

                bool isSuccess = _Manage.Save(model, _db);
                return Ok(true);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveTrainingDB : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetTrainingDB")]
        public IActionResult Get()
        {
            try
            {
                ManageTraningDB _Manage = new ManageTraningDB();

                var result= _Manage.GetData(_db);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("GetTrainingDB : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

    }
}
