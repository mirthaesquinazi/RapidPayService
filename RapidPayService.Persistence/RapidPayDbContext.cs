using Microsoft.EntityFrameworkCore;
using RapidPayService.Domain.Entities;

namespace RapidPayService.Persistence.Repositories
{
    public class RapidPayDbContext : DbContext
    {
        public RapidPayDbContext(DbContextOptions<RapidPayDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
