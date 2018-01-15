using Microsoft.AspNetCore.Mvc;
using TryAgain.Models.Forms;

namespace TryAgain.Controllers.Application
{
    public class ApplicationController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SelectApplicationType()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var app = new ApplicationViewModel
            {
                Organizer = "Bill Gates",
                Date = new DateInApplicationViewModel(),
                Course = new CourseInApplicationViewModel()
                
            };

            return View(app);
        }

        [HttpPost]
        public IActionResult Create(ApplicationViewModel app)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ShowWarningPopup = true;
                return View(app);
            }

            return RedirectToAction("CreateSucccessResult", app);
        }


        public IActionResult CreateSucccessResult(ApplicationViewModel podanie)
        {
            return View();
        }

        public IActionResult GetUserAll()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            return View();
        }
    }
}