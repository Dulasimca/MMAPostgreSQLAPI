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
    public class RolemasterController : Controller
    {
        private readonly DB_role_master _db;
        public RolemasterController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_role_master(eF_DataContext);
        }

        [HttpPost]
        [Route("api/[controller]/SaveRolemaster")]
        public IActionResult Post([FromBody] role_master_Model model)
        {
            try
            {
                ManageRolemaster _Manage = new ManageRolemaster();

                bool isSuccess = _Manage.Save(model,_db);
                return Ok(true);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveCasetypeMaster : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

    }
}

