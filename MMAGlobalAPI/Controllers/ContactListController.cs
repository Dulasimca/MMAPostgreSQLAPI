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
    public class ContactListController : Controller
    {

        private readonly DB_contacts_list _db;
        public ContactListController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_contacts_list(eF_DataContext);
        }

        [HttpPost]
        [Route("api/[controller]/Savecontactlist")]
        public IActionResult Post([FromBody] contacts_list_model model)
        {
            try
            {
                Manage_contacts_list _Manage = new Manage_contacts_list();

                bool isSuccess = _Manage.Save(model, _db);
                return Ok(true);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveContactlist : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpGet]
        [Route("api/[controller]/Getcontactlist")]
        public IActionResult Get()
        {
            try
            {
                Manage_contacts_list _Manage = new Manage_contacts_list();

                var result = _Manage.GetData(_db);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("Getcontactlist : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

    }
}

