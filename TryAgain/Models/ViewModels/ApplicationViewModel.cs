using TryAgain.Models.Constants;

namespace TryAgain.Models.ViewModels
{
    public class ApplicationViewModel
    {
        public string OrganizerFullName { get; set; }

        public CourseInApplicationViewModel Course { get; set; }

        public CourseType Type { get; set; }

        public string ProposedTeacherFullName { get; set; }

        public string Classroom { get; set; }

        public DateInApplicationViewModel Date { get; set; }

    }
}
