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
    public class DailyexpensesController : Controller
    {
        private readonly DB_daily_expenses _db;
        private readonly DB_expensescategory_master _dailyexpenses;
        public DailyexpensesController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_daily_expenses(eF_DataContext);
            _dailyexpenses = new DB_expensescategory_master(eF_DataContext);
        }

        [HttpPost]
        [Route("api/[controller]/SaveDailyexpenses")]
        public IActionResult Post([FromBody] daily_expenses_Model model)
        {
            try
            {
                Manage_daily_expenses _Manage = new Manage_daily_expenses();

                bool isSuccess = _Manage.Save(model, _db);
                return Ok(true);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveDailyexpenses : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetDailyexpenses")]
        public IActionResult Get()
        {
            try
            {
                Manage_daily_expenses _Manage = new Manage_daily_expenses();
                var result = _Manage.GetData(_db, _dailyexpenses);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("Getdailyexpenses : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
