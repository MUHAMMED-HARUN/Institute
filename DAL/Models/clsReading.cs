using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class clsReading
    {
        [Key]
        public int ID { get; set; }
        public short ReadedPageNum { get; set; }
        public byte PerformanceRating{ get; set; }
        public byte ReadigType{ get; set; }

        [ForeignKey("ReadingDay")]
        public int ReadingDayID { get; set; }
        public virtual clsReadingDay ReadingDay { get; set; }
        [ForeignKey("AuditableEntity")]
        public int? AuditableEntityID { get; set; }
        public virtual AuditableEntity AuditableEntity { get; set; }

    }
}
