using DAL.Models.TableViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.TableFilters
{
    public class clsFilterNomination
    {
        public string FullName { get; set; }
        public DateTime StartTestDate { get; set; }
        public DateTime EndTestDate { get; set; }

        public List<clsNominationTableView> NominationTableView { get; set; } = new List<clsNominationTableView>(); 
    }
}
