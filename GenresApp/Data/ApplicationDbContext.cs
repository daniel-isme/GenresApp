using Microsoft.EntityFrameworkCore;

namespace GenresApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }

}
