using TryAgain.Models;
using TryAgain.Services.Interfaces;

namespace TryAgain.Services
{
    internal class UserService : IUserService
    {
        public UserModel GetCurrentUser()
        {
            //todo implement some fake 
            return new UserModel
            {
                FirstName = "Elon",
                LastName = "Musk",
                Id = 1
            };
        }
    }
}