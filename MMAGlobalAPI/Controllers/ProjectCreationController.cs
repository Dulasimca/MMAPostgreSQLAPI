using Microsoft.AspNetCore.Mvc;
using System;
using MMAGlobalBAL.Model;
using MMAGlobalBAL.ManageDB;
using MMAGlobalDAL;
using MMAGlobalDAL.Database.DB_Helper;
using MMAGlobalAPI.common;

namespace MMAGlobalAPI.Controllers
{
    public class ProjectCreationController : Controller
    {
        private readonly DB_projectcreation _db;
        public ProjectCreationController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_projectcreation(eF_DataContext);
        }

        [HttpPost]
        [Route("api/[controller]/Saveproject_creation")]
        public IActionResult Post([FromBody] project_creation_model model)
        {
            try
            {
                Manage_project_creation _Manage = new Manage_project_creation();

                bool isSuccess = _Manage.Save(model, _db);
                return Ok(true);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveProjectCreation : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetprojectCreation")]
        public IActionResult Get()
        {
            try
            {
                Manage_project_creation _Manage = new Manage_project_creation();

                var result = _Manage.GetData(_db);
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