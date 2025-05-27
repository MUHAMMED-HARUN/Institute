using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsCity
    {
        [Key]
        public int ID { get; set; }
        [RegularExpression(@"^[A-Za-z\u0621-\u064A\s]+$", ErrorMessage = "اسم المدينة يجب ان يكوم مكون من احرف فقط")]

        public string CityName { get; set; }
        [ForeignKey("Countriy")]
        public int CountryID { get; set; }
        public virtual clsCountriy Countriy {  get; set; }
        [ForeignKey("AuditableEntity")]
        public int? AuditableEntityID { get; set; }

        public virtual AuditableEntity AuditableEntity { get; set; }
    }
}
