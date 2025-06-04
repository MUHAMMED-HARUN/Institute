using BAL.interfaceCalsses;
using DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BAL.ViewModel
{
    public class clsAddressPartialView
    {
      
public clsAddressPartialView()
        {
            Counties = new List<clsCountriy>();
        }
        [Range(1, int.MaxValue)]
        public int? SelectedCountryID { get; set; }
        [Range(1, int.MaxValue)]

        public int? SelectedCityID { get; set; }
        [Range(1, int.MaxValue)]

        public int? SelectedDistrictID { get; set; }
        [Range(1, int.MaxValue)]

        public int? SelectedNeighborhoodID { get; set; }
        public List<clsCountriy>? Counties { get; set; } 
        public string AddressDetails { get; set; }
    }
}
