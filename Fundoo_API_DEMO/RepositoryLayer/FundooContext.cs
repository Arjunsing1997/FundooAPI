using CommonLayer;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    public class FundooContext : DbContext
    {
        public FundooContext (DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                FirstName = "Arjun",
                LastName = "Raj",
                Email = "Arjun@gmail.com",
                Password =  "Arjun@123",
               

            }, new User
            {
                UserId = 2,
                FirstName = "John",
                LastName = "Mark",
                Email = "John@gmail.com",
                Password = "john@123"
            }) ;
        }

    }

    
}