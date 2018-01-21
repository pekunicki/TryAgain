using System.Collections.Generic;
using TryAgain.Models;

namespace TryAgain.Services.Interfaces
{
    public interface ITeacherService
    {
        List<TeacherModel> GetAllTeachers();
        List<TeacherModel> GetAllMatchedTeachers(string term, int numberResults);
        bool CheckIfTeacherExists(string fullName);
        TeacherModel TryGetTeacherByTeacherFullName(string fullName);
        TeacherModel GetTeacherById(int id);
    }
}