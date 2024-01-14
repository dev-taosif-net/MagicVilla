using MagicVillaAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace MagicVillaAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Villa> Villas { get; set; }
    }
}
