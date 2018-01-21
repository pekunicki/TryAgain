using System;
using System.Collections.Generic;
using System.Linq;
using TryAgain.Persistance.Entity;

namespace TryAgain.Persistance.Repository
{
    internal class TeacherRepository
    {
        private readonly DatabaseContext _context;

        public TeacherRepository(DatabaseContext context)
        {
            _context = context;
        }

        internal List<Teacher> GetAllTeachers()
        {
            return _context.Teachers.ToList();
        }

        internal Teacher GetTeacherByFirstNameAndLastName(string firstName, string lastName)
        {
            return _context.Teachers.SingleOrDefault(x => x.FirstName.Equals(firstName) && x.LastName.Equals(lastName));
        }

        internal Teacher GetTeacherById(int id)
        {
            return _context.Teachers.SingleOrDefault(t => t.Id == id);
        }

        internal List<Teacher> GetAllMatchedTeachers(string term, int numberResults)
        {
            return _context.Teachers
                .Where(t => GetFullName(t).IndexOf(term, StringComparison.OrdinalIgnoreCase) >= 0)
                .Take(numberResults)
                .ToList();
        }

        private static string GetFullName(Teacher teacher)
        {
            return $"{teacher.FirstName} {teacher.LastName}";
        }
    }
}