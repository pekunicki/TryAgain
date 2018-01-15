using Microsoft.AspNetCore.Mvc;
using TryAgain.Services.Interfaces;

namespace TryAgain.Controllers.Application
{
    public class TeacherConfirmationController : Controller
    {
        private readonly IApplicationService _applicationService;
        private readonly ITeacherConfirmationService _teacherConfirmationService;

        public TeacherConfirmationController(
            IApplicationService applicationService, 
            ITeacherConfirmationService teacherConfirmationService)
        {
            _applicationService = applicationService;
            _teacherConfirmationService = teacherConfirmationService;
        }

        [HttpGet]
        public IActionResult GetApplication(string link)
        {
            var confirmationModel = _teacherConfirmationService.TryGetTeacherConfirmationByLink(link);
            if (confirmationModel == null)
            {
                return RedirectToAction("InvalidLink");
            }
            var appModel = _applicationService.GetById(confirmationModel.ApplicationId);
            var appViewModel = _applicationService.CreateApplicationViewModel(appModel);
            //todo consider to delete it, we shouldn't expose this id
            ViewBag.TeacherConfirmationId = confirmationModel.Id;
            return View(appViewModel);
        }

        [HttpPost]
        public IActionResult Accept(int confirmationId)
        {
            _teacherConfirmationService.AcceptTeacherConfirmation(confirmationId);
            return View();
        }

        [HttpPost]
        public IActionResult Reject(int confirmationId)
        {
            _teacherConfirmationService.RejectTeacherConfirmation(confirmationId);
            return View();
        }

        [HttpGet]
        public IActionResult InvalidLink()
        {
            return View();
        }
    }
}