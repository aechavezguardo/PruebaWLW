using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Context
{
    public class DevLabContext : DbContext
    {
        public DevLabContext(DbContextOptions<DevLabContext> options) : base(options) { }

        public DbSet<CatProducto> CatProductos { get; set; }
        public DbSet<CatTipoCliente> CatTipoClientes { get; set; }
        public DbSet<TblCliente> TblClientes { get; set; }
        public DbSet<TblFactura> TblFacturas { get; set; }
        public DbSet<TblDetalleFactura> TblDetallesFactura { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CatProducto>()
                .ToTable("CatProductos");

            modelBuilder.Entity<CatProducto>()
                .Property(p => p.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd(); 

            modelBuilder.Entity<CatProducto>()
                .Property(p => p.NombreProducto)
                .HasColumnName("NombreProducto")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<CatProducto>()
                .Property(p => p.ImagenProducto)
                .HasColumnName("ImagenProducto")
                .HasColumnType("image");

            modelBuilder.Entity<CatProducto>()
                .Property(p => p.PrecioUnitario)
                .HasColumnName("PrecioUnitario")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<CatProducto>()
                .Property(p => p.Ext)
                .HasColumnName("ext")
                .HasMaxLength(5);

            modelBuilder.Entity<CatTipoCliente>()
                .ToTable("CatTipoCliente");

            modelBuilder.Entity<CatTipoCliente>()
                .Property(t => t.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CatTipoCliente>()
                .Property(t => t.TipoCliente)
                .HasColumnName("TipoCliente")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<TblCliente>()
                .ToTable("TblClientes");

            modelBuilder.Entity<TblCliente>()
                .Property(c => c.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TblCliente>()
                .Property(c => c.RazonSocial)
                .HasColumnName("RazonSocial")
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<TblCliente>()
                .Property(c => c.IdTipoCliente)
                .HasColumnName("IdTipoCliente")
                .IsRequired();

            modelBuilder.Entity<TblCliente>()
                .Property(c => c.FechaCreacion)
                .HasColumnName("FechaCreacion")
                .HasColumnType("date")
                .IsRequired();

            modelBuilder.Entity<TblCliente>()
                .Property(c => c.RFC)
                .HasColumnName("RFC")
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<TblFactura>()
                .ToTable("TblFacturas");

            modelBuilder.Entity<TblFactura>()
                .Property(f => f.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TblFactura>()
                .Property(f => f.FechaEmisionFactura)
                .HasColumnName("FechaEmisionFactura")
                .HasColumnType("datetime")
                .IsRequired();

            modelBuilder.Entity<TblFactura>()
                .Property(f => f.IdCliente)
                .HasColumnName("IdCliente")
                .IsRequired();

            modelBuilder.Entity<TblFactura>()
                .Property(f => f.NumeroFactura)
                .HasColumnName("NumeroFactura")
                .IsRequired();

            modelBuilder.Entity<TblFactura>()
                .Property(f => f.NumeroTotalArticulos)
                .HasColumnName("NumeroTotalArticulos")
                .IsRequired();

            modelBuilder.Entity<TblFactura>()
                .Property(f => f.SubTotalFacturas)
                .HasColumnName("SubTotalFacturas")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<TblFactura>()
                .Property(f => f.TotalImpuestos)
                .HasColumnName("TotalImpuestos")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<TblFactura>()
                .Property(f => f.TotalFactura)
                .HasColumnName("TotalFactura")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<TblDetalleFactura>()
                .ToTable("TblDetallesFactura");

            modelBuilder.Entity<TblDetalleFactura>()
                .Property(d => d.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TblDetalleFactura>()
                .Property(d => d.IdFactura)
                .HasColumnName("IdFactura")
                .IsRequired();

            modelBuilder.Entity<TblDetalleFactura>()
                .Property(d => d.IdProducto)
                .HasColumnName("IdProducto")
                .IsRequired();

            modelBuilder.Entity<TblDetalleFactura>()
                .Property(d => d.CantidadDeProducto)
                .HasColumnName("CantidadDeProducto")
                .IsRequired();

            modelBuilder.Entity<TblDetalleFactura>()
                .Property(d => d.PrecioUnitarioProducto)
                .HasColumnName("PrecioUnitarioProducto")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<TblDetalleFactura>()
                .Property(d => d.SubtotalProducto)
                .HasColumnName("SubtotalProducto")
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            modelBuilder.Entity<TblDetalleFactura>()
                .Property(d => d.Notas)
                .HasColumnName("Notas")
                .HasMaxLength(200);

            modelBuilder.Entity<TblCliente>()
                .HasOne(c => c.TipoCliente)
                .WithMany()
                .HasForeignKey(c => c.IdTipoCliente)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TblDetalleFactura>()
                .HasOne(d => d.Factura)
                .WithMany()
                .HasForeignKey(d => d.IdFactura)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TblDetalleFactura>()
                .HasOne(d => d.Producto)
                .WithMany()
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TblFactura>()
                .HasOne(f => f.Cliente)
                .WithMany()
                .HasForeignKey(f => f.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
