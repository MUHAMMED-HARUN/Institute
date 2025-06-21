using DAL.Models.TableViews;
using System;
using System.Collections.Generic;

namespace DAL.Models.TableFilters
{
    public class clsTeacherFilter:clsPersonFilter
    {
        public int? TeacherID { get; set; }
        public DateTime EntryDate { get; set; } = new DateTime(1900, 1, 1);
        public DateTime ExitDate { get; set; } = new DateTime(9999, 12, 31);
        public bool? IsActive { get; set; }

      
        public List<clsTeacherTableView> TeacherTableView { get; set; } = new();
    }
}
