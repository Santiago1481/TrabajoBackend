using Microsoft.EntityFrameworkCore;

namespace Entity.Context
{
    // Hereda de BaseDbContext
    public class SqlServerDbContext : BaseDbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
        {
        }
    }
}