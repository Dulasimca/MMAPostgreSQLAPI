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
                    flag = model.flag,


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
        public List<shooting_schedule_model> GetData(DB_shooting_schedule _db)
        {
            try
            {
                List<shooting_schedule_model> _Model = new List<shooting_schedule_model>();
                var restul = _db.Getdata();
                restul.ForEach(model => _Model.Add(new shooting_schedule_model()
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
                    flag = model.flag,

                }));

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
