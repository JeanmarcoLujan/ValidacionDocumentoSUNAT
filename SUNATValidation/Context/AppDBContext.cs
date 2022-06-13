using Microsoft.EntityFrameworkCore;
using SUNATValidation.Models;

namespace SUNATValidation.Context
{
    public class AppDBContext: DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        public DbSet<Purcharse> Purcharses { get; set; }
        public DbSet<Rate> Rates { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Rate>()
                .HasIndex(u => u.DateRate)
                .IsUnique();
        }
    }
}
