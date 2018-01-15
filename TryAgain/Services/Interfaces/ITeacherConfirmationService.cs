using TryAgain.Models;

namespace TryAgain.Services.Interfaces
{
    public interface ITeacherConfirmationService
    {
        TeacherConfirmationModel CreateNewTeacherConfirmation(int teacherId, ApplicationModel applicationId);
        void AcceptTeacherConfirmation(int teacherConfirmationId);
        void RejectTeacherConfirmation(int confirmationId);
        TeacherConfirmationModel TryGetTeacherConfirmationByLink(string link);
    }
}