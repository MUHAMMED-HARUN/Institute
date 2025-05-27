using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class AuditableEntity
    {
        [Key]
        public int ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }

        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
