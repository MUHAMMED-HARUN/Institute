using BAL.interfaceCalsses;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Institute_Proj.Controllers.Address
{
    public class AddressController : Controller
    {
        IAddressService _AddressService;
        public AddressController(IAddressService AddressService)
        {
            _AddressService = AddressService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCities(int countryId) 
        {

            return Json(_AddressService.GetCityList(countryId));
        } 
        public IActionResult GetDistricts(int CityId) 
        {
            return Json(_AddressService.GetDistrictList(CityId));
        }
        public IActionResult GetNeighborhoods(int DistrictId)
        {
            return Json(_AddressService.GetNeighborhoodList(DistrictId));
        }
    }
}
