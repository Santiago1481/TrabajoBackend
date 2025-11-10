using Microsoft.EntityFrameworkCore;

namespace Entity.Context
{
    // Hereda de BaseDbContext
    public class MySqlDbContext : BaseDbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        {
        }
    }
}