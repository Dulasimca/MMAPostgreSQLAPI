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
   public class Managemasters
    {
        public DB_MasterEntity GetData(DB_masters b_Masters)
        {
            DB_MasterEntity Master_Model = new DB_MasterEntity();

            try
            {
                return b_Masters.Getdata();
               

                // return masters_Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("Manage save method: " + ex.Message);
                return null;
            }

        }

    }
}
