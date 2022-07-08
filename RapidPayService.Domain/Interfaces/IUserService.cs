using RapidPayService.Domain.Dtos;
using System.Threading.Tasks;

namespace RapidPayService.Domain.Interfaces
{
    public interface IUserService
    {
        Task<bool> Validate(string username, string password);

        Task<UserDto> GetById(int id);

        Task<string> GetRoleByUsername(string username);

    }
}
