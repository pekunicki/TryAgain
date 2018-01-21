using AutoMapper;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using NUnit.Framework;
using TryAgain.Models.Constants;
using TryAgain.Models.ViewModels;
using TryAgain.Services.Interfaces;
using TryAgain.Utils;

namespace TryAgain.Test
{
    [TestFixture]
    public class ApplicationViewModelValidatorTests
    {
        private Mock<ICourseService> _courseServiceMock;
        private Mock<ITeacherService> _teacherServiceMock;
        private ApplicationViewModelValidator _applicationViewModelValidator;

        [SetUp]
        public void Setup()
        {
            _courseServiceMock = new Mock<ICourseService>();
            _teacherServiceMock = new Mock<ITeacherService>();
            _applicationViewModelValidator =
                new ApplicationViewModelValidator(_courseServiceMock.Object, _teacherServiceMock.Object);
        }

        [Test]
        [Category("UnitTest")]
        public void ApplicationViewModelValidator_ValidApplicationViewModel_ModelIsValid()
        {
            var appViewModel = CreateApplicationViewModel("Analytics");
            SetupCheckIfCourseExists("Analytics");
            SetupCheckIfTeacherExists();

            var result = _applicationViewModelValidator.Validate(appViewModel);

            Assert.AreEqual(true, result.IsValid, result.Errors.Join(","));
        }

        [Test]
        [Category("UnitTest")]
        public void ApplicationViewModelValidator_CourseNotExists_ModelIsInvalid()
        {
            var appViewModel = CreateApplicationViewModel("Swimming");
            SetupCheckIfCourseExists("Dancing");
            SetupCheckIfTeacherExists();

            var result = _applicationViewModelValidator.Validate(appViewModel);

            Assert.AreEqual(1, result.Errors.Count);
            Assert.AreEqual("Podana wartość w polu Kurs nie istnieje w bazie danych.", result.Errors[0].ToString());
        }

        private void SetupCheckIfTeacherExists()
        {
            _teacherServiceMock.Setup(x => x.CheckIfTeacherExists(It.IsAny<string>())).Returns(true);
        }

        private void SetupCheckIfCourseExists(string courseName)
        {
            _courseServiceMock.Setup(x => x.CheckIfCourseExists(courseName)).Returns(true);
        }

        private static ApplicationViewModel CreateApplicationViewModel(string courseName)
        {
            return new ApplicationViewModel()
            {
                Classroom = "classRoom",
                Course = new CourseInApplicationViewModel()
                {
                    CourseName = courseName,
                    Ects = 5
                },
                Date = new DateInApplicationViewModel()
                {
                    StartTime = "11:15",
                    EndTime = "12:30",
                    Day = DayOfWeek.Czwartek,
                    Week = WeekType.ParzystyNieparzysty
                },
                OrganizerFullName = "Elon Musk",
                ProposedTeacherFullName = "ProposedTeacher",
                Type = CourseType.Wyklad
            };
        }
    }
}