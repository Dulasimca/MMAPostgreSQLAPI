using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using MMAGlobalBAL.Model;
using MMAGlobalDAL.Database.DB_Helper;
using MMAGlobalAPI.common;
using MMAGlobalDAL;

namespace MMAGlobalBAL.ManageDB
{
   public class Manage_shooting_character
    {
        public bool Saveshootingcharacter(shooting_character_model model, DB_shooting_character _db)
        {
            bool isSuccess = false;
            try
            {
                shooting_character shooting_character = new shooting_character
                {
                    character_id = model.character_id,
                    shooting_id = model.shooting_id,
                    contactlist_id = model.contactlist_id,
                    flag = model.flag,
                };
                isSuccess = _db.Saveshootingcharacter(shooting_character);
                return isSuccess;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageCallcharacter save method: " + ex.Message);
                return isSuccess;
            }
        }
        public List<shooting_character_model> GetData(DB_shooting_character _db)
        {
            try
            {
                List<shooting_character_model> _Model = new List<shooting_character_model>();
                var restul = _db.Getdata();
                restul.ForEach(model => _Model.Add(new shooting_character_model()
                {
                    character_id = model.character_id,
                    shooting_id = model.shooting_id,
                    contactlist_id = model.contactlist_id,
                    flag = model.flag,
                })); return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("ManageShootingCharacter save method: " + ex.Message);
                return null;
            }
        }
    }
}
    
