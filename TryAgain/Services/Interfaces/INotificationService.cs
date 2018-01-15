namespace TryAgain.Services.Interfaces
{
    public interface INotificationService
    {
        void SendRequestToTeacher(int applicationId, int teacherId);
        void SendTeacherConfirmatonToStudent(int applicationId, int studentId);
    }

    internal class NotificationService : INotificationService {

        public void SendRequestToTeacher(int applicationId, int teacherId)
        {
            //todo implement
        }

        public void SendTeacherConfirmatonToStudent(int applicationId, int studentId)
        {
            //todo implement
        }
    }
}