using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.interfaceCalsses
{
    public interface IAddressService
    {
        public clsAddress Address { get; set; }
        public clsCountriy Countriy { get; set; }
        public clsCity City { get; set; }
        public clsDistrict District { get; set; }
        public clsNeighborhood Neighborhood { get; set; }

        // Get List And Get Bt ID;

        //  for clsAddress
        public List<clsAddress> GetAddressList();
        public clsAddress GetAddressByID(int AddressID);

        //  for Country
        public List<clsCountriy> GetCountryList();
        public clsCountriy GetCountryByID(int CountryID);
        //  for city
        public List<clsCity> GetCityList();
        public List<clsCity> GetCityList(int CountryID);
        public clsCity GetCity(int CityID);
        //  for District
        public List<clsDistrict> GetDistrictList();
        public List<clsDistrict> GetDistrictList(int CityID);
        public clsDistrict GetDistrict(int DistrictID);
        //  for neighbood
        public List<clsNeighborhood> GetNeighborhoodList();
        public List<clsNeighborhood> GetNeighborhoodList(int DistrictID);
        public clsNeighborhood GetNeighborhood(int NeighborhoodID);
    }
}
