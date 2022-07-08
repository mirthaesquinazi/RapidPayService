using Microsoft.EntityFrameworkCore;
using RapidPayService.Domain.Entities;
using RapidPayService.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace RapidPayService.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RapidPayDbContext _context;

        public UserRepository(RapidPayDbContext context)
        {
            _context = context;

            InsertUser();
        }
        public async Task<User> GetById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<bool> ValidateCredentials(string username, string password)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);
            if (result != null)
            {
                return true;
            }
            return false;
        }

        public async Task<string> GetRoleByUserName(string username)
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => x.Username == username);

            return result.Role;
        }

        private void InsertUser()
        {
            var existingUser = _context.Users.FirstOrDefault(x => x.UserId == 1);

            if (existingUser == null)
            {
                _context.Users.Add(new User
                {
                    Username = "sa",
                    Password = "sa",
                    UserId = 1,
                    Role = "Owner"
                });

                _context.Users.Add(new User
                {
                    Username = "se",
                    Password = "se",
                    UserId = 2,
                    Role = "Viewer"

                });
                _context.SaveChanges();
            }
        }
    }
}
