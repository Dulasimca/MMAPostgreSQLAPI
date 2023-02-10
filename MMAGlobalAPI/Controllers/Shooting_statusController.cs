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
    public class Shooting_statusController : Controller
    {
        private readonly DB_shooting_status _db;
        public Shooting_statusController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_shooting_status(eF_DataContext);
        }

        [HttpPost]
        [Route("api/[controller]/Saveshooting_status")]
        public IActionResult Post([FromBody] shooting_status_model model)
        {
            try
            {
                ManageShooting_status _Manage = new ManageShooting_status();

                bool isSuccess = _Manage.Save(model, _db);
                return Ok(true);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveShooting_status : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpGet]
        [Route("api/[controller]/Getshooting_status")]
        public IActionResult Get()
        {
            try
            {
                ManageShooting_status _Manage = new ManageShooting_status();

                var result = _Manage.GetData(_db);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("GetShootingStatus : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

    }
}
