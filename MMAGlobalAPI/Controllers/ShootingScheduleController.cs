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
        private readonly DB_maincategorymaster _maincategory;
        private readonly DB_subcategorymasterdb _subcategory;
        private readonly DB_shooting_status _Shooting_Status;
        private readonly DB_projectcreation _Projectcreation;
        private readonly DB_shooting_character _dbchar;
        public ShootingScheduleController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_shooting_schedule(eF_DataContext);
            _maincategory = new DB_maincategorymaster(eF_DataContext);
            _subcategory = new DB_subcategorymasterdb(eF_DataContext);
            _Shooting_Status = new DB_shooting_status(eF_DataContext);
            _Projectcreation = new DB_projectcreation(eF_DataContext);
            _dbchar = new DB_shooting_character(eF_DataContext);


        }

        [HttpPost]
        [Route("api/[controller]/Saveshooting_schedule")]
        public IActionResult Post([FromBody] shootingcharacterdetails_Model model)
        {
            try
            {
                Manage_shooting_schedule _Manage = new Manage_shooting_schedule();

                bool isSuccess = _Manage.Save(model, _db, _dbchar);
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

                var result = _Manage.GetData(_db, _maincategory, _subcategory,_Shooting_Status,_Projectcreation);
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
