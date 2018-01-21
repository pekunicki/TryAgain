using Microsoft.AspNetCore.Mvc;
using TryAgain.Models.Creators;
using TryAgain.Models.Mappers;
using TryAgain.Models.ViewModels;
using TryAgain.Services.Interfaces;

namespace TryAgain.Controllers.Application
{
    public class ApplicationController : Controller
    {
        private readonly ApplicationModelMapper _applicationModelMapper;
        private readonly IApplicationService _applicationService;
        private readonly IUserService _userService;
        private readonly ITeacherConfirmationService _teacherConfirmationService;
        private readonly ICourseService _courseService;
        private readonly ITeacherService _teacherService;

        public ApplicationController(
            IApplicationService applicationService, 
            IUserService userService, 
            ITeacherConfirmationService teacherConfirmationService,
            ICourseService courseService, 
            ITeacherService teacherService, 
            ApplicationModelMapper applicationModelMapper)
        {
            _applicationService = applicationService;
            _userService = userService;
            _teacherConfirmationService = teacherConfirmationService;
            _courseService = courseService;
            _teacherService = teacherService;
            _applicationModelMapper = applicationModelMapper;
        }

        [HttpGet]
        public IActionResult SelectApplicationType()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetMatchedCourses(string term)
        {
            var courses = _courseService.GetAllMatchedCourses(term, 5);
            return Json(courses);
        }

        [HttpGet]
        public ActionResult GetMatchedTeachers(string term)
        {
            var teachers = _teacherService.GetAllMatchedTeachers(term, 5);
            return Json(teachers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var currentUser = _userService.GetUserById();
            var fullName = $"{currentUser.FirstName} {currentUser.LastName}";
            var appViewModel = CreatorApplicationViewModel.CreateEmpty(fullName);

            return View(appViewModel);
        }

        [HttpPost]
        public IActionResult Create(ApplicationViewModel appViewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ShowWarningPopup = true;
                return View(appViewModel);
            }

            var currentUser = _userService.GetUserById();
            var appModel = _applicationModelMapper.MapToModel(appViewModel, currentUser);
            var appId = _applicationService.SaveApplication(appModel);
            _teacherConfirmationService.CreateNewTeacherConfirmation(appModel, appId);

            return RedirectToAction("CreateSuccessResult");
        }

        public IActionResult CreateSuccessResult()
        {
            return View();
        }
    }
}