using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.interfaceCalsses
{
  public interface IAddress
    {
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
