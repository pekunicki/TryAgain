using System.Linq;
using Microsoft.EntityFrameworkCore;
using TryAgain.Persistance.Entity;

namespace TryAgain.Persistance.Repository
{
    internal class ApplicationRepository
    {
        private readonly DatabaseContext _context;

        public ApplicationRepository(DatabaseContext context)
        {
            _context = context;
        }

        internal Application Create(Application application)
        {
            var createdApp = _context.Applications.Add(application);
            _context.SaveChanges();
            return createdApp.Entity;
        }

        internal Application GetApplicationById(int id, bool includeRelations)
        {
            return _context.Applications
                .Where(x => x.Id == id)
                .Include(x => x.Course)
                .Include(x => x.Organizer)
                .Include(x => x.TeacherConfirmations)
                .ThenInclude(x => x.Teacher)
                .FirstOrDefault();
        }
    }
}