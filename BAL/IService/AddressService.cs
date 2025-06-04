using BAL.interfaceCalsses;
using DAL.IService;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.IService
{
    public class AddressService : IAddressService
    {
        public clsAddress Address { get; set; }
        public clsCountriy Countriy { get; set; }
        public clsCity City { get; set; }
        public clsDistrict District { get; set; }
        public clsNeighborhood Neighborhood { get; set; }

        private readonly AddrssRepository _addrssRepository;
        public AddressService(AddrssRepository addrssRepository)
        {
            _addrssRepository = addrssRepository;
        }

        public clsAddress GetAddressByID(int AddressID)
        {
            return _addrssRepository.GetAddressByID(AddressID);
        }

        public List<clsAddress> GetAddressList()
        {
            return _addrssRepository.GetAddressList();
        }

        public clsCity GetCity(int CityID)
        {
            return _addrssRepository.GetCity(CityID);
        }

        public List<clsCity> GetCityList()
        {
            return _addrssRepository.GetCityList();
        }

        public List<clsCity> GetCityList(int CountryID)
        {
            return _addrssRepository.GetCityList(CountryID);
        }

        public clsCountriy GetCountryByID(int CountryID)
        {
            return _addrssRepository.GetCountryByID(CountryID);
        }

        public List<clsCountriy> GetCountryList()
        {
            return _addrssRepository.GetCountryList();
        }

        public clsDistrict GetDistrict(int DistrictID)
        {
            return _addrssRepository.GetDistrict(DistrictID);
        }

        public List<clsDistrict> GetDistrictList()
        {
            return _addrssRepository.GetDistrictList();
        }

        public List<clsDistrict> GetDistrictList(int CityID)
        {
            return _addrssRepository.GetDistrictList(CityID);
        }

        public clsNeighborhood GetNeighborhood(int NeighborhoodID)
        {
            return _addrssRepository.GetNeighborhood(NeighborhoodID);
        }

        public List<clsNeighborhood> GetNeighborhoodList()
        {
            return _addrssRepository.GetNeighborhoodList();
        }

        public List<clsNeighborhood> GetNeighborhoodList(int DistrictID)
        {
            return _addrssRepository.GetNeighborhoodList(DistrictID);
        }
    }
}
