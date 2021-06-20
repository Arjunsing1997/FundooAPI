using CommonLayer;
using Microsoft.EntityFrameworkCore;

namespace RepositoryLayer
{
    public class FundooContext : DbContext
    {
        public FundooContext(DbContextOptions<FundooContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }


}