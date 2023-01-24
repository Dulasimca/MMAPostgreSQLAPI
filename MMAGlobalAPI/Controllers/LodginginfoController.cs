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
    public class LodginginfoController : Controller
    {
        private readonly DB_lodging_info _db;
        public LodginginfoController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_lodging_info(eF_DataContext);
        }

        [HttpPost]
        [Route("api/[controller]/SaveLodginginfo")]
        public IActionResult Post([FromBody] lodging_info_Model model)
        {
            try
            {
                Manage_lodging_info _Manage = new Manage_lodging_info();

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
        [Route("api/[controller]/Getlodginginfo")]
        public IActionResult Get()
        {
            try
            {
                Manage_lodging_info _Manage = new Manage_lodging_info();
                var result = _Manage.GetData(_db);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("Getlodginginfo : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}

