using BAL.Attribute;
using DAL.Models.TableViews;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.ViewModel
{
    public class clsStudentViewModel
    {
        [Display(Name ="معرف الطالب")]
        public int? StudentID { get; set; }
        public clsPersonTableView? PersonTable { get; set; } = new clsPersonTableView();
		[Display(Name = "معرف الشخص")]
        [IsStudent(ErrorMessage ="هذا الشخص يالاصل طالب")]
		public int PersonID { get; set; }
        [Display(Name ="تاريخ التسجيل")]

        public DateTime EntryDate { get; set; } = DateTime.Now;
		[Display(Name = "تاريخ الخروج")]

		public DateTime? ExitDate { get; set; } = null;
        [Display(Name = "هل هو مفعل")]

        public bool IsActive { get; set; } = true;

        // AuditableEntity
    }
}
