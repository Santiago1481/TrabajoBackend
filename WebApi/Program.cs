using Business.Implements.LogicaGenerica;
using Business.Intefaces.SGeneric;      // Para tu capa Business
using Data.Implement.LogicaGenerica;    // Para tu capa Data
using Data.Intefaces.IGeneric;          // Para tu capa Data
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.OpenApi.Models;
using Utilities.Mappers;                  // Para tu MappingProfile

var builder = WebApplication.CreateBuilder(args);

// --- 2. REGISTRO DE SERVICIOS (El "Cableado") ---

// A. Conexión a Base de Datos (¡LÓGICA AUTOMÁTICA AGREGADA!)
//
// Lee una variable de entorno 'DB_PROVIDER' para decidir qué BD usar.
// El script de PowerShell (generate-migrations.ps1) la establecerá.
// Si no existe, usará "PostgreSql" por defecto.
//
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    // Lee la variable de entorno. Si no existe, usa "PostgreSql" como valor predeterminado.
    var provider = Environment.GetEnvironmentVariable("DB_PROVIDER") ?? "PostgreSql";

    switch (provider)
    {
        case "SqlServer":
            // OPCIÓN 2: SQL Server (Microsoft)
            // (Asegúrate de tener "SqlServer" en tu appsettings.json)
            var sqlServerConnectionString = builder.Configuration.GetConnectionString("SqlServer");
            Console.WriteLine("--- USANDO SQL SERVER ---");
            options.UseSqlServer(sqlServerConnectionString);
            break;

        case "MySql":
            // OPCIÓN 3: MySQL (Pomelo)
            // (Asegúrate de tener "MySql" en tu appsettings.json)
            var mySqlConnectionString = builder.Configuration.GetConnectionString("MySql");
            Console.WriteLine("--- USANDO MYSQL ---");
            options.UseMySql(mySqlConnectionString, ServerVersion.AutoDetect(mySqlConnectionString));
            break;

        case "PostgreSql":
        default:
            // OPCIÓN 1: PostgreSQL (Por defecto)
            // (Usa "DefaultConnection" porque así lo tenías en tu archivo original)
            var postgreSqlConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine("--- USANDO POSTGRESQL ---");
            options.UseNpgsql(postgreSqlConnectionString);
            break;
    }
});


// B. AutoMapper (De Utilities) - (Tu línea, ¡perfecta!)
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

// C. Capa Data (IGeneric -> ModelGenerico)
builder.Services.AddScoped(typeof(IGeneric<>), typeof(ModelGenerico<>));

// D. Capa Business (ISGeneric -> SModeloGenerico)
builder.Services.AddScoped(typeof(ISGeneric<,>), typeof(SModeloGenerico<,>));



// --- 3. OTROS SERVICIOS (Tu configuración, ¡perfecta!) ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "WebApi",
        Description = "API RESTful para el backend",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Soporte",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Licencia MIT",
            Url = new Uri("https://example.com/license")
        }
    });
});

var app = builder.Build();

// --- 4. CONFIGURACIÓN (Tu configuración, ¡perfecta!) ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1");
        options.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();