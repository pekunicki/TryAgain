using System.Collections.Generic;
using TryAgain.Models;
using TryAgain.Services.Interfaces;

namespace TryAgain.Services
{
    internal class TeacherService : ITeacherService
    {
        public List<TeacherModel> GetAllTeachers()
        {
            //todo mapping
            return new List<TeacherModel>();
        }

        public bool CheckIfTeacherExists(string fullName)
        {
            //todo
            return true;
        }

        public TeacherModel GetTeacherByTeacherFullName(string fullName)
        {
            //todo
            return new TeacherModel
            {
                Email = "email",
                FirstName = "Elon",
                LastName = "Musk",
                HoursNumber = 300,
                Id = 300
            };
        }
    }
}