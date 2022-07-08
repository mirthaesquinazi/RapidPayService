using RapidPayService.Domain.Entities;
using System.Threading.Tasks;

namespace RapidPayService.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);

        Task<bool> ValidateCredentials(string username, string password);

        Task<string> GetRoleByUserName(string username);
    }
}
