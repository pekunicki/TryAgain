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
            ViewBag.Link = link;
            return View(appViewModel);
        }

        [HttpGet]
        public IActionResult Accept(string link)
        {
            var confirmationModel = _teacherConfirmationService.TryGetTeacherConfirmationByLink(link);
            if (confirmationModel == null)
            {
                return RedirectToAction("InvalidLink");
            }

            _teacherConfirmationService.AcceptTeacherConfirmation(confirmationModel.Id);
            return View();
        }

        [HttpGet]
        public IActionResult Reject(string link)
        {
            var confirmationModel = _teacherConfirmationService.TryGetTeacherConfirmationByLink(link);
            if (confirmationModel == null)
            {
                return RedirectToAction("InvalidLink");
            }

            _teacherConfirmationService.RejectTeacherConfirmation(confirmationModel.Id);
            return View();
        }

        [HttpGet]
        public IActionResult InvalidLink()
        {
            return View();
        }
    }
}