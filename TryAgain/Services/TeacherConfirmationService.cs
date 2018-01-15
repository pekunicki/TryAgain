using System;
using TryAgain.Models;
using TryAgain.Models.Constants;
using TryAgain.Persistance.Entity;
using TryAgain.Persistance.Repository.Interfaces;
using TryAgain.Services.Interfaces;

namespace TryAgain.Services
{
    internal class TeacherConfirmationService : ITeacherConfirmationService
    {
        private readonly INotificationService _notificationService;
        private readonly TeacherConfirmationRepository _teacherConfirmationRepository;

        public TeacherConfirmationService(
            INotificationService notificationService, 
            TeacherConfirmationRepository teacherConfirmationRepository)
        {
            _notificationService = notificationService;
            _teacherConfirmationRepository = teacherConfirmationRepository;
        }

        public TeacherConfirmationModel CreateNewTeacherConfirmation(int appId, ApplicationModel appModel)
        {
            var confirmation = new TeacherConfirmationModel
            {
                CreationDate = DateTime.UtcNow,
                ExpiryDaysNumber = 10, //todo some settings
                Link = "123", //todo add generating unique id and expose some endpoint
                State = ConfirmationState.Oczekiwanie
            };

            //todo mapping
            var teacherConfirmation = _teacherConfirmationRepository.Create(new TeacherConfirmation());
            _notificationService.SendRequestToTeacher(appId, teacherConfirmation.TeacherId);

            //todo here
            return new TeacherConfirmationModel();
        }

        public void AcceptTeacherConfirmation(int confirmationId)
        {
            _teacherConfirmationRepository.UpdateTeacherConfirmation(
                confirmationId,
                ConfirmationState.Zaakceptowane);
        }

        public void RejectTeacherConfirmation(int confirmationId)
        {
            _teacherConfirmationRepository.UpdateTeacherConfirmation(
                confirmationId,
                ConfirmationState.Odrzucone);
        }

        public bool ValidateTeacherConfirmationLink(string link)
        {
            var confirmation = _teacherConfirmationRepository.GetTeacherConfirmationByLink(link);
            return confirmation.CreationDate.AddDays(confirmation.ExpiryDaysNumber) >= DateTime.UtcNow;
        }
    }
}