using System;
using System.Collections.Generic;
using System.Linq;
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

        internal List<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }

        internal Course GetCourseByName(string name)
        {
            var course = _context.Courses.FirstOrDefault(x => x.CourseName == name);
            return course;
        }

        internal Course GetCourseById(int id)
        {
            return _context.Courses.FirstOrDefault(x => x.Id == id);
        }

        internal List<Course> GetAllMatchedCourses(string term, int numberResults)
        {
            return _context.Courses
                .Where(c => c.CourseName.IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0)
                .Take(numberResults)
                .ToList();
        }
    }
}
