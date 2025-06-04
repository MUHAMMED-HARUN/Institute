using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class clsNeighborhood
    {
        [Key]
        public int ID { get; set; }
        [RegularExpression(@"^[A-Za-z\u0621-\u064A\s]+$", ErrorMessage = "اسم الحي يجب ان يكوم مكون من احرف فقط")]

        public string NeighborhoodName { get; set; }
        [ForeignKey("District")]
        public int DistrictID { get; set; }
        public virtual clsDistrict District { get; set; }
        [ForeignKey("AuditableEntity")]
        public int? AuditableEntityID { get; set; }

        public virtual AuditableEntity AuditableEntity { get; set; }

    }
}
