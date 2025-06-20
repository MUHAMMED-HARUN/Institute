using DAL.Models.TableViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.TableFilters
{
    public class clsEnrollmentStudentInClassFilter
    {
        public int? StudentID { get; set; }
        public string NationalNumber { get; set; }
        public string StudentFullName { get; set; }
        public int? CalssID { get; set; }
        public string ClassName{ get; set; }
        public bool? IsActive { get; set; }
        public List<clsEnrollmentStudentInClassTableView> EnrollmentTable { get; set; } = new List<clsEnrollmentStudentInClassTableView>();
    }
}