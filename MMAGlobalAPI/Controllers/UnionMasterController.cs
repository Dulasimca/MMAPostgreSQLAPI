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
    public class UnionMasterController : Controller
    {
        private readonly DB_union_masters _db;
        public UnionMasterController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_union_masters(eF_DataContext);
        }
        [HttpPost]
        [Route("api/[controller]/SaveunionmasterDB")]
        public IActionResult Post([FromBody] union_masters_model model)
        {
            try
            {
                Manageunion_masters _Manage = new Manageunion_masters();

                bool isSuccess = _Manage.Save(model, _db);
                return Ok(true);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveUnionMaster : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetUnionMaster")]
        public IActionResult Get()
        {
            try
            {
                Manageunion_masters _Manage = new Manageunion_masters();

                var result = _Manage.GetData(_db);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("GetunionmasterDB : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
