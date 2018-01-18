using TryAgain.Models;

namespace TryAgain.Services.Interfaces
{
    public interface IUserService
    {
        UserModel GetUserById(int id = 1);
    }
}