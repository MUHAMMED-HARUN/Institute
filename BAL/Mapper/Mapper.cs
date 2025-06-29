using BAL.interfaceCalsses;
using BAL.IService;
using BAL.ViewModel;
using DAL.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Buffers.Text;
using System.Net.NetworkInformation;
using DAL.Models.TableViews;
using DAL.Models.TableFilters;
using DAL.interfaceCalsses;
namespace BAL.Mapper
{
    public class Mapper
    {
        IServiceProvider _service;
        IPersonService _personService;
        IAddressService _addressService;
        IStudentService _studentService;
        IClassService _classService;
        ITeacherService _teacherService;
        IProjectService _projectService;
        IQuranStudentService _quranStudentService;
        IReadingService _readingService;
        public Mapper(IServiceProvider service)
        {
            _service = service;
        }

        public clsPerson MapPerson(clsPersonViewModel model)
        {
            _personService = (IPersonService)_service.GetService(typeof(IPersonService));
            if (_personService == null)
                return new clsPerson();
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
                _personService.Person.NationalIDImage = Path.GetFileName(model.NationalImagePath);

            return _personService.Person;
        }
        public clsAddress MapAddress(clsAddressPartialView addressPartialView)
        {
            _personService = (IPersonService)_service.GetService(typeof(IPersonService));
            if (_personService == null)
                return new clsAddress();
            _personService.Address = new clsAddress();

            if (addressPartialView.SelectedNeighborhoodID.HasValue)
                _personService.Address.NeighborhoodID = addressPartialView.SelectedNeighborhoodID.Value;

            _personService.Address.AddressDetails = addressPartialView.AddressDetails;
            return _personService.Address;

        }
        public clsPersonViewModel MapPerson(int PersonID)
        {
            _personService = (IPersonService)_service.GetService(typeof(IPersonService));
            if (_personService == null)
                return new clsPersonViewModel();

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
            _personService = (IPersonService)_service.GetService(typeof(IPersonService));
            if (_personService == null)
                return new clsPersonTableView();

            clsPersonFilter filter = new clsPersonFilter();
            filter.PersonID = personID;
            clsPersonTableView person = _personService.GetPersonTableView(filter).FirstOrDefault();
            if (person != null)
            {
                clsFile file =new clsFile();
                person.FullName = null;
                person.MotherFullName = null;
                person.Image = Path.Combine(clsFile.GetFullPathOfPersonImagesDirectory(false), person.Image);
                person.NationalIDImage= Path.Combine(clsFile.GetFullPathOfPersonImagesDirectory(false), person.NationalIDImage);
                return person;
            }
            return new clsPersonTableView();

        }
        public clsPersonTableView MapPersonCard(clsStudentTableView studentTableView)
        {

            if (studentTableView != null)
            {
                clsPersonTableView person = new clsPersonTableView();
                clsFile file = new clsFile();
                person.PersonID= studentTableView.PersonID??-1;
                person.NationalNumber = studentTableView.NationalNumber;
                person.FirstName = studentTableView.FirstName;
                person.FatherName = studentTableView.FatherName;
                person.GrandFatherName = studentTableView.GrandFatherName;
                person.LastName = studentTableView.LastName;
                person.MotherName = studentTableView.MotherName;
                person.MotherLastName = studentTableView.MotherLastName;
                person.GendorText = studentTableView.GendorText;
                person.PhoneNumber = studentTableView.PhoneNumber;
                person.CountryName = studentTableView.CountryName;
                person.AddressCityName = studentTableView.AddressCityName;
                person.DistrictName = studentTableView.DistrictName;
                person.NeighborhoodName = studentTableView.NeighborhoodName;
                person.AddressDetails = studentTableView.AddressDetails;
                person.PlaceOfBirthName = studentTableView.PlaceOfBirthName;
                person.BirthDate = studentTableView.BirthDate??DateTime.MinValue;
                person.PersonalStatus = studentTableView.PersonalStatus;
                person.Image = Path.Combine(clsFile.GetFullPathOfPersonImagesDirectory(false), studentTableView.Image);
                person.NationalIDImage = Path.Combine(clsFile.GetFullPathOfPersonImagesDirectory(false), studentTableView.NationalIDImage);
                return person;
            }
            return new clsPersonTableView();

        }
		public clsPersonTableView MapPersonCard(clsTeacherTableView TeacherTableView)
		{

			if (TeacherTableView != null)
			{
				clsPersonTableView person = new clsPersonTableView();
				clsFile file = new clsFile();
				person.PersonID = TeacherTableView.PersonID ?? -1;
				person.NationalNumber = TeacherTableView.NationalNumber;
				person.FirstName = TeacherTableView.FirstName;
				person.FatherName = TeacherTableView.FatherName;
				person.GrandFatherName = TeacherTableView.GrandFatherName;
				person.LastName = TeacherTableView.LastName;
				person.MotherName = TeacherTableView.MotherName;
				person.MotherLastName = TeacherTableView.MotherLastName;
				person.GendorText = TeacherTableView.GendorText;
				person.PhoneNumber = TeacherTableView.PhoneNumber;
				person.CountryName = TeacherTableView.CountryName;
				person.AddressCityName = TeacherTableView.AddressCityName;
				person.DistrictName = TeacherTableView.DistrictName;
				person.NeighborhoodName = TeacherTableView.NeighborhoodName;
				person.AddressDetails = TeacherTableView.AddressDetails;
				person.PlaceOfBirthName = TeacherTableView.PlaceOfBirthName;
				person.BirthDate = TeacherTableView.BirthDate ?? DateTime.MinValue;
				person.PersonalStatus = TeacherTableView.PersonalStatus;
				person.Image = Path.Combine(clsFile.GetFullPathOfPersonImagesDirectory(false), TeacherTableView.Image);
				person.NationalIDImage = Path.Combine(clsFile.GetFullPathOfPersonImagesDirectory(false), TeacherTableView.NationalIDImage);
				return person;
			}
			return new clsPersonTableView();

		}
		public clsAddressPartialView MapAddress(int AddressID)
        {
            _addressService = (IAddressService)_service.GetService(typeof(IAddressService));
            if (_addressService == null)
                return new clsAddressPartialView();

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
            _addressService = (IAddressService)_service.GetService(typeof(IAddressService));
            if (_addressService == null)
                return new clsCityAndCountryViewModel();

            clsCityAndCountryViewModel CityAndCountryView = new clsCityAndCountryViewModel();
            CityAndCountryView.PlaceOfBirthID = CityID;
            CityAndCountryView.SelectedCountryID = _addressService.GetCity(CityID).CountryID;
            CityAndCountryView.Cities = _addressService.GetCityList(CityAndCountryView.SelectedCountryID);
            CityAndCountryView.countriys = _addressService.GetCountryList();
            return CityAndCountryView;
        }
        public clsStudent MapStudent(clsStudentViewModel model)
        {

            _studentService = (IStudentService)_service.GetService(typeof(IStudentService));
            if (_studentService == null)
                return new clsStudent();

            if (model.StudentID.HasValue)
            {
                _studentService.Student = _studentService.GetByStudentID(model.StudentID.Value);
                _studentService.SaveMode = GlobalVar._SaveMode.Update;
            }
            else
            {
                _studentService.Student = new clsStudent();
            _studentService.SaveMode =  GlobalVar._SaveMode.New;

            }

            if (_studentService.Student == null)
                _studentService.Student = new clsStudent();

            _studentService.Student.PersonID = model.PersonID;
            _studentService.Student.EntryDate= model.EntryDate;
            _studentService.Student.ExitDate = model.ExitDate;
            _studentService.Student.IsActive= model.IsActive;
           
			//  AuditableEntity;
            return _studentService.Student;
		}
        public clsStudentViewModel MapStudent(int  studentID)
        {
            _studentService = (IStudentService)_service.GetService(typeof(IStudentService));
            if (_studentService == null)
                return new clsStudentViewModel();

            if ( studentID <= 0)
                return new clsStudentViewModel();

            clsStudent student =_studentService.GetByStudentID(studentID);

            if (student == null)
                return new clsStudentViewModel();

            clsStudentViewModel model= new clsStudentViewModel();
            model.StudentID = student.ID;

            model.PersonTable = MapPersonCard(student.PersonID);
            model.EntryDate = student.EntryDate;
            model.ExitDate = student.ExitDate;
            model.IsActive = student.IsActive;
            model.PersonID = student.PersonID;
            return model;
        }
        public clsStudentTableVieweModel MapStudentTable (int studentID)
        {
            _studentService = (IStudentService)_service.GetService(typeof(IStudentService));
            if (_studentService == null)
                return new clsStudentTableVieweModel();

            clsStudentTableVieweModel model = new clsStudentTableVieweModel();
            clsStudentFilter studentFilter = new clsStudentFilter();
            studentFilter.StudentID = studentID;
            clsStudentTableView StudentView = _studentService.GetList(studentFilter).FirstOrDefault();
            if(StudentView != null)
            {
                model.clsPersonViewModel = MapPersonCard(StudentView);

                model.StudentID = StudentView.StudentID ?? -1;
                model.EntryDate = StudentView.EntryDate??DateTime.MinValue;
                model.ExitDate = StudentView.ExitDate ?? DateTime.MinValue;
                model.IsActive = StudentView.IsActive;

                return model;
            }
            return new clsStudentTableVieweModel();
        }
        public clsStudentTableVieweModel MapStudentTable(clsStudentFilter studentFilter)
        {

            _studentService = (IStudentService)_service.GetService(typeof(IStudentService));
            if (_studentService == null)
                return new clsStudentTableVieweModel();

            clsStudentTableVieweModel model = new clsStudentTableVieweModel();
            clsStudentTableView StudentView = _studentService.GetList(studentFilter).FirstOrDefault();
            if (StudentView != null)
            {
                model.clsPersonViewModel = MapPersonCard(StudentView);

                model.StudentID = StudentView.StudentID ?? -1;
                model.EntryDate = StudentView.EntryDate ?? DateTime.MinValue;
                model.ExitDate = StudentView.ExitDate ?? DateTime.MinValue;
                model.IsActive = StudentView.IsActive;

                return model;
            }
            return new clsStudentTableVieweModel();
        }
        public clsEnrolmentStudentInClass MapEnrollmentStudent(clsEnrolmentStudentInClassModel model)
        {

            _studentService = (IStudentService)_service.GetService(typeof(IStudentService));
            if (_studentService == null)
                return new clsEnrolmentStudentInClass();

            clsEnrolmentStudentInClass EnrollmentStudent=new clsEnrolmentStudentInClass();
            if (model.EnrollmentID > 0)
            {
                EnrollmentStudent = _studentService.GetEnrolmentStudentInClass(model.EnrollmentID);
                _studentService.SaveMode = GlobalVar._SaveMode.Update;
            }
            else if(EnrollmentStudent==null || model.EnrollmentID <= 0)
            {
                EnrollmentStudent = new clsEnrolmentStudentInClass();
                _studentService.SaveMode = GlobalVar._SaveMode.New; 
            }
            EnrollmentStudent.ID = model.EnrollmentID;
            EnrollmentStudent.StudentID = model.StudentID ;
            EnrollmentStudent.ClassID = model.ClassID;
            EnrollmentStudent.StudentID = model.StudentID;
            EnrollmentStudent.EnrolmentDate = model.EnrolmentDate.Value;
            EnrollmentStudent.EnrollmentEndDate = model.EnrollmentEndDate??DateTime.MinValue;
            EnrollmentStudent.EnrollmentStatus = model.EnrollmentStatus;
            // AuditableEntityID
            return  EnrollmentStudent;
        }
        public clsEnrolmentStudentInClassModel MapEnrollmentStudent(int EnrollmentStudentID)
        {
            _studentService = (IStudentService)_service.GetService(typeof(IStudentService));
            if (_studentService == null)
                return new clsEnrolmentStudentInClassModel();

            _classService = (IClassService)_service.GetService(typeof(IClassService));
            if (_classService == null)
                return new clsEnrolmentStudentInClassModel();

            clsEnrolmentStudentInClass EnrollmentInClass= _studentService.GetEnrolmentStudentInClass(EnrollmentStudentID);
            if(EnrollmentInClass==null)
                return new clsEnrolmentStudentInClassModel();
            
            clsEnrolmentStudentInClassModel model = new clsEnrolmentStudentInClassModel();
        
            model.EnrollmentID = EnrollmentInClass.ID;
            model.ClassID = EnrollmentInClass.ClassID;
            model.StudentID = EnrollmentInClass.StudentID;
            model.EnrolmentDate =EnrollmentInClass.EnrolmentDate;
            model.EnrollmentEndDate = EnrollmentInClass.EnrollmentEndDate;
            model.EnrollmentStatus = EnrollmentInClass.EnrollmentStatus;
            model.studentTable = MapStudentTable(model.StudentID);
            model.ClassList = _classService.GetClassList();
            return model;
        }
        public clsTeacherViewModel MapTeacher(int teacherID)
        {
            _teacherService = (ITeacherService)_service.GetService(typeof(ITeacherService));
            if (_teacherService == null)
                return new clsTeacherViewModel();

            if (teacherID <= 0)
                return new clsTeacherViewModel();

            clsTeacher teacher = _teacherService.GetByID(teacherID);

            if (teacher == null)
                return new clsTeacherViewModel();

            clsTeacherViewModel model = new clsTeacherViewModel();
            model.TeacherID = teacher.ID;

            model.PersonTable = MapPersonCard(teacher.PersonID);
            model.EntryDate = teacher.EntryDate;
            model.ExitDate = teacher.ExitDate ?? DateTime.MinValue;
            model.IsActive = teacher.IsActive;
            model.PersonID = teacher.PersonID;

            return model;
        }
        public clsTeacher MapTeacher(clsTeacherViewModel model)
        {
            _teacherService = (ITeacherService)_service.GetService(typeof(ITeacherService));
            if (_teacherService == null)
                return new clsTeacher();

            if (model.TeacherID > 0)
            {
                _teacherService.Teacher = _teacherService.GetByID(model.TeacherID);
                if (_teacherService.Teacher != null)
                    _teacherService.SaveMode = GlobalVar._SaveMode.Update;
            }
            else
            {
                _teacherService.Teacher = null;
                _teacherService.SaveMode = GlobalVar._SaveMode.New;
            }


            if (_teacherService.Teacher == null)
                _teacherService.Teacher = new clsTeacher();

            _teacherService.Teacher.PersonID = model.PersonID;
            _teacherService.Teacher.EntryDate = model.EntryDate;
            _teacherService.Teacher.ExitDate = model.ExitDate;
            _teacherService.Teacher.IsActive = model.IsActive;

            return _teacherService.Teacher;
        }
         
