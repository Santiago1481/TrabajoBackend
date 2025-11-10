using AutoMapper;
using Business.Implements;
using Business.Implements.LogicaGenerica;
using Business.Intefaces;
using Business.Intefaces.SGeneric;
using Data.Implement;
using Data.Implement.LogicaGenerica;
using Data.Intefaces;
using Data.Intefaces.IGeneric;
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Utilities.Mappers;
using WebApi.Jwt;
using WebApi.MigrationServices;

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURACIÓN GENERAL ---
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MappingProfile>());

// --- 2. CONFIGURACIÓN BASES DE DATOS ---
// Esta línea registra Postgres, MySQL y SQL Server automáticamente
builder.Services.AddConfiguredDatabases(builder.Configuration);

// --- 3. SERVICIOS DE JWT ---
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddScoped<ITokenService, TokenService>();

// --- 4. INYECCIÓN DE DEPENDENCIAS (CAPAS) ---
// Repositorios y Lógica Genérica
builder.Services.AddScoped(typeof(IGeneric<>), typeof(ModelGenerico<>));
builder.Services.AddScoped(typeof(ISGeneric<,>), typeof(SModeloGenerico<,>));

// Repositorios y Lógica Específica (Login, Usuarios)
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUsuarioBusiness, UsuarioBusiness>();

// --- 5. CONTROLLERS Y SWAGGER ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi v1", Version = "v1" });

    // Configuración del botón "Authorize" para JWT
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Introduce tu token JWT aquí (solo el token, sin 'Bearer ' delante)"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// --- 6. MIGRACIONES AUTOMÁTICAS ---
// Aplica cambios pendientes a las 3 bases de datos al iniciar
await MigrationFactory.ApplyAllMigrationsAsync(app.Services);

// --- 7. PIPELINE DE MIDDLEWARE ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1");
        options.RoutePrefix = string.Empty; // Swagger en la raíz (http://localhost:xxxx/)
    });
}

app.UseHttpsRedirection();

// ¡Orden crítico para la seguridad!
app.UseAuthentication(); // Identifica quién eres
app.UseAuthorization();  // Verifica qué puedes hacer

app.MapControllers();

app.Run();