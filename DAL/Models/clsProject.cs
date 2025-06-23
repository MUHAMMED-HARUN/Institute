using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class clsProject
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [ForeignKey("AuditableEntity")]
        public int? AuditableEntityID { get; set; }
        public virtual AuditableEntity AuditableEntity { get; set; }
    }
}
