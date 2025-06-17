using BAL.Attribute;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.ViewModel
{
    public class clsEnrolmentStudentInClassModel
    {
        [Display(Name ="معرف التسجيل")]
        public int EnrollmentID { get; set; }
        [Display(Name = "معرف الصف")]
        [Range(1, int.MaxValue, ErrorMessage = "الرجاء اختيار صف صحيح.")]
        public int ClassID { get; set; }
        [Display(Name = "معرف الطالب")]
        //[HasActiveEnrolment]
        [Range(1, int.MaxValue, ErrorMessage = "الرجاء طالب.")]
        [HasActiveEnrollment(ErrorMessage ="هذا الطالب لديه قيد نشط في هذا الصف")]
        public int StudentID { get; set; }
        [Display(Name = "تاريخ التسجيل")]
        public DateTime? EnrolmentDate { get; set; }= DateTime.Now;
        [Display(Name = "تاريخ انتهاء التسجيل")]
        public DateTime? EnrollmentEndDate { get; set; } = null;
        [Display(Name ="حالة التسجيل")]
        [Range(1, int.MaxValue, ErrorMessage = "الرجاء اختيار حالة التسجيل.")]
        public byte EnrollmentStatus { get; set; }
        public clsStudentTableVieweModel studentTable { get; set; } = new clsStudentTableVieweModel();
       public List<clsClass> ClassList { get; set; }= new List<clsClass>();
        
        public Dictionary<string, int> EnrollStatus { get; set; } = new Dictionary<string, int>();
    } 
}
