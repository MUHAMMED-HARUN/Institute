using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using BAL.ViewModel;
using BAL.Mapper;
using BAL.interfaceCalsses;
namespace Institute_Proj.Controllers.Student
{
    public class StudentController : Controller
    {
        public readonly IStudentService _studentService;
        public readonly IPersonService _personService;

        public StudentController(IStudentService studentService,IPersonService personService)
        {                   
            _personService = personService;
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult NewOrEdit(int? studentID)
        {
            Mapper mapper = new Mapper(_personService, _studentService);
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
            Mapper mapper = new Mapper(_personService, _studentService);
            _studentService.Student = mapper.MapStudent(Model);
           bool IsSaved= _studentService.Save();
            if(IsSaved)
              return RedirectToAction("Index", "Student");
           else
                return View(Model); 
        }
    }
}
