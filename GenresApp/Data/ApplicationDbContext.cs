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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SubGenre>().HasOne(x => x.Parent).WithMany().OnDelete(DeleteBehavior.Restrict);
        }



        public DbSet<SubGenre> SubGenre { get; set; }

        public DbSet<Genre> Genre { get; set; }

    }

}
