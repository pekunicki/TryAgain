using System;
using TryAgain.Models.Constants;
using DayOfWeek = TryAgain.Models.Constants.DayOfWeek;

namespace TryAgain.Models
{
    public class ApplicationModel
    {
        public ApplicationState State { get; set; }
        public string Classroom { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public WeekType Week { get; set; }
        public DayOfWeek Day { get; set; }

        public UserModel Organizer { get; set; }
        public CourseModel Course { get; set; }
        public TeacherModel Teacher { get; set; }
    }
}