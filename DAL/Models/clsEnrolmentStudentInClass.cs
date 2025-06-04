using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class clsEnrolmentStudentInClass
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Class")]
        public int ClassID { get; set; }
        public virtual clsClass Class { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public virtual clsStudent Student { get; set; }
        public DateTime EnrolmentDate { get; set; }
        public DateTime? EnrollmentEndDate { get; set; }

        [ForeignKey("AuditableEntity")]
        public int? AuditableEntityID { get; set; }

        public virtual AuditableEntity AuditableEntity { get; set; }
    }
}
