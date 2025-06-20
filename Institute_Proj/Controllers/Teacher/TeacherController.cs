using BAL.interfaceCalsses;
using BAL.Mapper;
using BAL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Institute_Proj.Controllers.Teacher
{
    public class TeacherController : Controller
    {
        ITeacherService _TeacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _TeacherService = teacherService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult NewOrEdit(int TeacherID)
        {
            Mapper mapper = new Mapper(_TeacherService);
           
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
            Mapper mapper = new Mapper(_TeacherService);
            _TeacherService.Teacher = mapper.MapTeacher(model);
            if(_TeacherService.Save())
                return RedirectToAction("Index");
            return View(model);
        }
    }
}
