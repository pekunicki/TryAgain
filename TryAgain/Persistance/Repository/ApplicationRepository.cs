using System.Linq;
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

        internal Application GetApplicationById(int id)
        {
            return _context.Applications.FirstOrDefault(x => x.Id == id);

        }
    }
}