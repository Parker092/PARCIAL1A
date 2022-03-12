using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PARCIAL1A.Models
{
    public partial class PARCIAL1AContext : DbContext
    {
        public PARCIAL1AContext()
        {
        }

        public PARCIAL1AContext(DbContextOptions<PARCIAL1AContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CompraElemento> CompraElementos { get; set; }
        public virtual DbSet<Elemento> Elementos { get; set; }
        public virtual DbSet<ElementosPorPlato> ElementosPorPlatos { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Plato> Platos { get; set; }
        public virtual DbSet<PlatosPorCombo> PlatosPorCombos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost; Database=PARCIAL1A; Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<CompraElemento>(entity =>
            {
                entity.HasKey(e => e.CompraId)
                    .HasName("PK__CompraEl__067DA7256E5CE030");

                entity.Property(e => e.CompraId).HasColumnName("CompraID");

                entity.Property(e => e.ElementoId).HasColumnName("ElementoID");

                entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCompra).HasColumnType("date");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.HasOne(d => d.Elemento)
                    .WithMany(p => p.CompraElementos)
                    .HasForeignKey(d => d.ElementoId)
                    .HasConstraintName("FK_compra_elementos");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.CompraElementos)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK_compra_empresa");
            });

            modelBuilder.Entity<Elemento>(entity =>
            {
                entity.Property(e => e.ElementoId).HasColumnName("ElementoID");

                entity.Property(e => e.Elemento1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Elemento");

                entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Inventario).HasColumnName("inventario");

                entity.Property(e => e.UnidadMedida)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Elementos)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK_elemento_empresa");
            });

            modelBuilder.Entity<ElementosPorPlato>(entity =>
            {
                entity.HasKey(e => e.ElementoPorPlatoId)
                    .HasName("PK__Elemento__C628413461710061");

                entity.ToTable("ElementosPorPlato");

                entity.Property(e => e.ElementoPorPlatoId).HasColumnName("ElementoPorPlatoID");

                entity.Property(e => e.ElementoId).HasColumnName("ElementoID");

                entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.PlatoId).HasColumnName("PlatoID");

                entity.HasOne(d => d.Elemento)
                    .WithMany(p => p.ElementosPorPlatos)
                    .HasForeignKey(d => d.ElementoId)
                    .HasConstraintName("FK_elementos_plato_elementos");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.ElementosPorPlatos)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK_elementos_empresa");

                entity.HasOne(d => d.Plato)
                    .WithMany(p => p.ElementosPorPlatos)
                    .HasForeignKey(d => d.PlatoId)
                    .HasConstraintName("FK_elementos_plato");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.ToTable("Empresa");

                entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");

                entity.Property(e => e.Correo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Nit)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NIT");

                entity.Property(e => e.NombreEmpresa)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nrc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NRC");

                entity.Property(e => e.Representante)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Plato>(entity =>
            {
                entity.Property(e => e.PlatoId).HasColumnName("PlatoID");

                entity.Property(e => e.AplicaPropina)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DescripcionPlato)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Domingo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");

                entity.Property(e => e.Estado)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.Imagen)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Jueves)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Lunes)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Martes)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Miercoles)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePlato)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Precio)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Sabado)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TiempoPreparacion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Viernes)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Platos)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK_plato_empresa");
            });

            modelBuilder.Entity<PlatosPorCombo>(entity =>
            {
                entity.ToTable("PlatosPorCombo");

                entity.Property(e => e.PlatosPorComboId).HasColumnName("PlatosPorComboID");

                entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");

                entity.Property(e => e.Estado)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.FechaModificacion).HasColumnType("datetime");

                entity.Property(e => e.PlatoId).HasColumnName("PlatoID");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.PlatosPorCombos)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK_plato_combo_empresa");

                entity.HasOne(d => d.Plato)
                    .WithMany(p => p.PlatosPorCombos)
                    .HasForeignKey(d => d.PlatoId)
                    .HasConstraintName("FK_plato_combo_plato");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
