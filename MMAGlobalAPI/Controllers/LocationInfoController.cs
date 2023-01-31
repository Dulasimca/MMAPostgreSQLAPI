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
    public class LocationInfoController : Controller
    {
        private readonly DB_location_info _db;
        private readonly DB_country_master _country;
        private readonly DB_statemaster _state;
        private readonly DB_city_master _city;
        private readonly DB_contacts_list _Contacts_List;
        public LocationInfoController(EF_MMADatabaseContext eF_DataContext)
        {
            _db = new DB_location_info(eF_DataContext);
            _country = new DB_country_master(eF_DataContext);
            _state = new DB_statemaster(eF_DataContext);
            _city = new DB_city_master(eF_DataContext);
            _Contacts_List = new DB_contacts_list(eF_DataContext);
        }
        [HttpPost]
        [Route("api/[controller]/SaveLocationInfo")]
        public IActionResult Post([FromBody] location_info_model model)
        {
            try
            {
                Manage_location_info _Manage = new Manage_location_info();

                bool isSuccess = _Manage.Save(model, _db);
                return Ok(true);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("SaveLocationInfo : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpGet]
        [Route("api/[controller]/GetLocationInfo")]
        public IActionResult Get()
        {
            try
            {
                Manage_location_info _Manage = new Manage_location_info();

                var result = _Manage.GetData(_db, _country, _state, _city, _Contacts_List);
                return Ok(result);// ResponseHandler.GetAppResponse(type, model));
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("LocationInfoGet : " + ex.Message);
                return BadRequest(false); //ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
