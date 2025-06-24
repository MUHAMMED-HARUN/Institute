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
        public int ID { get; set; }
        public DateTime ReadingDate { get; set; }
        public string Discription { get; set; }

        [ForeignKey("AuditableEntity")]
        public int? AuditableEntityID { get; set; }
        public virtual AuditableEntity? AuditableEntity { get; set; }
    }
}
