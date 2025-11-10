using Microsoft.EntityFrameworkCore;

namespace Entity.Context
{
    // Hereda de BaseDbContext
    public class ApplicationDbContext : BaseDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}