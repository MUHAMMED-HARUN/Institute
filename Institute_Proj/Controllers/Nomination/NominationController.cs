using BAL.interfaceCalsses;
using BAL.Mapper;
using DAL.Models.TableFilters;
using DAL.Models.TableViews;
using Microsoft.AspNetCore.Mvc;

namespace Institute_Proj.Controllers.Nomination
{
    public class NominationController : Controller
    {
        ITestService _TestService;
        IServiceProvider _Service;
        public NominationController(IServiceProvider service,ITestService testService)
        {
            _Service = service;
            _TestService = testService;
        }
        public IActionResult Index()
        {
            clsFilterNomination Filter = new clsFilterNomination();
            Filter.NominationTableView = _TestService.GetNominationList(Filter);
            return View("NominationList", Filter);
        }
        public IActionResult Search(clsFilterNomination filter)
        {
            return Json(_TestService.GetNominationList(filter));
        }
        [HttpGet]
        public IActionResult NewOrEdit(int QuranStudentID)
        {
            Mapper mapper = new Mapper(_Service);
            clsNominationTableView Model = mapper.MapNomination(QuranStudentID);
            ViewBag.TestsList = _TestService.GetBasicTestInfos();
            return View("NewOrEdit", Model);
        }
        [HttpPost]
        public IActionResult NewOrEdit(clsNominationTableView Model)
        { 
            ModelState.Remove("TestName");
            ModelState.Remove("QuranStudentFullName");
            if (!ModelState.IsValid)
            {
                ViewBag.TestsList = _TestService.GetBasicTestInfos();
                return View(Model);
            }
            Mapper mapper = new Mapper(_Service);
            _TestService.Nomination = mapper.MapNomination(Model);
            if (_TestService.SaveNominate())
                return RedirectToAction("Index", "QuranStudent");
            return View("NewOrEdit", Model);
        }
    }
}
