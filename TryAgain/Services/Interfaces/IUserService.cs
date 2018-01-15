using TryAgain.Models;

namespace TryAgain.Services.Interfaces
{
    public interface IUserService
    {
        UserModel GetCurrentUser();
    }
}