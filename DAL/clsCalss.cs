using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsCalss
    {
        [Key]
        public int ID { get; set; }
        public string ClassName { get; set; }
        public string CalssDiscription { get; set; }
        public float SubscriptionFee { get; set; }
        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public virtual clsDepartment Department { get; set; }

        [ForeignKey("AuditableEntity")]
        public int? AuditableEntityID { get; set; }

        public virtual AuditableEntity AuditableEntity { get; set; }
    }
}
