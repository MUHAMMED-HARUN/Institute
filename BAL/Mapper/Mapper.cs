using BAL.interfaceCalsses;
using BAL.IService;
using BAL.ViewModel;
using DAL.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Buffers.Text;
using System.Net.NetworkInformation;
using DAL.Models.TableViews;
using DAL.Models.TableFilters;
namespace BAL.Mapper
{
    public class Mapper
    {
        IPersonService _personService;
        IAddressService _addressService;
        public Mapper(IPersonService personService, IAddressService addressService)
        {
            _personService = personService;
            _addressService = addressService;
        }
        public clsPerson MapPerson(clsPersonViewModel model)
        {

            // Convert To IsExist(personID);
            _personService.Person = _personService.GetByID(model.PersonID);
            if (_personService.Person == null)
            {
                _personService.SaveMode = GlobalVar._SaveMode.New;
                _personService.Person = new clsPerson();
            }
            else
            {
                _personService.SaveMode = GlobalVar._SaveMode.Update;
                _personService.Person.PersonID = model.PersonID;
            }



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

            if (model.ImageFile != null)
                _personService.Person.Image = file.ConvertFileNameToGuid(model.ImageFile.FileName);
            else
                 if (_personService.SaveMode == GlobalVar._SaveMode.Update)
                _personService.Person.Image = Path.GetFileName(model.ImagePath);


            if (model.NationalImageFile != null)
                _personService.Person.NationalIDImage = file.ConvertFileNameToGuid(model.NationalImageFile.FileName); 
            else
                  if (_personService.SaveMode == GlobalVar._SaveMode.Update)
                _personService.Person.NationalIDImage =Path.GetFileName( model.NationalImagePath);

            return _personService.Person;
        }
        public clsAddress MapAddress(clsAddressPartialView addressPartialView)
        {
            _personService.Address = new clsAddress();

            if (addressPartialView.SelectedNeighborhoodID.HasValue)
                _personService.Address.NeighborhoodID = addressPartialView.SelectedNeighborhoodID.Value;

            _personService.Address.AddressDetails = addressPartialView.AddressDetails;
            return _personService.Address;

        }
        public clsPersonViewModel MapPerson(int PersonID)
        {
            clsPersonViewModel model = new clsPersonViewModel();
            clsPerson person = _personService.GetByID(PersonID);

            if (person == null)
                return null;

            model.IsEdit = true;

            model.PersonID = person.PersonID;
            model.NationalNumber = person.NationalNumber;
            model.FirstName = person.FirstName;
            model.FatherName = person.FatherName;
            model.GrandFatherName = person.GrandFatherName;
            model.LastName = person.LastName;
            model.PhoneNumber = person.PhoneNumber;
            model.BirthDate = person.BirthDate;
            model.MotherName = person.MotherName;
            model.MotherLastName = person.MotherLastName;
            model.RelationshipsID = (int)person.RelationshipStatus;
            if (string.IsNullOrEmpty(person.Image))
                model.ImagePath = null;
            else
                model.ImagePath = Path.Combine(clsFile.GetFullPathOfPersonImagesDirectory(false), person.Image);

            if (string.IsNullOrEmpty(person.NationalIDImage))
                model.NationalImagePath = null;
            else
                model.NationalImagePath = Path.Combine(clsFile.GetFullPathOfPersonImagesDirectory(false), person.NationalIDImage);
            model.addressPartialView = MapAddress(person.AddressID);
            model.CityAndCountry = MapCityAndCountry(person.PlaceOfBirthID);
            return model;
        }
        public clsPersonTableView MapPersonCard(int personID)
        {
            clsPersonFilter filter = new clsPersonFilter();
            filter.PersonID = personID;
            clsPersonTableView person = _personService.GetPersonTableView(filter).FirstOrDefault();
            if(person != null)
            {
                person.FullName = null;
                person.MotherFullName = null;
                return person;
            }
            return null;
        
        }
        public clsAddressPartialView MapAddress(int AddressID)
        {
            clsAddressPartialView AdrsPartialview = new clsAddressPartialView();
            clsAddress address = _addressService.GetAddressByID(AddressID);
            if (address == null)
                return new clsAddressPartialView();
            AdrsPartialview.AddressDetails = address.AddressDetails;
            AdrsPartialview.SelectedNeighborhoodID = address.NeighborhoodID;
            AdrsPartialview.SelectedDistrictID = _addressService.GetNeighborhood(AdrsPartialview.SelectedNeighborhoodID.Value).DistrictID;
            AdrsPartialview.SelectedCityID = _addressService.GetDistrict(AdrsPartialview.SelectedDistrictID.Value).CityID;
            AdrsPartialview.SelectedCountryID = _addressService.GetCity(AdrsPartialview.SelectedCityID.Value).CountryID;

            AdrsPartialview.Counties = _addressService.GetCountryList();
            AdrsPartialview.Cities = _addressService.GetCityList(AdrsPartialview.SelectedCountryID.Value);
            AdrsPartialview.Districts = _addressService.GetDistrictList(AdrsPartialview.SelectedCityID.Value);
            AdrsPartialview.Neighborhoods = _addressService.GetNeighborhoodList(AdrsPartialview.SelectedDistrictID.Value);
            return AdrsPartialview;
        }
        public clsCityAndCountryViewModel MapCityAndCountry(int CityID)
        {
            clsCityAndCountryViewModel CityAndCountryView = new clsCityAndCountryViewModel();
            CityAndCountryView.PlaceOfBirthID = CityID;
            CityAndCountryView.SelectedCountryID = _addressService.GetCity(CityID).CountryID;
            CityAndCountryView.Cities = _addressService.GetCityList(CityAndCountryView.SelectedCountryID);
            CityAndCountryView.countriys = _addressService.GetCountryList();
            return CityAndCountryView;
        }
    }
}

