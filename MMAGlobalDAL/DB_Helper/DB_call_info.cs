using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMAGlobalDAL.Database.DB_Entity;
using Microsoft.EntityFrameworkCore;
namespace MMAGlobalDAL.Database.DB_Helper
{
    public class DB_call_info
    {

        private EF_MMADatabaseContext _DataContext;
        public DB_call_info(EF_MMADatabaseContext DataContext)
        {
            _DataContext = DataContext;
        }
        public int SaveCallinfo(call_info call_info)
        {
            int callid = 0;
            try
            {

                _DataContext.call_info.Add(call_info);
                if (call_info.slno > 0)
                {
                    _DataContext.Entry(call_info).State = EntityState.Modified;
                }
                _DataContext.SaveChanges();
                callid = call_info.slno;
            }
            catch (Exception ex)
            {
                return callid;
            }
            return callid;
        }
        public List<call_info> Getdata()
        {
            return _DataContext.call_info.ToList();
        }

    }
}

