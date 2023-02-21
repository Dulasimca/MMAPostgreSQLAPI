using MMAGlobalDAL.Database.DB_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalDAL.Database.DB_Entity
{
    public class DB_MasterEntity
    {
        public List<main_categorymasterdb> main_Categorymasters { get; set; }
        public List<statemasterdb> statemasters { get; set; }
        public List<city_master> city_Masters { get; set; }
        public List<sub_categorymasterdb> sub_Categorymasters { get; set; }
        public List<union_masters> union_Masters { get; set; }
        public List<role_master> role_Masters { get; set; }
        public List<expensescategory_master> expensescategory_Masters { get; set; }
        public List<country_master> country_Masters { get; set; }
        public List<shooting_status> shooting_Statuses { get; set; }


    }
}
