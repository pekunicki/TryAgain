using TryAgain.Models.Constants;

namespace TryAgain.Services.Interfaces
{
    public interface INotificationService
    {
        void SendRequestToTeacher(string senderName, string teacherEmail, string link);
        void SendTeacherConfirmatonToStudent(string senderName, string receiverEmail, ConfirmationState state);
    }
}