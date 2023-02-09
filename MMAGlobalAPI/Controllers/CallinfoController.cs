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
    public class CallinfoController : Controller
    {
        private readonly DB_call_info _db;
        private readonly DB_lodging_info _dbloding;
        private readonly DB_transport_info _dbtransport;
        private readonly DB_call_character _dbCall;
        private readonly DB_projectcreation _dailyprojectname;
        private readonly DB_role_master _rolemaster;
        private readonly DB_maincategorymaster _Maincategorymaster;
        public CallinfoController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_call_info(eF_DataContext);
            _dbCall = new DB_call_character(eF_DataContext);
            _dbloding = new DB_lodging_info(eF_DataContext);
            _dbtransport = new DB_transport_info(eF_DataContext);
            _dailyprojectname = new DB_projectcreation(eF_DataContext);
            _rolemaster = new DB_role_master(eF_DataContext);
            _Maincategorymaster = new DB_maincategorymaster(eF_DataContext);
        }

        [HttpPost]
        [Route("api/[controller]/SaveCallinfo")]
        public IActionResult Post([FromBody] callinfodetails_Model model)
        {
            try
            {
                Manage_call_info _Manage = new Manage_call_info();

                bool isSuccess = _Manage.Save(model, _db, _dbloding,_dbtransport, _dbCall);
                return Ok(true);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveCasetypeMaster : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetCallinfo")]
        public IActionResult Get()
        {
            try
            {
                Manage_call_info _Manage = new Manage_call_info();
                var result = _Manage.GetData(_db, _dailyprojectname, _rolemaster, _Maincategorymaster);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("GetCallinfo : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}

