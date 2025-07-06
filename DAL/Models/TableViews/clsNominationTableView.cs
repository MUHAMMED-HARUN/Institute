using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Models.TableViews
{
    public class clsNominationTableView
    {
        [Display(Name ="معرف الترشيح")]
        public int? NominationID { get; set; }
        [Display(Name ="معرف الطالب")]
        public int? QuranStudentID { get; set; }
        [Display(Name ="اسم الطالب")]
        public string QuranStudentFullName { get; set; }
        [Display(Name = "تاريخ الترشيح")]
        public DateTime? NominationDate { get; set; }
        [Display(Name = "معرف الاختبار")]
        public int? BasicTestID { get; set; }
        [Display(Name = "تاريخ الاختبار")]
        public DateTime? TestDate { get; set; }
        [Display(Name = "اسم الاختبار")]
        public string TestName { get; set; }
        [Display(Name ="من")]
        public byte? FromPart { get; set; }
        [Display(Name = "الى")]
        public byte? ToPart { get; set; }
    }
}
