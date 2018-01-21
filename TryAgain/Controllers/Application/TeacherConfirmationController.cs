using Microsoft.AspNetCore.Mvc;
using TryAgain.Models.Mappers;
using TryAgain.Services.Interfaces;

namespace TryAgain.Controllers.Application
{
    public class TeacherConfirmationController : Controller
    {
        private readonly ApplicationModelMapper _applicationModelMapper;
        private readonly IApplicationService _applicationService;
        private readonly ITeacherConfirmationService _teacherConfirmationService;

        public TeacherConfirmationController(
            IApplicationService applicationService, 
            ITeacherConfirmationService teacherConfirmationService, 
            ApplicationModelMapper applicationModelMapper)
        {
            _applicationService = applicationService;
            _teacherConfirmationService = teacherConfirmationService;
            _applicationModelMapper = applicationModelMapper;
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
            var appViewModel = _applicationModelMapper.MapToViewModel(appModel);
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