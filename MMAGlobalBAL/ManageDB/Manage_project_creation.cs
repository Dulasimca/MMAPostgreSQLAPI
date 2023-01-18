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
   public class Manage_project_creation
    {

        public bool Save(project_creation_model model, DB_projectcreation _db)
        {
            bool isSuccess = false;
            try
            {
                project_creation project_creation = new project_creation
                {
                    slno = model.slno,
                    project_name = model.project_name,
                    duration_in_days = model.duration_in_days,
                    budget = model.budget,
                    project_start_date = model.project_start_date,
                    created_date = model.created_date,
                    flag = model.flag

                };
                isSuccess = _db.SaveProjectCreation(project_creation);

                return isSuccess;

            }

            catch (Exception ex)
            {
                AuditLog.WriteError("ManageTraningDB save method: " + ex.Message);
                return isSuccess;
            }

        }
        public List<project_creation_model> GetData(DB_projectcreation _db)
        {
            try
            {
                List<project_creation_model> _Model = new List<project_creation_model>();
                var restul = _db.Getdata();
                restul.ForEach(model => _Model.Add(new project_creation_model()
                {
                    slno = model.slno,
                    project_name = model.project_name,
                    duration_in_days = model.duration_in_days,
                    budget = model.budget,
                    project_start_date = model.project_start_date,
                    created_date = model.created_date,
                    flag = model.flag
                }));

                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("Manageprojectcreation save method: " + ex.Message);
                return null;
            }

        }

    }
}
