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

        /// <summary>
        /// Note that parameter is mocked due to not implemented authorization service.
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns></returns>
        public UserModel GetUserById(int id = 1)
        {
            var user = _userRepository.GetUserById(id);
            var userModel = Mapper.Map<UserModel>(user);
            return userModel;
        }
    }
}