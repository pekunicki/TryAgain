using TryAgain.Models.Constants;

namespace TryAgain.Models.Forms
{
    public class ApplicationViewModel
    {
        public string Organizer { get; set; }

        public CourseInApplicationViewModel Course { get; set; }

        public CourseType Type { get; set; }

        public string ProposedTeacher { get; set; }

        public string Classroom { get; set; }

        public DateInApplicationViewModel Date { get; set; }
    }
}
