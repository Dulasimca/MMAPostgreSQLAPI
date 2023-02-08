using Microsoft.AspNetCore.Mvc;
using System;
using MMAGlobalBAL.Model;
using MMAGlobalBAL.ManageDB;
using MMAGlobalDAL;
using MMAGlobalDAL.Database.DB_Helper;
using MMAGlobalAPI.common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMAGlobalAPI.Controllers
{
    [ApiController]
    public class ShootingCharacterController : Controller
    {
        private readonly DB_shooting_character _db;
        public ShootingCharacterController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_shooting_character(eF_DataContext);
        }
        [HttpPost]
        [Route("api/[controller]/Saveshootingcharacter")]
        public IActionResult Post([FromBody] shooting_character_model model)
        {
            try
            {
                Manage_shooting_character _Manage = new Manage_shooting_character(); bool isSuccess = _Manage.Saveshootingcharacter(model, _db);
                return Ok(true);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveCasetypeMaster : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpGet]
        [Route("api/[controller]/Getshootingcharacter")]
        public IActionResult Get()
        {
            try
            {
                Manage_shooting_character _Manage = new Manage_shooting_character();
                var result = _Manage.GetData(_db);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("Getcallcharacter : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}