using Mapster;
using RapidPayService.Domain.Dtos;
using RapidPayService.Domain.Interfaces;
using RapidPayService.Domain.Repositories;
using System.Threading.Tasks;

namespace RapidPayService.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await _userRepository.GetById(id);

            return user.Adapt<UserDto>();
        }

        public async Task<bool> Validate(string username, string password)
        {
            var isUserValid = await _userRepository.ValidateCredentials(username, password);

            return isUserValid;
        }

        public async Task<string> GetRoleByUsername(string username)
        {
            var role = await _userRepository.GetRoleByUserName(username);

            return role;
        }
    }
}
