using Microsoft.EntityFrameworkCore;
using GenresApp.Models;

namespace GenresApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<GenresApp.Models.Genre> Genre { get; set; }
    }

}
