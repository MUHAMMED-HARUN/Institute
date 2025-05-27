using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsNeighborhood
    {
        [Key]
        public int ID { get; set; }
        [RegularExpression(@"^[A-Za-z\u0621-\u064A\s]+$", ErrorMessage = "اسم الحي يجب ان يكوم مكون من احرف فقط")]

        public string NeighborhoodName { get; set; }
        [ForeignKey("City")]
        public int CityID { get;set; }
        public virtual clsCity City { get; set; }
        [ForeignKey("AuditableEntity")]
        public int? AuditableEntityID { get; set; }

        public virtual AuditableEntity AuditableEntity { get; set; }

    }
}
