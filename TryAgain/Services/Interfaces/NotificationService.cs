using PostmarkDotNet;
using PostmarkDotNet.Legacy;
using TryAgain.Models.Constants;
using TryAgain.Utils;

namespace TryAgain.Services.Interfaces
{
    internal class NotificationService : INotificationService
    {
        private readonly string _senderEmail;
        private readonly PostmarkClient _postmarkClient;

        public NotificationService()
        {
            _senderEmail = Settings.SenderEmail;
            var serverToken = Settings.PostMarkToken;
            _postmarkClient = new PostmarkClient(serverToken);
        }

        public void SendRequestToTeacher(string senderName, string receiverEmail, string link)
        {
            var htmlMessage = CreateMessageForTeacher(senderName, link);
            var message = CreatePostMarkMessage(receiverEmail, htmlMessage);

            _postmarkClient.SendMessage(message);
        }

        public void SendTeacherConfirmatonToStudent(string senderName, string receiverEmail, ConfirmationState state)
        {
            var htmlMessage = CreateMessageForStudent(senderName, state);
            var message = CreatePostMarkMessage(receiverEmail, htmlMessage);

            _postmarkClient.SendMessage(message);
        }

        private PostmarkMessage CreatePostMarkMessage(string receiverEmail, string htmlBody)
        {
            return new PostmarkMessage()
            {
                To = receiverEmail,
                From = _senderEmail,
                TrackOpens = true,
                Subject = "Potwierdzenie prowadzenia kursu poprawkowego",
                HtmlBody = htmlBody
            };
        }

        private static string CreateMessageForTeacher(string studentName, string link)
        {
            return $"<center>Student <b>{studentName}</b> wystąpił z prośbą do Ciebie o prowadzenie kursu poprawkowego.<br/>" +
                   $"Kliknij w link, aby potwierdzić albo odrzucić prośbę.<br/>" +
                   $"<a href=\"{link}\">ZOBACZ PODANIE</a></center>";
        }

        private string CreateMessageForStudent(string teacherName, ConfirmationState state)
        {
            return
                $"<center>Prowadzacy <b>{teacherName}</b> podjął decyzję odnośnie prowadzenia kursu poprawkowego.<br/>" +
                $"Twoje podanie zostało <b>{state.ToString()}</b>.";
        }
    }
}