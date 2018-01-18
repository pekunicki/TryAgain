using System;
using TryAgain.Models.Constants;

namespace TryAgain.Models
{
    public class TeacherConfirmationModel
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public int TeacherId { get; set; }
        public string Link { get; set; }
        public ConfirmationState State { get; set; }
        public int ExpiryDaysNumber { get; set; }
        public DateTime CreationDate { get; set; }
    }
}