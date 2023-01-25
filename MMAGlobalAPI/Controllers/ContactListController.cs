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
        private readonly DB_country_master _country;
        private readonly DB_statemaster _state;
        private readonly DB_city_master _city;
        private readonly DB_role_master _role;
        private readonly DB_union_masters _union;
        private readonly DB_maincategorymaster _maincategory;
       

        public ContactListController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_contacts_list(eF_DataContext);
            _country = new DB_country_master(eF_DataContext);
            _state = new DB_statemaster(eF_DataContext);
            _city = new DB_city_master(eF_DataContext);
            _role = new DB_role_master(eF_DataContext);
            _union = new DB_union_masters(eF_DataContext);
            _maincategory = new DB_maincategorymaster(eF_DataContext);
    
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

                var result = _Manage.GetData(_db,_country ,_state, _city,_role,_union, _maincategory);
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

