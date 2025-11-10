using Entity.Context;
using Microsoft.EntityFrameworkCore;

namespace WebApi.MigrationServices
{
    public static class Migrations
    {
        public static IServiceCollection AddConfiguredDatabases(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. PostgreSQL
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Entity")));

            // 2. MySQL (¡ESTO ES LO QUE FALTA!)
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 0)); // Ajusta la versión si sabes cuál es
            services.AddDbContext<MySqlDbContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("MySqlConnection"),
                    serverVersion,
                    b => b.MigrationsAssembly("Entity")));

            // 3. SQL Server (¡ESTO TAMBIÉN FALTA!)
            services.AddDbContext<SqlServerDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("SqlServerConnection"),
                    b => b.MigrationsAssembly("Entity")));

            return services;
        }
    }
}