using Microsoft.AspNetCore.Mvc;
using System;
using MMAGlobalBAL.Model;
using MMAGlobalBAL.ManageDB;
using MMAGlobalDAL;
using MMAGlobalDAL.Database.DB_Helper;
using MMAGlobalAPI.common;

namespace MMAGlobalAPI.Controllers
{
    [ApiController]
    public class ShootingScheduleController : Controller
    {
        private readonly DB_shooting_schedule _db;
        public ShootingScheduleController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_shooting_schedule(eF_DataContext);
        }

        [HttpPost]
        [Route("api/[controller]/Saveshooting_schedule")]
        public IActionResult Post([FromBody] shooting_schedule_model model)
        {
            try
            {
                Manage_shooting_schedule _Manage = new Manage_shooting_schedule();

                bool isSuccess = _Manage.Save(model, _db);
                return Ok(true);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveShooting_Schedule : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpGet]
        [Route("api/[controller]/Getshooting_schedule")]
        public IActionResult Get()
        {
            try
            {
                Manage_shooting_schedule _Manage = new Manage_shooting_schedule();

                var result = _Manage.GetData(_db);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("Getshootingschedule : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

    }
}
