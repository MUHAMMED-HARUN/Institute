using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.TableViews
{
    public class clsEnrollmentStudentInClassTableView
    {
        public int? ID { get; set; }
        public string FullName { get; set; }
        public string NationalNumber { get; set; }
        public string ClassName { get; set; }
       public bool? IsActive { get; set; }
    }
}
