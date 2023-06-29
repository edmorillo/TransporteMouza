using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TransporteMouza.Models
{
    public partial class TAIContext : DbContext
    {
        public TAIContext()
        {
        }

        public TAIContext(DbContextOptions<TAIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chofere> Choferes { get; set; } = null!;
        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Compra> Compras { get; set; } = null!;
        public virtual DbSet<Neumatico> Neumaticos { get; set; } = null!;
        public virtual DbSet<Provincium> Provincia { get; set; } = null!;
        public virtual DbSet<TipoUnidade> TipoUnidades { get; set; } = null!;
        public virtual DbSet<Unidad> Unidads { get; set; } = null!;
        public virtual DbSet<Viaje> Viajes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=NT-F0FQVP2\\SQLEXPRESS; DataBase=TAI; Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chofere>(entity =>
            {
                entity.HasKey(e => e.IdChoferes)
                    .HasName("PK__Choferes__3596523F3A702C8C");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Cuil)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dni).HasColumnName("DNI");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNac).HasColumnType("date");

                entity.Property(e => e.LicenciaVen).HasColumnType("date");

                entity.Property(e => e.Matricula)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.ProvNavigation)
                    .WithMany(p => p.Choferes)
                    .HasForeignKey(d => d.Prov)
                    .HasConstraintName("FK_Provincia");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PK__Clientes__D59466421DABC52F");

                entity.Property(e => e.ConIva)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Cuitclie).HasColumnName("CUITClie");

                entity.Property(e => e.DireccionC)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.IngresosBrutos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Localidad)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSoc)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PK__Compras__0A5CDB5CDABDF88F");

                entity.Property(e => e.Detalle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCompra).HasColumnType("date");

                entity.Property(e => e.FormaDePago)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Neumatico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("money");
            });

            modelBuilder.Entity<Neumatico>(entity =>
            {
                entity.HasKey(e => e.IdNeumatico)
                    .HasName("PK__Neumatic__AA974EFD5253775E");

                entity.Property(e => e.Detalle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Marca)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rodado)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.Neumaticos)
                    .HasForeignKey(d => d.IdCompra)
                    .HasConstraintName("FK_Compras");

                entity.HasOne(d => d.IdTipoUnidadNavigation)
                    .WithMany(p => p.Neumaticos)
                    .HasForeignKey(d => d.IdTipoUnidad)
                    .HasConstraintName("FK_TipoUnidades");
            });

            modelBuilder.Entity<Provincium>(entity =>
            {
                entity.HasKey(e => e.IdProvincia)
                    .HasName("PK__Provinci__EED744558199277B");

                entity.Property(e => e.IdProvincia).ValueGeneratedNever();

                entity.Property(e => e.Provincia)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoUnidade>(entity =>
            {
                entity.HasKey(e => e.IdTipoUnidad)
                    .HasName("PK__TipoUnid__23FD7E6A5D2E6512");

                entity.Property(e => e.Chasis)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Detalle)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Unidad>(entity =>
            {
                entity.HasKey(e => e.IdUnidad)
                    .HasName("PK__Unidad__437725E67E598C6E");

                entity.ToTable("Unidad");

                entity.Property(e => e.EstadoDocumentacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FecCompra).HasColumnType("date");

                entity.Property(e => e.FecMantenimiento).HasColumnType("date");

                entity.Property(e => e.Matricula)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Viaje>(entity =>
            {
                entity.HasKey(e => e.IdViajes)
                    .HasName("PK__Viajes__3505F3980E2BC65D");

                entity.Property(e => e.Destino)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Detalle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NumContenedor)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Origen)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Tarifa).HasColumnType("money");

                entity.HasOne(d => d.IdChoferesNavigation)
                    .WithMany(p => p.Viajes)
                    .HasForeignKey(d => d.IdChoferes)
                    .HasConstraintName("fk_Viaje_Choferes");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Viajes)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("fk_Viaje_Cliente");

                entity.HasOne(d => d.IdUnidadNavigation)
                    .WithMany(p => p.Viajes)
                    .HasForeignKey(d => d.IdUnidad)
                    .HasConstraintName("fk_Viaje_Unidad");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
