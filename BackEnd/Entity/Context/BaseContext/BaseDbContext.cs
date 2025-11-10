using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Entity.Context
{
   
    public abstract class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        // --- Aquí definimos las tablas UNA SOLA VEZ ---
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

            // --- Aquí tu configuración UNA SOLA VEZ ---

            // Relacion muchos a muchos Usuario <-> Rol
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

            // OJO: Revisa tus Foreign Keys. Usar 'p.Id' como Foreign Key es inusual
            // si no es una relación 1 a 1. Normalmente sería 'p.RolId' o 'p.MesaId'.
            // Lo dejo como lo tienes, pero revísalo si te da errores al migrar.

            modelBuilder.Entity<Pedidos>()
                .HasOne(p => p.Rol)
                .WithMany(r => r.Pedidos)
                .HasForeignKey(p => p.Id); // ¿Seguro que es p.Id y no p.RolId?

            modelBuilder.Entity<Pedidos>()
                .HasOne(p => p.Mesa)
                .WithMany(m => m.Pedidos)
                .HasForeignKey(p => p.Id); // ¿Seguro que es p.Id y no p.MesaId?

            modelBuilder.Entity<Productos>()
                .HasOne(pr => pr.Pedido)
                .WithMany(pe => pe.Productos)
                .HasForeignKey(pr => pr.Id); // ¿Seguro que es pr.Id y no pr.PedidoId?

            // Relacion muchos a muchos DetalleModificador
            modelBuilder.Entity<DetalleModificador>()
                .HasKey(dm => new { dm.ProductoId, dm.ModificadorId });

            modelBuilder.Entity<DetalleModificador>()
                .HasOne(dm => dm.Producto)
                .WithMany(p => p.DetalleModificadores)
                .HasForeignKey(dm => dm.Id); // Esto debería ser dm.ProductoId probablemente

            modelBuilder.Entity<DetalleModificador>()
                .HasOne(dm => dm.Modificador)
                .WithMany(m => m.DetalleModificadores)
                .HasForeignKey(dm => dm.Id); // Esto debería ser dm.ModificadorId probablemente
        }

        //migracion
        //.\Scripts\migrar.bat
    }
}