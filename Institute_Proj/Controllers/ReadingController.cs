using BAL;
using BAL.interfaceCalsses;
using BAL.Mapper;
using BAL.ViewModel;
using DAL.Models;
using DAL.Models.TableFilters;
using Microsoft.AspNetCore.Mvc;

namespace Institute_Proj.Controllers
{
    public class ReadingController : Controller
    {
        IReadingService _readingService;
        IServiceProvider _service;
        IQuranStudentService _QuranstudentService;
        public ReadingController(IReadingService readingService, IServiceProvider service)
        {
            _readingService = readingService;
            _service = service;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<clsReadingDay> model =_readingService.GetAllReadingDays();
            return View("ReadingDayList", model);
        }
        [HttpGet]
        public IActionResult NewOrEditReadingDay()
        {
            clsReadingDay model = new clsReadingDay();

            return View("NewOrEditReadingDay", model);
         
        }

        [HttpPost]
      public IActionResult NewOrEditReadingDay(clsReadingDay model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (_readingService.CreateReadingDay(model) > 0)
                return RedirectToAction("Index");
            else
                return NotFound("خطا في الحفظ");
        }


        [HttpGet]
        public IActionResult ReadingList(int ReadingDay)
        {
            
            List<clsReading> model = _readingService.GetReadingsByDayID(ReadingDay);
            return View("ReadingList", model);
        }
        //[HttpGet]
        //public IActionResult EditReading(int ReadingID)
        //{
        //    clsReading reading = new clsReading();
        //    if(ID > 0)
        //        reading .ID = ID;
        //    reading.ReadingDayID = ReadingDayID;
        //    return View(reading);
        //}
        [HttpGet]
        public IActionResult NewOrEditReading(int QuranStudentID,int ReadingDayID)
        {
            _QuranstudentService = (IQuranStudentService)_service.GetService(typeof(IQuranStudentService));

            clsReadingModel model = new clsReadingModel();
            clsQuranStudentFilter filter = new clsQuranStudentFilter();

            filter.QuranStudentID = QuranStudentID;
            model.QuranStudentName= _QuranstudentService.GetAll(filter).FirstOrDefault().FullName;
            model.QuranStudentID = QuranStudentID;

            model.ReadingDay = _readingService.GetReadingDayByID(ReadingDayID).ReadingDate;
            model.ReadingDayID = ReadingDayID;

            model.PerformaceList = GlobalVar.GetPerformanceRating();
            model.ReadingTypeList = GlobalVar.GetReadingType();
            return View(model);
        }
        public IActionResult NewOrEditReading(clsReading model)  
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_readingService.CreateReading(model) > 0)
                return RedirectToAction("ReadingList");
            else
                return NotFound("خطا في الاضافة");
        }
    }
}
