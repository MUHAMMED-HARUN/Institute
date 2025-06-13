using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.TableViews
{
    public class clsPersonTableView
    {
        public int PersonID { get; set; }
        public string NationalNumber { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string GrandFatherName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string MotherName { get; set; }
        public string MotherLastName { get; set; }
        public string MotherFullName { get; set; }
        public string GendorText { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryName { get; set; }
        public string AddressCityName { get; set; }
        public string DistrictName { get; set; }
        public string NeighborhoodName { get; set; }
        public string AddressDetails { get; set; }
        public string PlaceOfBirthName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PersonalStatus { get; set; }
        public string Image { get; set; }
        public string NationalIDImage { get; set; }
    }
}
