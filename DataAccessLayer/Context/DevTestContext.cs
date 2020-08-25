using DataAccessLayer.Infrastructure;
using Microsoft.EntityFrameworkCore;



namespace DataAccessLayer
{
    public class DevTestContext : DbContext
    {
        public DevTestContext()
        {

        }
        public DevTestContext(DbContextOptions<DevTestContext> options) : base(options)
        {

        }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<UserDetails> UserDetails { get; set; }
    }
  

}
