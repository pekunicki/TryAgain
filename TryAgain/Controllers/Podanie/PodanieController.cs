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
            var podanie = new PodanieFormModel
            {
                StudentOrganizujacyKurs = "Bill Gates",
                Data = new DataToPodanieFormModel(),
                Kurs = new KursToPodanieFormModel()
                
            };

            return View(podanie);
        }

        [HttpPost]
        public IActionResult Create(PodanieFormModel podanie)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ShowWarningPopup = true;
                return View(podanie);
            }

            return RedirectToAction("CreateSucccessResult", podanie);
        }


        public IActionResult CreateSucccessResult(PodanieFormModel podanie)
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