using DAL.interfaceCalsses;
using DAL.Models.TableViews;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.TableFilters
{
    public class clsStudentFilter:clsPersonFilter
    {
        [Display(Name ="معرف الطالب")]
        public int? @StudentID { get; set; }
        [Display(Name = "تاريخ التسجيل")]
        public DateTime? EntryDate { get; set; }
        [Display(Name = "تاريخ الفصل")]
        public DateTime? ExitDate { get; set; }
        [Display(Name = "الحالة")]
        public bool? IsActive { get; set; }

        public List<clsStudentTableView> studentTableView { get; set; } = new List<clsStudentTableView>();

    }
}
