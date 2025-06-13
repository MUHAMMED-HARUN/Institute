using BAL;
using BAL.interfaceCalsses;
using BAL.IService;
using BAL.Mapper;
using BAL.ViewModel;
using DAL.Models;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Institute_Proj.Controllers.Pepole
{
    public class PeopleController : Controller
    {
        // List of people
        IPersonService _personService;
        IAddressService _addressService;

        string OldImage;
        string OldIDImage;
        string NewImage;
        string NewIDImage;
        public PeopleController(IPersonService personService, IAddressService addressService)
        {
            _personService = personService;
            _addressService = addressService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            clsPersonFilter personFilter = new clsPersonFilter();

            personFilter.personTableView = _personService.GetPersonTableView(personFilter);
            
            return View("PersonList", personFilter);
        }
        public IActionResult Search(clsPersonFilter personFilter)
        {
            return Json(_personService.GetPersonTableView(personFilter));
            
        }
        [HttpGet]
        public IActionResult NewOrEdit(int personID)
        {   
           
            Mapper mapper = new Mapper(_personService, _addressService);
            clsPersonViewModel personViewModel = mapper.MapPerson(personID);
            ViewBag.Relations = new SelectList(_personService.RelationshipStatusArabic().Select(r => new { Text = r.Key, Value = r.Value.ToString() }), "Value", "Text");
            if (personViewModel != null)
                return View(personViewModel);
            else
            {
                personViewModel = new clsPersonViewModel();
                personViewModel.addressPartialView.Counties = _addressService.GetCountryList();
                personViewModel.CityAndCountry.countriys = _addressService.GetCountryList();
                return View(personViewModel);
            }

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
               
            Mapper mapper = new Mapper(_personService, _addressService);
            _personService.Person= mapper.MapPerson(personVModel);
            _personService.Address = mapper.MapAddress(personVModel.addressPartialView);
            // Re Build This Func
            SaveImagesPathToVar(_personService.Person.PersonID);

            bool IsSaved = _personService.Save();
            HandleImages(IsSaved, personVModel.ImageFile, personVModel.NationalImageFile);
       
            return RedirectToAction("Index", "People");
        }
        public IActionResult ShowPersonCard(int PersonID, string prefix)
        {
            ViewData.TemplateInfo.HtmlFieldPrefix = prefix;

            Mapper mapper = new Mapper(_personService, _addressService);
            clsPersonTableView model = mapper.MapPersonCard(PersonID);
            if (model != null)
                return PartialView("PersonCardPartial", model);
            else
                return PartialView("PersonCardPartial", new clsPersonTableView());

        }
        public IActionResult DeletePerson(int PersonID)
        {
                if (_personService.IsExist(PersonID))
            {
                return Json(_personService.Delete(PersonID));
            }
            else
            {
                return Json(false);
            }
        }
        [HttpGet]
        public IActionResult PersonCardWithFilter()
        {
            return PartialView("PersonCardWithFilterPartila", new clsPersonTableView());
        }
        [HttpPost]
        public IActionResult PersonCardWithFilter(clsPersonFilter personFilter,string prefix)
        {
            ViewData.TemplateInfo.HtmlFieldPrefix = prefix;
            return PartialView("PersonCardPartial", _personService.GetPersonTableView(personFilter).FirstOrDefault());
        }
        void SaveImagesPathToVar(int PersonID)
        {


            if (_personService.SaveMode == GlobalVar._SaveMode.Update)
            {
                clsPerson person = _personService.GetByID(PersonID);
                if (person != null)
                {
                    OldImage = person.Image;
                    OldIDImage = person.NationalIDImage;
                }
            }
            if (OldImage != _personService.Person.Image && !string.IsNullOrEmpty(_personService.Person.Image))
                NewImage = _personService.Person.Image;
            if (OldIDImage != _personService.Person.NationalIDImage && !string.IsNullOrEmpty(_personService.Person.NationalIDImage))
                NewIDImage = _personService.Person.NationalIDImage;
        }
        void HandleImages(bool IsSaved, IFormFile ImageFile, IFormFile ImageIDFile)
        {
            if (!string.IsNullOrEmpty(NewImage))
                SaveNewImage(IsSaved, ImageFile, NewImage);
            if (!string.IsNullOrEmpty(NewIDImage))
                SaveNewImage(IsSaved, ImageIDFile, NewIDImage);

            if (_personService.SaveMode == GlobalVar._SaveMode.Update)
            {
                if (!string.IsNullOrEmpty(OldImage) && !string.IsNullOrEmpty(NewImage))
                    DeleteOldImage(IsSaved, OldImage);
                if (!string.IsNullOrEmpty(OldIDImage) && !string.IsNullOrEmpty(NewIDImage))
                    DeleteOldImage(IsSaved, OldIDImage);
            }

        }
        void SaveNewImage(bool IsSaved, IFormFile ImageFile,string ImageName)
        {
            if(IsSaved)
            {
                clsFile file= new clsFile();
                file.SaveIFormFile(ImageFile, clsFile.GetFullPathOfPersonImagesDirectory(), ImageName);
            }
        }
        void DeleteOldImage(bool IsSaved,string ImageName)
        {
            if (IsSaved)
            {
                clsFile file = new clsFile();
                string filePath = Path.Combine(clsFile.GetFullPathOfPersonImagesDirectory(), ImageName);
                file.DeleteFile(filePath);
            }
        }
    }
}
