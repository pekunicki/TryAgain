using System;
using TryAgain.Models.Constants;
using DayOfWeek = TryAgain.Models.Constants.DayOfWeek;

namespace TryAgain.Persistance.Entity
{
    public class Application
    {
        public int Id { get; set; }
        public int OrganizerId { get; set; }
        public int CourseId { get; set; }
        public int ProposedOtherCourseId { get; set; }
        public ApplicationState State { get; set; }
        public string Classroom { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public WeekType Week { get; set; }
        public DayOfWeek Day { get; set; }
        public string ApplicationType { get; set; }


    }
}