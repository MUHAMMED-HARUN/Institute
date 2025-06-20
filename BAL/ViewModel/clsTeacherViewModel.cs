using DAL.Models.TableViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.ViewModel
{
    public class clsTeacherViewModel
    {
        public int TeacherID { get; set; }
        public int PersonID { get; set; }
        public bool IsActive { get; set; }
        public DateTime EntryDate { get; set; }
        public clsPersonTableView PersonTable { get; set; } = new clsPersonTableView();
        public DateTime ExitDate { get; set; }
       // public int AuditableEntityID { get; set; }

    }
}
