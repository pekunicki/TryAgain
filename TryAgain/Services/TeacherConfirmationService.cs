using System;
using System.Linq;
using AutoMapper;
using TryAgain.Models;
using TryAgain.Models.Constants;
using TryAgain.Persistance.Entity;
using TryAgain.Persistance.Repository;
using TryAgain.Services.Interfaces;

namespace TryAgain.Services
{
    internal class TeacherConfirmationService : ITeacherConfirmationService
    {
        private readonly INotificationService _notificationService;
        private readonly TeacherConfirmationRepository _teacherConfirmationRepository;
        private int _expiryDaysNumber = 10;

        public TeacherConfirmationService(
            INotificationService notificationService, 
            TeacherConfirmationRepository teacherConfirmationRepository)
        {
            _notificationService = notificationService;
            _teacherConfirmationRepository = teacherConfirmationRepository;
        }

        public TeacherConfirmationModel CreateNewTeacherConfirmation(int teacherId, int appId)
        {
            var confirmation = new TeacherConfirmation()
            {
                CreationDate = DateTime.UtcNow,
                ExpiryDaysNumber = _expiryDaysNumber,
                Link = GenerateUniqueId(),
                State = ConfirmationState.Oczekiwanie,
                ApplicationId =  appId,
                TeacherId = teacherId
            };

            var teacherConfirmation = _teacherConfirmationRepository.Create(confirmation);
            _notificationService.SendRequestToTeacher(appId, teacherId);
            return MapToConfirmationModel(teacherConfirmation);
        }

        private static string GenerateUniqueId()
        {
            return Guid.NewGuid().ToString();
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

        public TeacherConfirmationModel TryGetTeacherConfirmationByLink(string link)
        {
            var confirmation = _teacherConfirmationRepository.GetTeacherConfirmationByLink(link);
            var isValid = confirmation.CreationDate.AddDays(confirmation.ExpiryDaysNumber) >= DateTime.UtcNow
                          && confirmation.State == ConfirmationState.Oczekiwanie;

            if (isValid)
            {
                return MapToConfirmationModel(confirmation);
            }
            return null;
        }

        private static TeacherConfirmationModel MapToConfirmationModel(TeacherConfirmation confirmation)
        {
            return Mapper.Map<TeacherConfirmationModel>(confirmation);
        }

        public TeacherConfirmationModel TryGetTeacherConfirmationByAppId(int id)
        {
            var confirmations = _teacherConfirmationRepository.GetTeacherCOnfirmationsByAppId(id);
            var firstConfirmation = confirmations.First();
            return MapToConfirmationModel(firstConfirmation);
        }
    }
}