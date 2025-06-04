using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class clsAddress
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Neighborhood")]
        public int NeighborhoodID { get; set; }
        public clsNeighborhood Neighborhood { get; set; }
        public string AddressDetails { get; set; }
        [ForeignKey("AuditableEntity")]
        public int? AuditableEntityID { get; set; }

        public virtual AuditableEntity AuditableEntity { get; set; }
    }
}
