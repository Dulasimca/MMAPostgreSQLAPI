using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMAGlobalDAL.Database.DB_Entity
{
    [Table("contactslist")]
    public class contacts_list
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int slno { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int roleid { get; set; }
        public int maincategory_id { get; set; }
        public int subcategory_id { get; set; }
        public DateTime dob { get; set; }
        public string phonenumber { get; set; }
        public string whatsappnumber { get; set; }
        public string email_id { get; set; }
        public int countrycode { get; set; }
        public int statecode { get; set; }
        public int citycode { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string pincode { get; set; }
        public Boolean isunion { get; set; }
        public int unionid { get; set; }
        public Boolean flag { get; set; }



    }
}
