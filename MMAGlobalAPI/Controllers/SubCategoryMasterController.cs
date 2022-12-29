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
    public class SubCategoryMasterController : Controller
    {

        private readonly DB_subcategorymasterdb _db;
        public SubCategoryMasterController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_subcategorymasterdb(eF_DataContext);
        }

        [HttpPost]
        [Route("api/[controller]/Savesub_category")]
        public IActionResult Post([FromBody] subcategorymaster_Model model)
        {
            try
            {
                ManageSubCategoryMasterDB _Manage = new ManageSubCategoryMasterDB();

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
        [Route("api/[controller]/Getsubcategorymaster")]
        public IActionResult Get()
        {
            try
            {
                ManageSubCategoryMasterDB _Manage = new ManageSubCategoryMasterDB();

                var result = _Manage.GetData(_db);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("Getsubcategorymaster : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

    }
}
