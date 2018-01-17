using System.Linq;
using TryAgain.Persistance.Entity;

namespace TryAgain.Persistance.Repository
{
    internal class UserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        internal User GetUserById(int id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id);
        }
    }
}