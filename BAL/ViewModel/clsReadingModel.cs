using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.ViewModel
{
    public class clsReadingModel
    {
        [DisplayName("معرف القرائة")]
        public int ReadingID { get; set; }
        [DisplayName("الصفحة المقروئة")]
        public short ReadedPageNumer { get; set; }
        [DisplayName("تقدير الصفحة")]
        public byte PerformaceRating { get; set; }
        public Dictionary<string, byte> PerformaceList= new Dictionary<string, byte>();
        [DisplayName("نوع القرائة")]
        public byte readingType { get; set; }
        public Dictionary<string, byte>? ReadingTypeList=new Dictionary<string, byte>();
      
        [DisplayName("تاريخ القرائة")]
        public DateTime? ReadingDay { get; set; }
        [DisplayName("معرف يوم التسميع")]
        public int ReadingDayID { get; set; }
        [DisplayName("اسم الطالب")]
        public string? QuranStudentName { get; set; }
        [DisplayName("معرف الطالب")]
        public int QuranStudentID { get; set; }

    }
}
