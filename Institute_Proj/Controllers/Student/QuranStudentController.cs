using BAL;
using BAL.interfaceCalsses;
using BAL.Mapper;
using BAL.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Institute_Proj.Controllers.Student
{
    public class QuranStudentController : Controller
    {
        IProjectService _projectService;
        IQuranStudentService _quranStudentService;
        public QuranStudentController(IProjectService projectService,IQuranStudentService quranStudentService)
        {
            _projectService = projectService;
            _quranStudentService = quranStudentService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult NewOrEdit()
        {
            clsQuranStudentModel model = new clsQuranStudentModel();
            model.ProjectList = _projectService.GetAll();
            model.PerformanceRatings =GlobalVar.GetPerformanceRating();
            return View("NewOrEdit", model);
        }
        [HttpPost]
        public IActionResult NewOrEdit(clsQuranStudentModel model)
        {
            List<string> keys = ModelState.Keys.Where(k => k.StartsWith("studentTable.", StringComparison.OrdinalIgnoreCase)).ToList();


            foreach (string k in keys)
            {
                ModelState.Remove(k);
            }
            if (!ModelState.IsValid)
            {
                model.ProjectList = _projectService.GetAll();
                model.PerformanceRatings = GlobalVar.GetPerformanceRating();
                return View(model);
            }
            Mapper mapper = new Mapper(_quranStudentService, _projectService);
            _quranStudentService.QuranStudent = mapper.MapQuranStudent(model);

            if (_quranStudentService.Save())
                return RedirectToAction("Index");
            else
                return NotFound();
        }
    }
}
