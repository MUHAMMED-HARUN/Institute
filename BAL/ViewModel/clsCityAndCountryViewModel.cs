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
        }
        public int SelectedCountryID { get; set; }
        public List<clsCountriy>? countriys { get; set; }
        //City ID
        public int PlaceOfBirthID { get; set; }
    }
}
