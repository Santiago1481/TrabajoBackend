using Business.Implements.LogicaGenerica;
using Business.Intefaces.SGeneric;      
using Data.Implement.LogicaGenerica;    
using Data.Intefaces.IGeneric;          
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.OpenApi.Models;
using Utilities.Mappers;                  

var builder = WebApplication.CreateBuilder(args);
    

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