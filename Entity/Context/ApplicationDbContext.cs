using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Reflection;

using Entity.Model;

namespace Entity.Context
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Productos> Productos { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Rol> Empleados { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Modificadores> Modificadores { get; set; }
        public DbSet<DetalleModificador> DetalleModificadores { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Aplicar configuraciones desde la asamblea actual

            //Coneccion Muchos a Muchos entre Usuario y Rol
            modelBuilder.Entity<RolUser>()
            .HasKey(ru => new { ru.idUsuario, ru.idRol });

            modelBuilder.Entity<RolUser>()
                .HasOne(ru => ru.Usuario)
                .WithMany(u => u.RolUsers)
                .HasForeignKey(ru => ru.idUsuario);

            modelBuilder.Entity<RolUser>()
                .HasOne(ru => ru.Rol)
                .WithMany(r => r.RolUsers)
                .HasForeignKey(ru => ru.idRol);

            // Coneccion Uno a Muchos entre Rol y Pedidos
            modelBuilder.Entity<Pedidos>()
                .HasOne(p => p.Rol)
                .WithMany(r => r.Pedidos)
                .HasForeignKey(p => p.Id);
            // Coneccion de uno a muchos entre Mesa y Pedidos
            modelBuilder.Entity<Pedidos>()
                .HasOne(p => p.Mesa)
                .WithMany(m => m.Pedidos)
                .HasForeignKey(p => p.Id);
            //coneccion uno a muchos entre Pedidos y Productos
            modelBuilder.Entity<Productos>()
                .HasOne(pr => pr.Pedido)
                .WithMany(pe => pe.Productos)
                .HasForeignKey(pr => pr.Id);
            //coneccion de muchos a muchos entre DetalleModificador y Productos y Modificadores
            modelBuilder.Entity<DetalleModificador>()
                .HasKey(dm => new { dm.ProductoId, dm.ModificadorId });
            modelBuilder.Entity<DetalleModificador>()
                .HasOne(dm => dm.Producto)
                .WithMany(p => p.DetalleModificadores)
                .HasForeignKey(dm => dm.Id);
            modelBuilder.Entity<DetalleModificador>()
                .HasOne(dm => dm.Modificador)
                .WithMany(m => m.DetalleModificadores)
                .HasForeignKey(dm => dm.Id);



        }

    }
}