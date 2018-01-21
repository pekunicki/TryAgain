using System;
using System.Linq;
using AutoMapper;
using TryAgain.Models;
using TryAgain.Models.Constants;
using TryAgain.Persistance.Entity;
using TryAgain.Persistance.Repository;
using TryAgain.Services.Interfaces;
using TryAgain.Utils;

namespace TryAgain.Services
{
    internal class TeacherConfirmationService : ITeacherConfirmationService
    {
        private readonly INotificationService _notificationService;
        private readonly ITeacherConfirmationRepository _teacherConfirmationRepository;
        private int _expiryDaysNumber = 10;

        public TeacherConfirmationService(
            INotificationService notificationService, 
            ITeacherConfirmationRepository teacherConfirmationRepository)
        {
            _notificationService = notificationService;
            _teacherConfirmationRepository = teacherConfirmationRepository;
        }

        public TeacherConfirmationModel CreateNewTeacherConfirmation(ApplicationModel appModel, int appId)
        {
            var confirmation = new TeacherConfirmation()
            {
                CreationDate = DateTime.UtcNow,
                ExpiryDaysNumber = _expiryDaysNumber,
                Link = GenerateUniqueId(),
                State = ConfirmationState.Oczekiwanie,
                ApplicationId =  appId,
                TeacherId = appModel.Teacher.Id
            };
            var teacherConfirmation = _teacherConfirmationRepository.Create(confirmation);
            var fullLink = CreateLink(teacherConfirmation.Link);
            _notificationService.SendRequestToTeacher(appModel.Organizer.FullName, appModel.Teacher.Email, fullLink);

            return MapToConfirmationModel(teacherConfirmation);
        }

        public void AcceptTeacherConfirmation(int confirmationId)
        {
            var confirmation = _teacherConfirmationRepository.UpdateTeacherConfirmation(
                confirmationId,
                ConfirmationState.Zaakceptowane);

            if (confirmation != null)
            {
                SendNotificationToStudent(confirmationId, ConfirmationState.Zaakceptowane);
            }

        }

        public void RejectTeacherConfirmation(int confirmationId)
        {
            var confirmation = _teacherConfirmationRepository.UpdateTeacherConfirmation(
                confirmationId,
                ConfirmationState.Odrzucone);

            if (confirmation != null)
            {
                SendNotificationToStudent(confirmationId, ConfirmationState.Odrzucone);
            }
        }

        public TeacherConfirmationModel TryGetTeacherConfirmationByLink(string link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return null;
            }
            var confirmation = _teacherConfirmationRepository.GetTeacherConfirmationByLink(link);
            if (confirmation == null)
            {
                return null;
            }
            var isValid = confirmation.CreationDate.AddDays(confirmation.ExpiryDaysNumber) >= DateTime.UtcNow
                          && confirmation.State == ConfirmationState.Oczekiwanie;

            if (isValid)
            {
                return MapToConfirmationModel(confirmation);
            }
            return null;
        }

        private void SendNotificationToStudent(int confirmationId, ConfirmationState state)
        {
            var confirmation = _teacherConfirmationRepository.GetTeacherAndOrganizerByConfirmationId(confirmationId);
            var teacherName = $"{confirmation.Teacher.FirstName} {confirmation.Teacher.LastName}";
            var studentEmail = confirmation.Application.Organizer.Email;
            _notificationService.SendTeacherConfirmationToStudent(teacherName, studentEmail, state);
        }

        private static TeacherConfirmationModel MapToConfirmationModel(TeacherConfirmation confirmation)
        {
            return Mapper.Map<TeacherConfirmationModel>(confirmation);
        }

        private string CreateLink(string teacherConfirmationLink)
        {
            return Settings.BaseUrl + Settings.TeacherConfirmationEndpoint + teacherConfirmationLink;
        }

        private static string GenerateUniqueId()
        {
            return Guid.NewGuid().ToString();
        }
    }
}