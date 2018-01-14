using Microsoft.AspNetCore.Mvc;
using TryAgain.Models.Forms;

namespace TryAgain.Controllers.Podanie
{
    public class PodanieController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var podanie = new PodanieViewModel
            {
                StudentOrganizujacyKurs = "Bill Gates",
                Data = new DataToPodanieViewModel(),
                Kurs = new KursToPodanieViewModel()
                
            };

            return View(podanie);
        }

        [HttpPost]
        public IActionResult Create(PodanieViewModel podanie)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ShowWarningPopup = true;
                return View(podanie);
            }

            return RedirectToAction("CreateSucccessResult", podanie);
        }


        public IActionResult CreateSucccessResult(PodanieViewModel podanie)
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