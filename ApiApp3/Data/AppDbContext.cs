using ApiApp3.Models;
using Microsoft.EntityFrameworkCore;
namespace ApiApp3.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }

        public DbSet<Study> Study { get; set; }


    }
}
