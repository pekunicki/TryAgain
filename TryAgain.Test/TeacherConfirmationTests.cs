using System;
using AutoMapper;
using Moq;
using NUnit.Framework;
using TryAgain.Controllers.Application;
using TryAgain.Models.Constants;
using TryAgain.Models.Mappers;
using TryAgain.Persistance.Entity;
using TryAgain.Persistance.Repository;
using TryAgain.Services;
using TryAgain.Services.Interfaces;
using TryAgain.Utils;

namespace TryAgain.Test
{
    [TestFixture]
    public class TeacherConfirmationTests
    {
        private ITeacherConfirmationService _teacherConfirmationService;
        private Mock<INotificationService> _notificationService;
        private Mock<IApplicationService> _applicationService;
        private Mock<ITeacherConfirmationRepository> _teacherConfirmationRepositoryMock;
        private TeacherConfirmationController _teacherConfirmationController;

        [SetUp]
        public void Setup()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());

            _notificationService = new Mock<INotificationService>();
            _applicationService = new Mock<IApplicationService>();
            var fakeApplicationModelMapper = new ApplicationModelMapper(null, null);
            _teacherConfirmationRepositoryMock = new Mock<ITeacherConfirmationRepository>();
            _teacherConfirmationService = new TeacherConfirmationService(_notificationService.Object, _teacherConfirmationRepositoryMock.Object);
            _teacherConfirmationController = new TeacherConfirmationController(_applicationService.Object, _teacherConfirmationService, fakeApplicationModelMapper);
        }

        [Test]
        [Category("IntegrationTest")]
        public void Accept_PassValidTeacherConfirmationLink_TeacherConfirmationAccepted()
        {
            var link = Guid.NewGuid().ToString();
            var confirmation = CreateTeacherConfirmation(link);
            SetupGetTeacherConfirmationByLink(link, confirmation);

            _teacherConfirmationController.Accept(link);

            _teacherConfirmationRepositoryMock.Verify(x=>x.UpdateTeacherConfirmation(1, ConfirmationState.Zaakceptowane), Times.Once);   
        }

        private void SetupGetTeacherConfirmationByLink(string link, TeacherConfirmation confirmation)
        {
            _teacherConfirmationRepositoryMock.Setup(x => x.GetTeacherConfirmationByLink(link)).Returns(confirmation);
        }

        private static TeacherConfirmation CreateTeacherConfirmation(string link)
        {
            var confirmation = new TeacherConfirmation
            {
                ExpiryDaysNumber = 5,
                CreationDate = DateTime.UtcNow,
                State = ConfirmationState.Oczekiwanie,
                Link = link,
                Id = 1
            };
            return confirmation;
        }
    }
}
