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
    public class SendMailController : Controller
    {
        private readonly DB_send_mail _db;
        public SendMailController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_send_mail(eF_DataContext);
        }
        //[HttpGet]
        //[Route("api/[controller]/GetSendMail")]
        //public IActionResult Get()
        //{
        //    try
        //    {
        //        Manage_send_mail _Manage = new Manage_send_mail();

        //        var result = _Manage.GetData(_db);
        //        return Ok(result);// ResponseHandler.GetAppResponse(type, model));
        //    }
        //    catch (Exception ex)
        //    {
        //        AuditLog.WriteError("GetSendMailDB : " + ex.Message);
        //        return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
        //    }
        //}
    }
}
