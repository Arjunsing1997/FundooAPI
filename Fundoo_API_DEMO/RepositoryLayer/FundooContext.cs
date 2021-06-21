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
            modelBuilder.Entity<Note>()
                .HasOne(n => n.User)
                .WithMany(m => m.Note)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }
    }


}