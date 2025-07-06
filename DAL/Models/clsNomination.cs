using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class clsNomination
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("BasicTest")]
        public int BasicTestID { get; set; }
        public virtual clsBasicTestInfo BasicTest { get; set; }
        [ForeignKey("QuranStudent")]
        public int QuranStudentID { get; set; }
        public virtual clsQuranStudent QuranStudent { get; set; }
        public byte FromPart {  get; set; }
        public byte? ToPart { get; set; } 
        public DateTime NominationDate { get; set; }
        public DateTime TestDate { get; set; }
        public byte TestStatus { get; set; }

    }
}
