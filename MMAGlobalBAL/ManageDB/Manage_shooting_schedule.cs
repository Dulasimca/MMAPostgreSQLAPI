using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using MMAGlobalBAL.Model;
using MMAGlobalDAL.Database.DB_Helper;
using MMAGlobalAPI.common;
namespace MMAGlobalBAL.ManageDB
{
   public  class Manage_shooting_schedule
    {

        public bool Save(shooting_schedule_model model, DB_shooting_schedule _db)
        {
            bool isSuccess = false;
            try
            {
                shooting_schedule shooting_schedule = new shooting_schedule
                {
                    slno = model.slno,
                    project_name = model.project_name,
                    role_id = model.role_id,
                    main_category_id = model.main_category_id,
                    sub_category_id = model.sub_category_id,
                    phone_number = model.phone_number,
                    date = model.date,
                    schedule_day = model.schedule_day,
                    schedule_date = model.schedule_date,
                    day_night = model.day_night,
                    interior_exterior = model.interior_exterior,
                    scene = model.scene,
                    characters = model.characters,
                    status = model.status,
                    created_date = model.created_date,
                    name = model.name,

                };
                isSuccess = _db.Saveshootingschedule(shooting_schedule);

                return isSuccess;

            }

            catch (Exception ex)
            {
                AuditLog.WriteError("ManageTraningDB save method: " + ex.Message);
                return isSuccess;
            }

        }
        public List<shooting_schedule_model> GetData(DB_shooting_schedule _db, DB_role_master _rolemaster,DB_maincategorymaster _Maincategorymaster

)
        {
            try
            {
                List<shooting_schedule_model> _Model = new List<shooting_schedule_model>();
                var result = _db.Getdata();
                var _role = _rolemaster.Getdata();
                var _maincategory = _Maincategorymaster.Getdata();
                _Model = (from shooting in result
                          join role_id in _role on shooting.role_id equals role_id.roleid
                          join main_category_id in _maincategory on shooting.main_category_id equals main_category_id.sino
                          select new shooting_schedule_model

                          // restul.ForEach(model => _Model.Add(new shooting_schedule_model()
                          {
                              slno = shooting.slno,
                              project_name = shooting.project_name,
                              role_id = shooting.role_id,
                              main_category_id = shooting.main_category_id,
                              sub_category_id = shooting.sub_category_id,
                              phone_number = shooting.phone_number,
                              date = shooting.date,
                              schedule_day = shooting.schedule_day,
                              schedule_date = shooting.schedule_date,
                              day_night = shooting.day_night,
                              interior_exterior = shooting.interior_exterior,
                              scene = shooting.scene,
                              characters = shooting.characters,
                              status = shooting.status,
                              created_date = shooting.created_date,
                              name = shooting.name,
                              rolename = role_id.rolename,
                              categoryname=main_category_id.categoryname,
                          }).ToList();
                

                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("Manageshootingschedule save method: " + ex.Message);
                return null;
            }

        }

    }
}
