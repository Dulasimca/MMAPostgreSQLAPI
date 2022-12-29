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
    public class CityMasterController : Controller
    {
        private readonly DB_city_master _db;
        public CityMasterController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_city_master(eF_DataContext);
        }
        [HttpPost]
        [Route("api/[controller]/SaveCityMasterDB")]
        public IActionResult Post([FromBody] city_master_model model)
        {
            try
            {
                Manage_city_master _Manage = new Manage_city_master();

                bool isSuccess = _Manage.Save(model, _db);
                return Ok(true);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveMenuMaster : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetcitymasterDB")]
        public IActionResult Get()
        {
            try
            {
                Manage_city_master _Manage = new Manage_city_master();

                var result = _Manage.GetData(_db);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("GetcitymasterDB : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
