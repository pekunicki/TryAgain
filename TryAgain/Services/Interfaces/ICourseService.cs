using System.Collections.Generic;
using TryAgain.Models;

namespace TryAgain.Services.Interfaces
{
    public interface ICourseService
    {
        List<CourseModel> GetAllCourses();
        bool CheckIfCourseExists(string courseName);
        CourseModel GetCourseByCourseName(string coursename);
    }
}