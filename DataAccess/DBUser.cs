using Microsoft.EntityFrameworkCore;
using Rddis.Models;

namespace Rddis.DataAccess
{
    public class DBUser : DbContext
    {
        public DBUser(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
