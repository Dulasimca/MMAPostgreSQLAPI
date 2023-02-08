using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using Microsoft.EntityFrameworkCore;
namespace MMAGlobalDAL.Database.DB_Helper
{ 
   public class DB_shooting_character
{ 
        private EF_MMADatabaseContext _DataContext;
        public DB_shooting_character(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public bool Saveshootingcharacter(shooting_character shooting_character)
        {
            bool isSuccess = false;
            try
            {
                // trainingdb.id = (_DataContext.trainingdb.Max(u => u.id)) + 1;
                _DataContext.shooting_character.Add(shooting_character);
                if (shooting_character.character_id > 0)
                {
                    _DataContext.Entry(shooting_character).State = EntityState.Modified;
                }
                _DataContext.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return isSuccess;
        }
        public List<shooting_character> Getdata()
        {
            return _DataContext.shooting_character.ToList();
        }
    }
}
