using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class clsCountriy
    {
        [Key]
        public int ID { get; set; }
        [RegularExpression(@"^[A-Za-z\u0621-\u064A\s]+$", ErrorMessage = "اسم الدولة يجب ان يكوم مكون من احرف فقط")]
        public string CountryName { get; set; }
        [ForeignKey("AuditableEntity")]
        public int? AuditableEntityID { get; set; }

        public virtual AuditableEntity AuditableEntity { get; set; }
    }
}
