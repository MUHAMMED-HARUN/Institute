using BAL;
using BAL.interfaceCalsses;
using BAL.Mapper;
using BAL.ViewModel;
using DAL.Models.TableFilters;
using Microsoft.AspNetCore.Mvc;

namespace Institute_Proj.Controllers.Student
{
    public class QuranStudentController : Controller
    {
        IServiceProvider _service;
        IProjectService _projectService;
        IQuranStudentService _quranStudentService;
        public QuranStudentController(IProjectService projectService,IQuranStudentService quranStudentService ,IServiceProvider provider)
        {
            _projectService = projectService;
            _quranStudentService = quranStudentService;
            _service = provider;
        }
        public IActionResult Index()
        {
            clsQuranStudentFilter filter =new clsQuranStudentFilter();
            filter.Projects = _projectService.GetAll();
            filter.QuranStudentTableView = _quranStudentService.GetAll(filter);

            return View("QuranStudentList", filter);
        }
        [HttpGet]
        public IActionResult NewOrEdit(int QuranStudentID)
        {
            Mapper mapper =new  Mapper(_service);
            clsQuranStudentModel model =mapper.MapQuranStudent(QuranStudentID);


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
            Mapper mapper = new Mapper(_service);
            _quranStudentService.QuranStudent = mapper.MapQuranStudent(model);

            if (_quranStudentService.Save())
                return RedirectToAction("Index");
            else
                return NotFound();
        }
        [HttpPost]
        public IActionResult Search(clsQuranStudentFilter filter)
        {
            return Json(_quranStudentService.GetAll(filter));
        }
    }
}
