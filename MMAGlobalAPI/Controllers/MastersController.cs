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
    public class MasterController : Controller
    {
        private readonly DB_masters _db;

        public MasterController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_masters(eF_DataContext);
        }


        [HttpGet]
        [Route("api/[controller]/Getmasters")]
        public IActionResult Get()
        {
            try
            {
                Managemasters _Manage = new Managemasters();
                var result = _Manage.GetData(_db);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("Getmaster : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}

