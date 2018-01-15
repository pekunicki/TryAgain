using System.Collections.Generic;
using TryAgain.Models;

namespace TryAgain.Services.Interfaces
{
    public interface ITeacherService
    {
        List<TeacherModel> GetAllTeachers();
        bool CheckIfTeacherExists(string fullName);
        TeacherModel GetTeacherByTeacherFullName(string fullName);
    }
}