		public clsTeacherTableViewModel MapTeacherTable(int teacherID)
		{
            _teacherService = (ITeacherService)_service.GetService(typeof(ITeacherService));
            if (_teacherService == null)
                return new clsTeacherTableViewModel();

            clsTeacherTableViewModel model = new clsTeacherTableViewModel();
			clsTeacherFilter teacherFilter = new clsTeacherFilter();
			teacherFilter.TeacherID = teacherID;
			clsTeacherTableView TeacherView = _teacherService.GetAll(teacherFilter).FirstOrDefault();
			if (TeacherView != null)
			{
				model.clsPersonViewModel = MapPersonCard(TeacherView);

				model.TeacherID = TeacherView.TeacherID ?? -1;
				model.EntryDate = TeacherView.EntryDate ?? DateTime.MinValue;
				model.ExitDate = TeacherView.ExitDate ?? DateTime.MinValue;
				model.IsActive = TeacherView.IsActiveText;

				return model;
			}
			return new clsTeacherTableViewModel();
		}
        public clsTeacherTableViewModel MapTeacherTable(clsTeacherFilter teacherFilter)
        {
            _teacherService = (ITeacherService)_service.GetService(typeof(ITeacherService));
            if (_teacherService == null)
                return new clsTeacherTableViewModel();

            clsTeacherTableViewModel model = new clsTeacherTableViewModel();
            clsTeacherTableView TeacherTable = _teacherService.GetAll(teacherFilter).FirstOrDefault();
            if (TeacherTable != null)
            {
                model.clsPersonViewModel = MapPersonCard(TeacherTable);

                model.TeacherID = TeacherTable.TeacherID ?? -1;
                model.EntryDate = TeacherTable.EntryDate ?? DateTime.MinValue;
                model.ExitDate = TeacherTable.ExitDate ?? DateTime.MinValue;
                model.IsActive = TeacherTable.IsActiveText;

                return model;
            }
            return new clsTeacherTableViewModel();
        }
        public clsEnrolmentTeacherInClass MapEnrollmentTeacher(clsEnrolmentTeacherInClassModel model)
        {
            _teacherService = (ITeacherService)_service.GetService(typeof(ITeacherService));
            if (_teacherService == null)
                return new clsEnrolmentTeacherInClass();

            clsEnrolmentTeacherInClass EnrollmentTeacher = new clsEnrolmentTeacherInClass();
            if (model.EnrollmentID > 0)
            {
                EnrollmentTeacher = _teacherService.GetEnrolmentTeacherInClass(model.EnrollmentID);
                _teacherService.SaveMode = GlobalVar._SaveMode.Update;
            }
            else if (EnrollmentTeacher == null || model.EnrollmentID <= 0)
            {
                EnrollmentTeacher = new clsEnrolmentTeacherInClass();
                _teacherService.SaveMode = GlobalVar._SaveMode.New;
            }
            EnrollmentTeacher.ID = model.EnrollmentID;
            EnrollmentTeacher.TeacherID = model.TeacherID;
            EnrollmentTeacher.ClassID = model.ClassID;
            EnrollmentTeacher.EnrolmentDate = model.EnrolmentDate.Value;
            EnrollmentTeacher.EndEnrolmentDate = model.EnrollmentEndDate ?? DateTime.MinValue;
            EnrollmentTeacher.EnrollmentStatus = model.EnrollmentStatus;
            // AuditableEntityID
            return EnrollmentTeacher;
        }
        public clsQuranStudent MapQuranStudent(clsQuranStudentModel model)
        {
            _quranStudentService = (IQuranStudentService)_service.GetService(typeof(IQuranStudentService));
            if (_quranStudentService == null)
                return new clsQuranStudent();

            if (model.ID > 0)
            {
                _quranStudentService.QuranStudent = _quranStudentService.GetByID(model.ID);
                if (_quranStudentService.QuranStudent != null)
                    _quranStudentService.SaveMode = GlobalVar._SaveMode.Update;
            }
            else
            {
                _quranStudentService.QuranStudent = null;
                _quranStudentService.SaveMode = GlobalVar._SaveMode.New;
            }


            if (_quranStudentService.QuranStudent == null)
                _quranStudentService.QuranStudent = new clsQuranStudent();

  
            _quranStudentService.QuranStudent.StudentID = model.StudentID;
            _quranStudentService.QuranStudent.TotalSavedPages = model.TotalSavedPages;
            _quranStudentService.QuranStudent.TotalInstalledParts = model.TotalInstalledParts;
            _quranStudentService.QuranStudent.performanceRating = model.performanceRating;
            _quranStudentService.QuranStudent.ProjectID = model.ProjectID;



            //_quranStudentService.QuranStudent.AuditableEntityID = model.a;


            return _quranStudentService.QuranStudent;
        }
        public clsQuranStudentModel MapQuranStudent(int QuranstudentID)
        {
            _quranStudentService = (IQuranStudentService)_service.GetService(typeof(IQuranStudentService));
            if (_quranStudentService == null)
                return new clsQuranStudentModel();

            _quranStudentService.SaveMode = GlobalVar._SaveMode.New;


            if (QuranstudentID <= 0)
                return new clsQuranStudentModel();

            clsQuranStudent quranstudent = _quranStudentService.GetByID(QuranstudentID);

            if (quranstudent == null)
                return new clsQuranStudentModel();

            _quranStudentService.SaveMode = GlobalVar._SaveMode.Update;
            clsQuranStudentModel model = new clsQuranStudentModel();
            model.ID = quranstudent.ID;
            model.studentTable = MapStudentTable(quranstudent.StudentID);
            model.StudentID = quranstudent.StudentID;
            model.TotalSavedPages = quranstudent.TotalSavedPages;
            model.TotalInstalledParts = quranstudent.TotalInstalledParts??0;
            model.ProjectID = quranstudent.ProjectID ?? 0;
            model.performanceRating = quranstudent.performanceRating ?? 0;
            return model;
        }
        public clsReading MapReading(clsReadingModel model)
        {
            _readingService = (IReadingService)_service.GetService(typeof(IReadingService));
            if (_readingService == null)
                return new clsReading();

            if (model.ReadingID > 0)
            {
                _readingService.SaveMode = GlobalVar._SaveMode.Update;
                _readingService.Reading = _readingService.GetReadingByID(model.ReadingID);
				_readingService.Reading.ReadedPageNum = model.ReadedPageNumer;
				if (_readingService.Reading == null)
				{
					_readingService.Reading = new clsReading();
					_readingService.SaveMode = GlobalVar._SaveMode.New;
				}
			}
            else
            {
                _readingService.Reading = new clsReading();

				_readingService.SaveMode = GlobalVar._SaveMode.New;
                _readingService.Reading.ReadedPageNum = (short)(_readingService.GetLastReadedPageNum(model.QuranStudentID)-1);
			}

        
        //_readingService.Reading.ID=model.ReadingID;

            _readingService.Reading.PerformanceRating = model.PerformaceRating;
            _readingService.Reading.ReadigType = model.readingType;
            _readingService.Reading.ReadingDayID = model.ReadingDayID;
            _readingService.Reading.QuranStudentID= model.QuranStudentID;

            return _readingService.Reading;
        }
        public clsReadingModel MapReading(int ReadingID )
        {
            _readingService = (IReadingService)_service.GetService(typeof(IReadingService));
            _quranStudentService = (IQuranStudentService)_service.GetService(typeof(IQuranStudentService));
            _studentService = (IStudentService)_service.GetService(typeof(IStudentService));
            if (_readingService == null&& _studentService==null)
                return new clsReadingModel();

            _readingService.Reading=_readingService.GetReadingByID(ReadingID);
            if (_readingService.Reading != null)
                _readingService.SaveMode = GlobalVar._SaveMode.Update;

            else
            {
                _readingService.SaveMode = GlobalVar._SaveMode.New;
                return new clsReadingModel();
            }
            clsReadingModel model = new clsReadingModel();

            model.ReadingID = _readingService.Reading.ID;
            model.ReadedPageNumer = _readingService.Reading.ReadedPageNum;
            model.PerformaceRating = _readingService.Reading.PerformanceRating;
            model.readingType = _readingService.Reading.ReadigType;
            model.ReadingDayID = _readingService.Reading.ReadingDayID;
            model.QuranStudentID = _readingService.Reading.QuranStudentID;
            model.ReadingDay = _readingService.GetReadingDayByID(model.ReadingDayID).ReadingDate;

            clsQuranStudentFilter filter =new clsQuranStudentFilter();
            filter.QuranStudentID = model.QuranStudentID;
            model.QuranStudentName = _quranStudentService.GetAll(filter).FirstOrDefault().FullName;

            return model;
        }
      public clsReadingModel MapReadingBuQuranStudentID(int QuranStudentID)
        {
            _quranStudentService = (IQuranStudentService)_service.GetService(typeof(IQuranStudentService));
            _readingService = (IReadingService)_service.GetService(typeof(IReadingService));

            clsReadingModel model = new clsReadingModel();
            clsQuranStudentFilter filter = new clsQuranStudentFilter();

            filter.QuranStudentID = QuranStudentID;

            model.QuranStudentName = _quranStudentService.GetAll(filter).FirstOrDefault()?.FullName;
            model.QuranStudentID = QuranStudentID;


            clsReadingDay readingDay = new clsReadingDay();
                readingDay = _readingService.GetLastReadingDay();
            model.ReadedPageNumer= _readingService.GetLastForReadingPageNum(QuranStudentID);
            model.ReadingDay = readingDay.ReadingDate;
            model.ReadingDayID = readingDay.ID;
            return (model);
        }
    }
}

