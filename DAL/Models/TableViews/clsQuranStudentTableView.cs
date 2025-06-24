using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.TableViews
{
    public class clsQuranStudentTableView
    {
        public int QuranStudentID { get; set; }
        public short TotalSavedPages { get; set; }
        public byte TotalInstalledParts { get; set; }
        public string ProjectName { get; set; }
        public string PerformanceRatingText { get; set; }

        public int? StudentID { get; set; }
        public int? PersonID { get; set; }
        public string NationalNumber { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string GendorText { get; set; }
        public string CountryName { get; set; }
        public string AddressCityName { get; set; }
        public string DistrictName { get; set; }
        public string NeighborhoodName { get; set; }
        public string AddressDetails { get; set; }
        public string PlaceOfBirthName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PersonalStatus { get; set; }
        public string Image { get; set; }
        public string NationalIDImage { get; set; }
        public string IsActive { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? ExitDate { get; set; }
    }
}
