using BAL.interfaceCalsses;
using BAL.Mapper;
using DAL.Models;
using DAL.Models.TableFilters;
using Microsoft.AspNetCore.Mvc;
using ViewModel;

namespace Institute_Proj.Controllers.Test
{
    public class TestController : Controller
    {
        ITestService _testService;
        IServiceProvider _service;
        IGroupService _groupService;
        public TestController(ITestService testService,IServiceProvider service,IGroupService groupService)
        {
            _testService=testService;
            _service=service;
            _groupService=groupService;
        }
        public IActionResult Index()
        {
            clsQuranTestViewModel Model = new clsQuranTestViewModel();
          
            return View("TestList", _testService.GetQuranStudentTests(new clsQuranTestFilter()));
        }
        [HttpGet]
        public IActionResult TestQuranStudent(int NominationID)
        {

            Mapper mapper = new Mapper(_service);
            ViewModel.clsQuranTestViewModel model = mapper.MapQuranTest(NominationID);
                ViewBag.Committee = _groupService.GetGroupList();
            return View("TestQuranStudent", model);
        }
        [HttpPost]
        public IActionResult TestQuranStudent(clsQuranTestViewModel model)
        {
            if (ModelState.IsValid == null)
            {
                ViewBag.Committee = _groupService.GetGroupList();
                return View(model);
            }
            Mapper mapper = new Mapper(_service);
           _testService.QuranTest = mapper.MapQuranTest(model);

            if (_testService.SaveQuranTest())
                return RedirectToAction("Index", "Nomination");
            else
                return View(model);
        }
    }
}
