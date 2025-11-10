using Entity.Context;
using Microsoft.EntityFrameworkCore;

namespace WebApi.MigrationServices
{
    public static class MigrationFactory
    {
        // Este método estático recorrerá los 3 contextos y aplicará cambios pendientes
        public static async Task ApplyAllMigrationsAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;

                // Logger para ver qué pasa en consola
                var logger = services.GetRequiredService<ILogger<Program>>();

                try
                {
                    // 1. Postgres
                    var pgContext = services.GetRequiredService<ApplicationDbContext>();
                    if ((await pgContext.Database.GetPendingMigrationsAsync()).Any())
                    {
                        logger.LogInformation("--> Aplicando migraciones PostgreSQL...");
                        await pgContext.Database.MigrateAsync();
                    }

                    // 2. MySQL
                    var mySqlContext = services.GetRequiredService<MySqlDbContext>();
                    if ((await mySqlContext.Database.GetPendingMigrationsAsync()).Any())
                    {
                        logger.LogInformation("--> Aplicando migraciones MySQL...");
                        await mySqlContext.Database.MigrateAsync();
                    }

                    // 3. SQL Server
                    var sqlContext = services.GetRequiredService<SqlServerDbContext>();
                    if ((await sqlContext.Database.GetPendingMigrationsAsync()).Any())
                    {
                        logger.LogInformation("--> Aplicando migraciones SQL Server...");
                        await sqlContext.Database.MigrateAsync();
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Ocurrió un error aplicando migraciones.");
                }
            }
        }
    }
}