using AspNetCore.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore.Services.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Client> Clients => Set<Client>();
    }
}
