using TryAgain.Persistance.Entity;

namespace TryAgain.Persistance.Repository
{
    internal interface IApplicationRepository
    {
        Application Create(Application application);
        Application GetApplicationById(int id);
    }
}