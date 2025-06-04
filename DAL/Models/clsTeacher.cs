using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class clsTeacher
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Person")]
        [MaxLength(50)]
        public int PersonID { get; set; }
        public virtual clsPerson Person { get; set; }
        public bool IsActive { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime? ExitDate { get; set; }
        // اضافة attr لمعرفة هل هذا الوقت اكبر من الوقت التالي للتحقق

        [ForeignKey("AuditableEntity")]
        public int? AuditableEntityID { get; set; }

        public virtual AuditableEntity AuditableEntity { get; set; }
    }
}
