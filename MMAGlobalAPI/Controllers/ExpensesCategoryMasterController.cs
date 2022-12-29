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
    public class ExpensesCategoryMasterController : Controller
    {
        private readonly DB_expensescategory_master _db;
        public ExpensesCategoryMasterController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_expensescategory_master(eF_DataContext);
        }
        [HttpPost]
        [Route("api/[controller]/SavemenumasterDB")]
        public IActionResult Post([FromBody] expensescategory_master_model model)
        {
            try
            {
                Manage_expensescategory_master _Manage = new Manage_expensescategory_master();

                bool isSuccess = _Manage.Save(model, _db);
                return Ok(true);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveExpensesCategoryMaster : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetexpencesmasterDB")]
        public IActionResult Get()
        {
            try
            {
                Manage_expensescategory_master _Manage = new Manage_expensescategory_master();

                var result = _Manage.GetData(_db);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("GetTrainingDB : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
