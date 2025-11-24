using ServiceMesh.Services.RewardAPI.Models;
using Microsoft.EntityFrameworkCore;
using ServiceMesh.Services.RewardAPI.Models;

namespace ServiceMesh.Services.RewardAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Rewards> Rewards { get; set; }
    
    }
}
