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
    public class TransportinfoController : Controller
    {
        private readonly DB_transport_info _db;
        public TransportinfoController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_transport_info(eF_DataContext);
        }

        [HttpPost]
        [Route("api/[controller]/Savetransportinfo")]
        public IActionResult Post([FromBody] transport_info_Model model)
        {
            try
            {
                Manage_transport_info _Manage = new Manage_transport_info();

                bool isSuccess = _Manage.Save(model, _db);
                return Ok(true);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveCasetypeMaster : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet]
        [Route("api/[controller]/Gettransportinfo")]
        public IActionResult Get()
        {
            try
            {
                Manage_transport_info _Manage = new Manage_transport_info();
                var result = _Manage.GetData(_db);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("Gettransportinfo : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}


