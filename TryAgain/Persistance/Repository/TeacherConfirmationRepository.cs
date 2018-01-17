using System.Linq;
using TryAgain.Models.Constants;
using TryAgain.Persistance.Entity;

namespace TryAgain.Persistance.Repository
{
    internal class TeacherConfirmationRepository
    {
        private readonly DatabaseContext _context;

        public TeacherConfirmationRepository(DatabaseContext context)
        {
            _context = context;
        }

        public TeacherConfirmation Create(TeacherConfirmation confirmation)
        {
            var savedConfirmation = _context.TeacherConfirmations.Add(confirmation);
            _context.SaveChanges();
            return savedConfirmation.Entity;
        }

        public TeacherConfirmation GetTeacherConfirmationByLink(string link)
        {
            return _context.TeacherConfirmations.SingleOrDefault(x => x.Link == link);
        }

        public TeacherConfirmation UpdateTeacherConfirmation(int id, ConfirmationState newState)
        {
            var confirmation = _context.TeacherConfirmations.FirstOrDefault(x => x.Id == id);
            if (confirmation == null)
            {
                return null;
            }
            confirmation.State = newState;
            _context.SaveChanges();
            return confirmation;
        }
    }
}