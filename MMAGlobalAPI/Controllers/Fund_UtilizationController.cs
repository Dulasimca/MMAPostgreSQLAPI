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
    public class Fund_UtilizationController : Controller
    {
        private readonly DB_fund_utilization _db;
        private readonly DB_contacts_list _contactslist;
        public Fund_UtilizationController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_fund_utilization(eF_DataContext);
            _contactslist = new DB_contacts_list(eF_DataContext);

        }

        [HttpPost]
        [Route("api/[controller]/Savefund_utilization")]
        public IActionResult Post([FromBody] fund_utilization_model model)
        {
            try
            {
                Manage_fund_utilization _Manage = new Manage_fund_utilization();

                bool isSuccess = _Manage.Save(model, _db);
                return Ok(true);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveFund_utilization : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpGet]
        [Route("api/[controller]/Getfund_utilization")]
        public IActionResult Get()
        {
            try
            {
                Manage_fund_utilization _Manage = new Manage_fund_utilization();

                var result = _Manage.GetData(_db,_contactslist);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("Getprojectcreation : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

       

    }
}