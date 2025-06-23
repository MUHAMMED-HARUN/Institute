using BAL.Attribute;
using DAL.Models;
using DAL.Models.TableViews;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BAL.ViewModel
{
    public class clsQuranStudentModel
    {
        [Display(Name = "معرف الحفظ")]
        public int ID { get; set; }

        [Display(Name = "معرف الطالب")]
        [Range(1, int.MaxValue, ErrorMessage = "الرجاء اختيار طالب.")]
        [IsQuranStudentHasBaseStudent(ErrorMessage ="لا يمكن ربط هذه البيانات بهذا الطالب لانه مربوط بالفعل")]
        public int StudentID { get; set; }

        [Display(Name = "عدد الصفحات المحفوظة")]
        [Range(0, 604, ErrorMessage = "الرجاء إدخال عدد صحيح بين 0 و 604.")]
        public short TotalSavedPages { get; set; }

        [Display(Name = "عدد الأجزاء المثبتة")]
        [Range(0, 30, ErrorMessage = "الرجاء إدخال عدد صحيح بين 0 و 30.")]
        public byte TotalInstalledParts { get; set; }

        [Display(Name = "معرف المشروع")]
        [Range(1, int.MaxValue, ErrorMessage = "الرجاء اختيار مشروع.")]
        [IsAlreadyInProject(ErrorMessage ="هذا الطالب موجود في هذا المشروع")]
        public int ProjectID { get; set; }

        [Display(Name = "تقييم الأداء")]
        public byte performanceRating { get; set; }

        // لعرض معلومات الطالب المختار
        public clsStudentTableVieweModel studentTable { get; set; } = new clsStudentTableVieweModel();

        // لعرض قائمة المشاريع في القائمة المنسدلة
        public List<clsProject> ProjectList { get; set; } = new List<clsProject>();

        // تقييمات الأداء كخيارات جاهزة في القائمة المنسدلة
        public Dictionary<string, byte> PerformanceRatings { get; set; } = new Dictionary<string, byte>();
    }
}
