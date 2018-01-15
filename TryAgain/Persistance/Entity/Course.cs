using TryAgain.Models.Constants;

namespace TryAgain.Persistance.Entity
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int Ects { get; set; }
        public CourseType Type { get; set; }
    }
}
