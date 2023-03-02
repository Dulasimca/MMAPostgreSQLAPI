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
    public class ManageSubCategoryMasterDB
    {
        /// <summary>
        /// This method will store the sub category master data in to database. we can use same method for insert and update.
        /// </summary>
        /// <param name="model">we have to send the sub category master properties with values</param>
        /// <param name="_db">Database connectoin property for sub category master</param>
        /// <returns>return boolean values. true or false</returns>
        public bool Save(subcategorymaster_Model model, DB_subcategorymasterdb _db)
        {
            bool isSuccess = false;
            try
            {
                sub_categorymasterdb sub_category = new sub_categorymasterdb
                {
                    sino = model.sino,
                    categoryname = model.categoryname,
                    maincategorycode=model.maincategorycode,
                    flag = model.flag
                };
                isSuccess = _db.SaveSubCategory(sub_category);

                return isSuccess;

            }

            catch (Exception ex)
            {
                AuditLog.WriteError("ManageTraningDB save method: " + ex.Message);
                return isSuccess;
            }

        }
        public List<subcategorymaster_Model> GetData(DB_subcategorymasterdb _db)
        {
            try
            {
                List<subcategorymaster_Model> _Model = new List<subcategorymaster_Model>();
                var restul = _db.Getdata();
                restul.ForEach(model => _Model.Add(new subcategorymaster_Model()
                {
                    sino = model.sino,
                    categoryname = model.categoryname,
                    maincategorycode = model.maincategorycode,
                    flag = model.flag
                }));

                return _Model;
            }
            catch (Exception ex)
            {
                AuditLog.WriteError("Managesubcategorymaster save method: " + ex.Message);
                return null;
            }

        }

    } 
}
