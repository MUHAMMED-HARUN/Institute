using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class clsBasicTestInfo
    {
        [Key]
        public int ID { get; set; }
        public string TestName { get; set; }
        public string TestDescription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public short MaxGrade { get; set; }
        public short MinGrade { get; set; }

    }
}
