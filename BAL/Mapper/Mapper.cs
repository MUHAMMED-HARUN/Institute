using BAL.interfaceCalsses;
using BAL.IService;
using BAL.ViewModel;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Mapper
{
    public class Mapper
    {
        IPersonService _personService;

        public Mapper(IPersonService personService)
        {
            _personService = personService;
        }
        public  clsPerson MapPerson(clsPersonViewModel model)
        {
            //service.inject( _personService)

            _personService.SaveMode = (model.PersonID > 0) ? GlobalVar._SaveMode.Update : GlobalVar._SaveMode.New;

            _personService.Person = new clsPerson();

            _personService.Person.NationalNumber = model.NationalNumber;
            _personService.Person.FirstName = model.FirstName;
            _personService.Person.FatherName = model.FatherName;
            _personService.Person.GrandFatherName = model.GrandFatherName;
            _personService.Person.LastName = model.LastName;
            _personService.Person.PhoneNumber = model.PhoneNumber;
            _personService.Person.BirthDate = model.BirthDate;
            _personService.Person.MotherName = model.MotherName;
            _personService.Person.MotherLastName = model.MotherLastName;
            _personService.Person.RelationshipStatus = ((sbyte)model.RelationshipsID);
            _personService.Person.Gendor = model.Gendor;
            _personService.Person.PlaceOfBirthID = model.CityAndCountry.PlaceOfBirthID;
            clsFile file = new clsFile();
            _personService.Person.Image = file.SaveIFormFile(model.ImageFile, clsFile.GetFullPathOfPersonImagesDirectory());
            _personService.Person.NationalIDImage = model.NationalIDImage;

            return _personService.Person;
        }
       public clsAddress MapAddress(clsAddressPartialView addressPartialView)
        {
            _personService.Address = new clsAddress();

                if (addressPartialView.SelectedNeighborhoodID.HasValue)
                _personService.Address.NeighborhoodID =addressPartialView.SelectedNeighborhoodID.Value;

            _personService.Address.AddressDetails =addressPartialView.AddressDetails;
            return _personService.Address;

        }
        public clsPersonViewModel MapPerson(int PersonID)
        {
            clsPersonViewModel model = new clsPersonViewModel();
            clsPerson person = _personService.GetByID(PersonID);

            if (person == null)
                return null;

            model.PersonID = person.PersonID;
            model.NationalNumber= person.NationalNumber;
            model.FatherName= person.FatherName;
            model.FatherName=person.FatherName;
            model.GrandFatherName= person.GrandFatherName;
            model.LastName= person.LastName;
            model.PhoneNumber= person.PhoneNumber;
            model.BirthDate= person.BirthDate;
            model.MotherName= person.MotherName;
            model.MotherLastName= person.MotherLastName;
            model.RelationshipsID = (int)person.RelationshipStatus;
            model.Gendor= person.Gendor;
            model.ImagePath = Path.Combine(clsFile.GetFullPathOfPersonImagesDirectory(), person.Image);
            // image of national id image
        }
        public clsAddressPartialView MapAddress(int AddressID)
        {

        }
    }
}
