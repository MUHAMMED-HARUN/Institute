using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.ViewModel
{
    public class clsCityAndCountryViewModel
    {
        public clsCityAndCountryViewModel()
        {
            countriys = new List<clsCountriy>();
            Cities = new List<clsCity>();
        }
        public int SelectedCountryID { get; set; }
        public List<clsCountriy>? countriys { get; set; }
        public List<clsCity>?Cities { get; set; }
        //City ID
        public int PlaceOfBirthID { get; set; }
    }
}
