using System.Linq;
using Microsoft.EntityFrameworkCore;
using TryAgain.Persistance.Entity;

namespace TryAgain.Persistance.Repository
{
    internal class CourseRepository
    {
        private readonly DatabaseContext _context;

        public CourseRepository(DatabaseContext context)
        {
            _context = context;
        }

        internal Course GetCourseByName(string name)
        {
            //todo consider return lists
            var course = _context.Courses.FirstOrDefault(x => x.CourseName == name);
            return course;
        }

        internal Course GetCourseById(int id)
        {
            return _context.Courses.FirstOrDefault(x => x.Id == id);
        }
    }
}
