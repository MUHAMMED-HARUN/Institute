using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class clsEnrolmentTeacherInClass
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Class")]
        public int ClassID { get; set; }
        public virtual clsClass Class { get; set; }
        [ForeignKey("Teacher")]
        public int TeacherID { get; set; }
        public virtual clsTeacher Teacher { get; set; }
        public DateTime EnrolmentDate { get; set; }
        public DateTime? EndEnrolmentDate { get; set; }


        [ForeignKey("AuditableEntity")]
        public int? AuditableEntityID { get; set; }
        public virtual AuditableEntity AuditableEntity { get; set; }

    }
}
