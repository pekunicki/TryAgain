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

        internal Teacher GetTeacherByFirstNameAndLastName(string firstName, string lastName)
        {
            return _context.Teachers.SingleOrDefault(x => x.FirstName.Equals(firstName) && x.LastName.Equals(lastName));
        }

        internal Teacher GetTeacherById(int id)
        {
            return _context.Teachers.SingleOrDefault(x => x.Id == id);
        }
    }
}