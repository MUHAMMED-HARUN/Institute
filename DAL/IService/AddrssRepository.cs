using DAL.interfaceCalsses;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.EF;
namespace DAL.IService
{
    public class AddrssRepository : IAddress
    {
        AppDBContext _Context;
        public AddrssRepository(AppDBContext appDBContext)
        {
            _Context= appDBContext;
        }
        public clsAddress GetAddressByID(int AddressID)
        {
            return _Context.Addresses.FirstOrDefault(a => a.ID == AddressID);
        }

        public List<clsAddress> GetAddressList()
        {
            return _Context.Addresses.ToList();
        }

        public clsCountriy GetCountryByID(int CountryID)
        {
            return _Context.Countriys.FirstOrDefault(c => c.ID == CountryID);
        }

        public List<clsCountriy> GetCountryList()
        {
            return _Context.Countriys.ToList();
        }

        public clsCity GetCity(int CityID)
        {
            return _Context.Cities.FirstOrDefault(c=>c.ID == CityID);
        }

        public List<clsCity> GetCityList()
        {
            return _Context.Cities.ToList();
        }

        public List<clsCity> GetCityList(int CountryID)
        {
            return _Context.Cities.Where(c=>c.CountryID == CountryID).ToList();
        }

        public clsDistrict GetDistrict(int DistrictID)
        {
            return _Context.Districts.FirstOrDefault(d => d.ID == DistrictID);
        }

        public List<clsDistrict> GetDistrictList()
        {
            return _Context.Districts.ToList();
        }

        public List<clsDistrict> GetDistrictList(int CityID)
        {
            return _Context.Districts.Where(d => d.CityID == CityID).ToList();
        }

        public clsNeighborhood GetNeighborhood(int NeighborhoodID)
        {
            return _Context.Neighborhoods.FirstOrDefault(n => n.ID == NeighborhoodID);
        }

        public List<clsNeighborhood> GetNeighborhoodList()
        {
            return _Context.Neighborhoods.ToList();
        }

        public List<clsNeighborhood> GetNeighborhoodList(int DistrictID)
        {
           return _Context.Neighborhoods.Where(n=>n.DistrictID == DistrictID).ToList();
        }
    }
}
