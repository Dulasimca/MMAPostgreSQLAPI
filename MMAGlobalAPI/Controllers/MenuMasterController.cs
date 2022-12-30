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
    public class MenuMasterController : Controller
    {
        private readonly DB_menu_master _db;
        private readonly DB_role_master _role;
        public MenuMasterController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_menu_master(eF_DataContext);
            _role = new DB_role_master(eF_DataContext);
        }
        [HttpPost]
        [Route("api/[controller]/Savemenumaster")]
        public IActionResult Post([FromBody] menu_master_model model)
        {
            try
            {
                Managemenu_master _Manage = new Managemenu_master();

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
        [Route("api/[controller]/GetMenuMaster")]
        public IActionResult Get()
        {
            try
            {
                Managemenu_master _Manage = new Managemenu_master();

                var result = _Manage.GetData(_db,_role);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("GetmenumasterDB : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
