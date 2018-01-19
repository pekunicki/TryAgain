using System.Collections.Generic;
using AutoMapper;
using TryAgain.Models;
using TryAgain.Persistance.Entity;
using TryAgain.Persistance.Repository;
using TryAgain.Services.Interfaces;

namespace TryAgain.Services
{
    internal class TeacherService : ITeacherService
    {
        private readonly TeacherRepository _teacherRepository;

        public TeacherService(TeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public List<TeacherModel> GetAllTeachers()
        {
            //todo mapping
            return new List<TeacherModel>();
        }

        public bool CheckIfTeacherExists(string fullName)
        {
            var isValid = TryGetTeacherByTeacherFullName(fullName);
            return isValid != null;
        }

        public TeacherModel TryGetTeacherByTeacherFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                return null;
            }
            var names = CreateNamesFromFullName(fullName);
            if (names == null)
            {
                return null;
            }
            var teacher = _teacherRepository.GetTeacherByFirstNameAndLastName(names.FirstName, names.LastName);
            return teacher == null ? null : MapToTeacherModel(teacher);
        }

        public TeacherModel GetTeacherById(int id)
        {
            var teacher = _teacherRepository.GetTeacherById(id);
            return MapToTeacherModel(teacher);
        }

        private static TeacherModel MapToTeacherModel(Teacher teacher)
        {
            return Mapper.Map<TeacherModel>(teacher);
        }

        private Name CreateNamesFromFullName(string fullName)
        {
            var names = fullName.Split(' ', 2);
            if (names.Length <= 1)
            {
                return null;
            }

            var firstName = names[0];
            var lastName = names[1];

            return new Name
            {
                FirstName = firstName,
                LastName = lastName
            };
        }

        private class Name
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
}