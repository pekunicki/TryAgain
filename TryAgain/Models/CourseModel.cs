using TryAgain.Models.Constants;

namespace TryAgain.Models
{
    public class CourseModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int Ects { get; set; }
        public CourseType Type { get; set; }
    }
}