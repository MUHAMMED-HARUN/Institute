using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.TableFilters
{
    public class clsQuranTestFilter
    {
        public int? NominationID { get; set; }
        public string CommitteeName { get; set; }
        public short? StartGrade { get; set; }
        public short? EndGrade { get; set; }
        public byte? FromPart { get; set; }
        public byte? ToPart { get; set; }
        public string QSName { get; set; }
    }
}
