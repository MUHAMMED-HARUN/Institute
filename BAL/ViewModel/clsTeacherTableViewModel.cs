using DAL.Models.TableViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.ViewModel
{
   public class clsTeacherTableViewModel
    {
		public clsPersonTableView clsPersonViewModel { get; set; } = new clsPersonTableView();
		public int TeacherID { get; set; }
		public string IsActive { get; set; }
		public DateTime EntryDate { get; set; }
		public DateTime ExitDate { get; set; }
	}
}
