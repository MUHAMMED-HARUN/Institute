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
        IAddressService _addressService;

        string OldImage;
        string OldIDImage;
        string NewtImage;
        string NewtIDImage;
        public PeopleController(IPersonService personService, IAddressService addressService)
        {
            _personService = personService;
            _addressService = addressService;
        }
        public IActionResult Index()
        {
            return View();
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
                return View(new clsPersonViewModel());

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
            SaveImagesPathToVar(_personService.Person.PersonID, _personService.Person.Image, _personService.Person.NationalIDImage);

            bool IsSaved = _personService.Save();
            HandleImage(IsSaved);
       
            return RedirectToAction("Index", "People");
        }
 
        void SaveImagesPathToVar(int PersonID,string newImg,string newIDImg)
        {
            

            if (_personService.SaveMode == GlobalVar._SaveMode.Update)
            {
                clsPerson person= _personService.GetByID(PersonID);
                if (person != null)
                {
                    OldImage = _personService.Person.Image;
                    OldIDImage = _personService.Person.NationalIDImage;
                }
                NewtImage = newImg;
                NewtIDImage = newIDImg;
            }
            else
            {
                NewtImage = newImg;
                NewtIDImage = newIDImg;
            }

        }
        void HandleImage(bool IsSaved)
        {
            if (!IsSaved)
            {
                // New Or Edit If Not Saved Remove Added Image To File 
                DeleteImage(NewtImage);
                DeleteImage(NewtIDImage);
            }
            else
            {
                if (_personService.SaveMode == GlobalVar._SaveMode.Update)
                {
                    DeleteImage(OldImage);
                    DeleteImage(NewtIDImage);
                }
            }
        }
        void DeleteImage(string ImgName)
        {
            if (ImgName == null || ImgName == "")
                return;

            clsFile file = new clsFile();
            string path = Path.Combine(clsFile.GetFullPathOfPersonImagesDirectory(), ImgName);
            file.DeleteFile(path);
        }
    }
}
