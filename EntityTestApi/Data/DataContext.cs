using EntityTestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityTestApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Entity> Entities { get; set; }
    }
}
