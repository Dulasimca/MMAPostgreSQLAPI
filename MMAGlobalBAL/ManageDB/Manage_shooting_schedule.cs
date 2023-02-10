using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using MMAGlobalBAL.Model;
using MMAGlobalDAL.Database.DB_Helper;
using MMAGlobalAPI.common;
using MMAGlobalDAL;
using System.Linq;



namespace MMAGlobalBAL.ManageDB
{
    public class Manage_shooting_schedule
    {
        /// <summary>
        /// This method will store the main category master data in to database. we can use same method for insert and update.
        /// </summary>
        /// <param name="model">we have to send the main category master properties with values</param>
        /// <param name="_db">Database connectoin property for main category master</param>
        /// <returns>return boolean values. true or false</returns>
        /// 
        public bool Save(shootingcharacterdetails_Model model, DB_shooting_schedule _db,DB_shooting_character _dbchar)
        {
            bool isSuccess = false;
            try
            {
                shooting_schedule shooting_schedule = new shooting_schedule
                {
                    slno = model.shooting_Schedule.slno,
                    project_id = model.shooting_Schedule.project_id,
                    scene = model.shooting_Schedule.scene,
                    interior_exterior = model.shooting_Schedule.interior_exterior,
                    day_night = model.shooting_Schedule.day_night,
                    schedule_day = model.shooting_Schedule.schedule_day,
                    schedule_date = model.shooting_Schedule.schedule_date,
                    status_id = model.shooting_Schedule.status_id,
                    main_category_id = model.shooting_Schedule.main_category_id,
                    sub_category_id = model.shooting_Schedule.sub_category_id,
                    created_date = model.shooting_Schedule.created_date,
                    flag = model.shooting_Schedule.flag,
                };
                //int shooting_id = _db.Saveshooting_schedule(shooting_schedule);
                
                //isSuccess = _db.Saveshootingschedule(shooting_schedule);
                int shootingid = _db.Saveshooting_schedule(shooting_schedule);

               foreach (int item in model.contactusid)
                {
                    shooting_character _character = new shooting_character
                    {
                        shooting_id = shootingid,
                        contactlist_id = item,
                        flag = true
                    };
                    _dbchar.Saveshootingcharacter(_character);
                }
                return isSuccess;

            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageTraningDB save method: " + ex.Message);
                return isSuccess;
            }
        }
                public List<shooting_schedule_model> GetData(DB_shooting_schedule _db, DB_maincategorymaster _Maincategorymaster, DB_subcategorymasterdb _subcategorymaster, DB_shooting_status _Shooting_Status, DB_projectcreation _project_name)
            {
                try
                {
                    List<shooting_schedule_model> _Model = new List<shooting_schedule_model>();
                    var result  = _db.Getdata();
                    var _maincategory = _Maincategorymaster.Getdata();
                    var _subcategory = _subcategorymaster.Getdata();
                    var _shootingstatus = _Shooting_Status.Getdata();
                    var _projectname = _project_name.Getdata();

                _Model = (from shooting_schedule in result
                          join main_category_id in _maincategory on shooting_schedule.main_category_id equals main_category_id.sino
                          join sub_category_id in _subcategory on shooting_schedule.sub_category_id equals sub_category_id.sino
                          join status_id in _shootingstatus on shooting_schedule.status_id equals status_id.slno
                          join projectname in _projectname on shooting_schedule.project_id equals projectname.project_id
                          select new shooting_schedule_model
                          {
                        slno = shooting_schedule.slno,
                        project_id = shooting_schedule.project_id,
                        scene = shooting_schedule.scene,
                        interior_exterior = shooting_schedule.interior_exterior,
                        day_night = shooting_schedule.day_night,
                        schedule_day = shooting_schedule.schedule_day,
                        schedule_date = shooting_schedule.schedule_date,
                        status_id = shooting_schedule.status_id,
                        main_category_id = shooting_schedule.main_category_id,
                        sub_category_id = shooting_schedule.sub_category_id,
                        created_date = shooting_schedule.created_date,
                        flag = shooting_schedule.flag,
                        maincategoryname=main_category_id.categoryname,
                        subcategoryname=sub_category_id.categoryname,
                        shooting_status= status_id.status,
                        project_name = projectname.project_name,

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
