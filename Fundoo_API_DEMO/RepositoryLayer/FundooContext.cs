using CommonLayer;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    public class FundooContext : DbContext
    {
        public FundooContext(DbContextOptions<FundooContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notes>()
                .HasOne(n => n.user)
                .WithMany(m => m.Notes)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Notes> Notes { get; set; }
    }


}