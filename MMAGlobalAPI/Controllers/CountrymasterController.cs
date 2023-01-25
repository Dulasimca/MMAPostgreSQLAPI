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
    public class CountrymasterController : Controller
    {
        private readonly DB_country_master _db;
        public CountrymasterController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_country_master(eF_DataContext);
        }

        [HttpPost]
        [Route("api/[controller]/SaveCountrymaster")]
        public IActionResult Post([FromBody] country_master_Model model)
        {
            try
            {
                ManageCountrymaster _Manage = new ManageCountrymaster();

                bool isSuccess = _Manage.Save(model, _db);
                return Ok(true);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveCountrymaster : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetCountrymaster")]
        public IActionResult Get()
        {
            try
            {
                ManageCountrymaster _Manage = new ManageCountrymaster();
                var result = _Manage.GetData(_db);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("GetCountrymaster : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}

