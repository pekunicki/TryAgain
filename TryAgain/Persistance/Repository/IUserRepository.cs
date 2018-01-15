using TryAgain.Persistance.Entity;

namespace TryAgain.Persistance.Repository
{
    internal interface IUserRepository
    {
        User GetUserById(int id);
    }
}