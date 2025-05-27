using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsDepartment
    {
        [Key]
        public int ID { get; set; }
        public string DepartmentName { get; set; }
        public string? DepartmentDiscription { get; set; }

        [ForeignKey("AuditableEntity")]
        public int? AuditableEntityID { get; set; }

        public virtual AuditableEntity AuditableEntity { get; set; }
    }
}
