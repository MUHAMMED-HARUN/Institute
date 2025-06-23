using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class clsReadingDay
    {
        [Key]
        public  int ID { get; set; }
        [ForeignKey("QuranStudent")]
        public int QuranStudentID { get; set; }
        public virtual clsQuranStudent QuranStudent { get; set; }
        [ForeignKey("AuditableEntity")]
        public int? AuditableEntityID { get; set; }
        public virtual AuditableEntity AuditableEntity { get; set; }
    }
}
