using DAL.Models.TableViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.TableFilters
{
    public class clsQuranStudentFilter : clsStudentFilter
    {
        public int? QuranStudentID { get; set; }
        public int? StartSevdPage { get; set; }
        public int? EndSevdPage { get; set; }
        public int? StartInstalledPart { get; set; }
        public int? EndInstalledPart { get; set; }
        public int? ProjectID { get; set; }
        public int? PerformanceRating { get; set; }
     public   List<clsQuranStudentTableView> QuranStudentTableView { get; set; } =new List<clsQuranStudentTableView>();
        public List<clsProject> Projects { get; set; } = new List<clsProject>();

    }
}
