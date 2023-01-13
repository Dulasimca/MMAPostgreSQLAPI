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
    public class RegistrationController : Controller
    {
        private readonly DB_registration _db;
        private readonly DB_country_master _country;
        private readonly DB_statemaster _state;
        private readonly DB_city_master _city;
        public RegistrationController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_registration(eF_DataContext);
            _country = new DB_country_master(eF_DataContext);
            _state = new DB_statemaster(eF_DataContext);
            _city = new DB_city_master(eF_DataContext);
        }

        [HttpPost]
        [Route("api/[controller]/SaveRegistration")]
        public IActionResult Post([FromBody] registration_Model model)
        {
            try
            {
                ManageRegistration _Manage = new ManageRegistration();

                bool isSuccess = _Manage.Save(model, _db);
                return Ok(true);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveRegistration : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetRegistration")]
        public IActionResult Get()
        {
            try
            {
                ManageRegistration _Manage = new ManageRegistration();

                var result = _Manage.GetData(_db,_country,_state,_city);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("GetRegistration : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

    }
}


