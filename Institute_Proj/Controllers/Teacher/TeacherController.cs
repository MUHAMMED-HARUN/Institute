using BAL.interfaceCalsses;
using BAL.IService;
using BAL.Mapper;
using BAL.ViewModel;
using DAL.Models.TableFilters;
using Institute_Proj.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Institute_Proj.Controllers.Teacher
{

    [Authorize(Roles = clsRoleString.Teacher)]
    public class TeacherController : Controller
    {
        ITeacherService _TeacherService;
        IPersonService _personService;
        IClassService _classService;
        IServiceProvider _service;
        public TeacherController(ITeacherService teacherService, IPersonService personService,IClassService classService, IServiceProvider service)
        {
            _TeacherService = teacherService;
            _personService = personService;
            _classService = classService;
            _service = service;
        }

        public IActionResult Index()
        {
            clsTeacherFilter filter = new clsTeacherFilter();
            filter.TeacherTableView = _TeacherService.GetAll(filter);
            return View("TeacherList", filter);
        }
        public IActionResult Search(clsTeacherFilter filter)
        {

            return Json(_TeacherService.GetAll(filter));
        }
        [HttpGet]
        public IActionResult showTeacherCard(int TeacherID)
        {
            Mapper mapper = new Mapper(_service);
            clsTeacherTableViewModel model = mapper.MapTeacherTable(TeacherID);
            return PartialView("TeacherCard", model);
        }
        [HttpGet]
        public IActionResult NewOrEdit(int TeacherID)
        {
            Mapper mapper = new Mapper(_service);

            clsTeacherViewModel model = mapper.MapTeacher(TeacherID);
            return View(model);
        }
        [HttpPost]
        public IActionResult NewOrEdit(clsTeacherViewModel model)
        {
            List<string> keys = ModelState.Keys.Where(k => k.StartsWith("PersonTable.", StringComparison.OrdinalIgnoreCase)).ToList();
            foreach (string k in keys)
            {
                ModelState.Remove(k);
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            Mapper mapper = new Mapper(_service);
            _TeacherService.Teacher = mapper.MapTeacher(model);
            if (_TeacherService.Save())
                return RedirectToAction("Index");
            return View(model);
        }
        [HttpGet]
        public IActionResult ShowTeacherCardWithFilter()
        {
            clsTeacherTableViewModel model = new clsTeacherTableViewModel();
            return PartialView("TeacherCardWithFilter", model);
        }
        [HttpPost]
        public IActionResult ShowTeacherCardWithFilter(clsTeacherFilter filter, string prefix)
        {
            ViewData.TemplateInfo.HtmlFieldPrefix = prefix;
            Mapper mapper = new Mapper(_service);
            clsTeacherTableViewModel model = mapper.MapTeacherTable(filter);
            return PartialView("TeacherCardWithFilter", model);
        }
        public IActionResult DeleteTeacher(int TeacherID)
        {
            return Json(_TeacherService.Delete(TeacherID));
        }
        [HttpGet]
        public IActionResult EnrollmentList()
        {
            clsEnrolmentTeacherInClassFilter filter = new clsEnrolmentTeacherInClassFilter();
            filter.Enrollments = _TeacherService.GetEnrollmentList(filter);
            return View("EnrollmentTeacherList" ,filter);
        }
        [HttpPost]
        public IActionResult EnrollmentList(clsEnrolmentTeacherInClassFilter filter)
        {
            return Json(_TeacherService.GetEnrollmentList(filter));
        }
        [HttpGet]
        public IActionResult EnrollInClass()
        {
            clsEnrolmentTeacherInClassModel model = new clsEnrolmentTeacherInClassModel();
            model.ClassList = _classService.GetClassList();
            model.EnrollStatus = _TeacherService.GetEnrollmentStatusList();
            return View("EnrollmentTeacher", model);
        }
        [HttpPost]
        public IActionResult EnrollInClass(clsEnrolmentTeacherInClassModel model)
        {
            List<string> keys = ModelState.Keys.Where(k => k.StartsWith("TeacherTable.", StringComparison.OrdinalIgnoreCase)).ToList();


            foreach (string k in keys)
            {
                ModelState.Remove(k);
            }

            if (!ModelState.IsValid)
            {
                model.ClassList = _classService.GetClassList();
                model.EnrollStatus = _TeacherService.GetEnrollmentStatusList();
                return View("EnrollmentTeacher", model);
            }


            Mapper mapper = new Mapper(_service);
            _TeacherService.EnrolmentTeacher = mapper.MapEnrollmentTeacher(model);
            if (_TeacherService.HandleEnrollmentTeacher())
                return RedirectToAction();
            else
                return View("EnrollmentTeacher", model);
        }
    }
}