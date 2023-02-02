using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MMAGlobalDAL.Database.DB_Entity;


namespace MMAGlobalDAL.Database.DB_Helper
{
    public class DB_projectcreation
    {
        private EF_MMADatabaseContext _DataContext;
        public DB_projectcreation(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public bool SaveProjectCreation(project_creation projectcreation)

        {
            bool isSuccess = false;
            try
            {
                // trainingdb.id = (_DataContext.trainingdb.Max(u => u.id)) + 1;
                _DataContext.projectcreation.Add(projectcreation);
                if (projectcreation.project_id > 0)
                {
                    _DataContext.Entry(projectcreation).State = EntityState.Modified;
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
        public List<project_creation> Getdata()
        {
            return _DataContext.projectcreation.ToList();
        }
    }
}