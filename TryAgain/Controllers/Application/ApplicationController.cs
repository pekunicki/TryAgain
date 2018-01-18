﻿using Microsoft.AspNetCore.Mvc;
using TryAgain.Models.Creators;
using TryAgain.Models.ViewModels;
using TryAgain.Services.Interfaces;

namespace TryAgain.Controllers.Application
{
    public class ApplicationController : Controller
    {
        private readonly IApplicationService _applicationService;
        private readonly IUserService _userService;

        public ApplicationController(
            IApplicationService applicationService, 
            IUserService userService)
        {
            _applicationService = applicationService;
            _userService = userService;
        }

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
            var currentUser = _userService.GetUserById();
            var fullName = $"{currentUser.FirstName} {currentUser.LastName}";

            //todo if we want have combobox and autofilling of ECTS field we need to pass here all courses or add ajax call
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
            var appModel = _applicationService.CreateApplicationModel(appViewModel, currentUser);
            _applicationService.SaveApplication(appModel);

            return RedirectToAction("CreateSucccessResult");
        }

        public IActionResult CreateSucccessResult()
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