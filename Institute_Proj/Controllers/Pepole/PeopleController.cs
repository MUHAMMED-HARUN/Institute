using BAL;
using BAL.interfaceCalsses;
using BAL.IService;
using BAL.Mapper;
using BAL.ViewModel;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Institute_Proj.Controllers.Pepole
{
    public class PeopleController : Controller
    {
        // List of people
        IPersonService _personService;
       public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult NewOrEdit(int? personID)
        {
            clsPersonViewModel personViewModel = new clsPersonViewModel();
            personViewModel.addressPartialView = new clsAddressPartialView();
            personViewModel.CityAndCountry = new clsCityAndCountryViewModel();
           ViewBag.Relations = new SelectList(_personService.RelationshipStatusArabic().Select(r => new { Text = r.Key, Value = r.Value.ToString() }), "Value", "Text");
            return View(personViewModel);

        }
        //http://localhost:18780/People/NewOrEdit
        [HttpPost]
        public IActionResult NewOrEdit(clsPersonViewModel personVModel)
        {
       
            if (!ModelState.IsValid)
            {
                ViewBag.Relations = new SelectList(_personService.RelationshipStatusArabic().Select(r => new { Text = r.Key, Value = r.Value.ToString() }), "Value", "Text");
                return View(personVModel); 
            }

            Mapper mapper = new Mapper(_personService);
            _personService.Person= mapper.MapPerson(personVModel);
            _personService.Address = mapper.MapAddress(personVModel.addressPartialView);

            if( _personService.Save())
            {
                // Save Image To www.root;
            }
            return RedirectToAction("Index", "People");
        }
 
    }
}
