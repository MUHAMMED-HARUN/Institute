using DAL.Models.TableViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.TableFilters
{
    public class clsEnrolmentTeacherInClassFilter
    {
        public int? TeacherID { get; set; }
        public string NationalNumber { get; set; }
        public string TeacherFullName { get; set; }
        public int? ClassID { get; set; }
        public string ClassName { get; set; }
        public bool? IsActive { get; set; }

        public List<clsEnrollmentTeacherInClassTableView> Enrollments { get; set; } = new();
    }
}
