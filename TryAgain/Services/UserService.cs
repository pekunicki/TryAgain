using AutoMapper;
using TryAgain.Models;
using TryAgain.Persistance.Repository;
using TryAgain.Services.Interfaces;

namespace TryAgain.Services
{
    internal class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModel GetUserById(int id = 1)
        {
            //todo consider if this '1' is ok :D
            var user = _userRepository.GetUserById(id);
            var userModel = Mapper.Map<UserModel>(user);
            return userModel;
        }
    }
}