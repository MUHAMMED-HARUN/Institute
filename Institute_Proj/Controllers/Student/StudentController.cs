using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using BAL.ViewModel;
using BAL.Mapper;
using BAL.interfaceCalsses;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
namespace Institute_Proj.Controllers.Student
{
    public class StudentController : Controller
    {
        public readonly IStudentService _studentService;
        public readonly IPersonService _personService;
        public readonly IClassService _classService;
        IServiceProvider _service;
        public StudentController(IStudentService studentService,IPersonService personService ,IClassService classService,IServiceProvider provider)
        {                   
            _personService = personService;
            _studentService = studentService;
            _classService = classService;
            _service = provider;
        }
        public IActionResult Index()
        {
            clsStudentFilter StudentFilter = new clsStudentFilter();
            StudentFilter.studentTableView = _studentService.GetList(StudentFilter);
            return View("StudentList", StudentFilter);
        }
        public IActionResult Search(clsStudentFilter StudentFilter)
        {
            return Json(_studentService.GetList(StudentFilter));
        }
        [HttpGet]
        public IActionResult NewOrEdit(int? studentID)
        {
            Mapper mapper = new Mapper(_service);
            clsStudentViewModel model = mapper.MapStudent(studentID??-1);
            return View(model);
        }
        [HttpPost]
        public IActionResult NewOrEdit(clsStudentViewModel Model)
        {
          List<string> keys=  ModelState.Keys.Where(k => k.StartsWith("PersonTable.", StringComparison.OrdinalIgnoreCase)).ToList();

            foreach (string k in keys)
            {
                ModelState.Remove(k);
            }
            
            if (!ModelState.IsValid)
                return View(Model);
            Mapper mapper = new Mapper(_service);
            _studentService.Student = mapper.MapStudent(Model);
           bool IsSaved= _studentService.Save();
            if(IsSaved)
              return RedirectToAction("Index", "Student");
           else
                return View(Model); 
        }
        [HttpGet]
        public IActionResult ShowStudentCard(int StudentID)
        {
            Mapper mapper = new Mapper(_service);
            clsStudentTableVieweModel Model = mapper.MapStudentTable(StudentID);
            return PartialView("StudentCard", Model);
        }
        [HttpGet]
        public IActionResult ShowStudentCardWithFilter()
        {
            clsStudentTableVieweModel studentTableView = new clsStudentTableVieweModel();
            return PartialView("StudentCardWithFilter", studentTableView);
        }
        [HttpPost]
        public IActionResult ShowStudentCardWithFilter(clsStudentFilter studentFilter ,string prefix)
        {
            ViewData.TemplateInfo.HtmlFieldPrefix = prefix;
            Mapper mapper = new Mapper(_service);
            return PartialView("StudentCardWithFilter", mapper.MapStudentTable(studentFilter));
        }
        public IActionResult DeleteStudent(int StudentID) 
        {
            if (_studentService.IsExist(StudentID))
                return Json(_studentService.Delete(StudentID));
            else
                return Json(false);
        }
        public IActionResult EnrollInClass()
        {
            clsEnrolmentStudentInClassModel model = new clsEnrolmentStudentInClassModel();
            model.ClassList=_classService.GetClassList();
            model.EnrollStatus=_studentService.GetEnrollmentStatusList();
            return View("EnrollmentStudent", model);

        }
        [HttpPost]
        public IActionResult EnrollInClass(clsEnrolmentStudentInClassModel model)
        {
            List<string> keys = ModelState.Keys.Where(k => k.StartsWith("studentTable.", StringComparison.OrdinalIgnoreCase)).ToList();

            foreach (string k in keys)
            {
                ModelState.Remove(k);
            }

            if (!ModelState.IsValid)
            {
                model.ClassList = _classService.GetClassList();
                model.EnrollStatus = _studentService.GetEnrollmentStatusList();
                return View("EnrollmentStudent", model);
            }


            Mapper mapper = new Mapper(_service);
            _studentService.EnrolmentStudentInClass = mapper.MapEnrollmentStudent(model);
            if (_studentService.HandleEnrollmentStudent())
                return RedirectToAction();
           else
            return View("EnrollmentStudent", model);

        }
        [HttpGet]
        public IActionResult EnrollmentList()
        {
			 clsEnrollmentStudentInClassFilter Filter = new clsEnrollmentStudentInClassFilter();
            Filter.EnrollmentTable = _studentService.GetEnrollmentTableView(Filter);

            return View("EnrollmentList", Filter);
        }
        [HttpPost]
        public IActionResult EnrollmentList( clsEnrollmentStudentInClassFilter Filter)
        {
            
            return Json(_studentService.GetEnrollmentTableView(Filter));
        }
    }
}
