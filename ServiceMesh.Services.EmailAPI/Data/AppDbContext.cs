using ServiceMesh.Services.EmailAPI.Models;
using Microsoft.EntityFrameworkCore;
using ServiceMesh.Services.EmailAPI.Model;

namespace ServiceMesh.Services.EmailAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<EmailLogger> EmailLoggers { get; set; }
    
    }
}
