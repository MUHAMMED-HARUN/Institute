using BAL.interfaceCalsses;
using BAL.Mapper;
using BAL.ViewModel;
using DAL.Models.TableFilters;
using Microsoft.AspNetCore.Mvc;

namespace Institute_Proj.Controllers.Teacher
{
    public class TeacherController : Controller
    {
        ITeacherService _TeacherService;
        IPersonService _personService;
        public TeacherController(ITeacherService teacherService,IPersonService personService)
        {
            _TeacherService = teacherService;
            _personService = personService;
        }

        public IActionResult Index()
        {
            clsTeacherFilter filter = new clsTeacherFilter();
            filter.TeacherTableView = _TeacherService.GetAll(filter);
            return View("TeacherList",filter);
        }
        public IActionResult Search(clsTeacherFilter filter)
        {
       
            return Json(_TeacherService.GetAll(filter));
        }
  		[HttpGet]
        public IActionResult showTeacherCard(int TeacherID)
        {
            Mapper mapper = new Mapper(_TeacherService,_personService);
            clsTeacherTableViewModel model = mapper.MapTeacherTable(TeacherID);
            return PartialView("TeacherCard", model);
        }
		[HttpGet]
        public IActionResult NewOrEdit(int TeacherID)
        {
			Mapper mapper = new Mapper(_TeacherService, _personService);

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
			Mapper mapper = new Mapper(_TeacherService, _personService);
			_TeacherService.Teacher = mapper.MapTeacher(model);
            if(_TeacherService.Save())
                return RedirectToAction("Index");
            return View(model);
        }
        [HttpGet]
        public IActionResult ShowTeacherCardWithFilter()
        {
            clsTeacherTableViewModel model =new clsTeacherTableViewModel();
            return PartialView("TeacherCardWithFilter", model);
        }
        [HttpPost]
        public IActionResult ShowTeacherCardWithFilter(clsTeacherFilter filter)
        {
            Mapper mapper = new Mapper(_TeacherService, _personService);
            clsTeacherTableViewModel model = mapper.MapTeacherTable(filter);
            return PartialView("TeacherCardWithFilter", model);
        }
        public IActionResult DeleteTeacher(int TeacherID)
        {
            return Json(_TeacherService.Delete(TeacherID));
        }
    }
}
