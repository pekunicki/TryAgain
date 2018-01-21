using System.Collections.Generic;
using TryAgain.Models;

namespace TryAgain.Services.Interfaces
{
    public interface ICourseService
    {
        List<CourseModel> GetAllCourses();
        List<CourseModel> GetAllMatchedCourses(string term, int numberResults);
        bool CheckIfCourseExists(string courseName);
        CourseModel GetCourseByCourseName(string coursename);
        CourseModel GetCourseById(int id);
    }
}