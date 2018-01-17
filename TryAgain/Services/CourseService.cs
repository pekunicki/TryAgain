using System.Collections.Generic;
using TryAgain.Models;
using TryAgain.Persistance.Repository;

namespace TryAgain.Services.Interfaces
{
    internal class CourseService : ICourseService
    {
        private readonly CourseRepository _courseRepository;

        public CourseService(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public List<CourseModel> GetAllCourses()
        {
            throw new System.NotImplementedException();
        }

        public bool CheckIfCourseExists(string courseName)
        {
            var course = _courseRepository.GetCourseByName(courseName);
            return course != null;
        }

        public CourseModel GetCourseByCourseName(string coursename)
        {
            _courseRepository.GetCourseByName(coursename);
            //todo mapping;
            return new CourseModel();
        }
    }
}