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
    public class MainCategoryMasterController : Controller
    {

        private readonly DB_maincategorymaster _db;
        public MainCategoryMasterController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_maincategorymaster(eF_DataContext);
        }

        [HttpPost]
        [Route("api/[controller]/Savemaincategory_master")]
        public IActionResult Post([FromBody] maincategorymaster_Model model)
        {
            try
            {
                ManageMainCategoryMasterDB _Manage = new ManageMainCategoryMasterDB();

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
        [Route("api/[controller]/GetMaincategorymaster")]
        public IActionResult Get()
        {
            try
            {
                ManageMainCategoryMasterDB _Manage = new ManageMainCategoryMasterDB();

                var result = _Manage.GetData(_db);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("GetMaincategorymaster : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

    }
}
