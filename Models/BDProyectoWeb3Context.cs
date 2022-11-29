using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoWEBAdministracionHorarios.Models
{
    public partial class BDProyectoWeb3Context : DbContext
    {
        public BDProyectoWeb3Context()
        {
        }

        public BDProyectoWeb3Context(DbContextOptions<BDProyectoWeb3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<Fecha> Fechas { get; set; } = null!;
        public virtual DbSet<Horario> Horarios { get; set; } = null!;
        public virtual DbSet<TipoDeHorario> TipoDeHorarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=DESKTOP-F5D95K0\\SQLEXPRESS; database=BDProyectoWeb3; integrated security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("Empleado");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.HasMany(d => d.IdTipoDeHorarios)
                    .WithMany(p => p.IdEmpleados)
                    .UsingEntity<Dictionary<string, object>>(
                        "EmpleadoTipoFecha",
                        l => l.HasOne<TipoDeHorario>().WithMany().HasForeignKey("IdTipoDeHorario").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EmpleadoTipoFecha_TipoDeHorario"),
                        r => r.HasOne<Empleado>().WithMany().HasForeignKey("IdEmpleado").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_EmpleadoTipoFecha_Empleado"),
                        j =>
                        {
                            j.HasKey("IdEmpleado", "IdTipoDeHorario");

                            j.ToTable("EmpleadoTipoFecha");

                            j.IndexerProperty<int>("IdEmpleado").HasColumnName("idEmpleado");

                            j.IndexerProperty<int>("IdTipoDeHorario").HasColumnName("idTipoDeHorario");
                        });
            });

            modelBuilder.Entity<Fecha>(entity =>
            {
                entity.ToTable("Fecha");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FechaFin)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaFin");

                entity.Property(e => e.FechaInicio)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaInicio");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.ToTable("Horario");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Domingo)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("domingo")
                    .IsFixedLength();

                entity.Property(e => e.FechaRegistro)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaRegistro")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.HoraFin)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("horaFin");

                entity.Property(e => e.HoraInicio)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("horaInicio");

                entity.Property(e => e.Jueves)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("jueves")
                    .IsFixedLength();

                entity.Property(e => e.Lunes)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasComment("0 INACTIVO\r\n1 ACTIVO");

                entity.Property(e => e.Martes)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("martes")
                    .IsFixedLength();

                entity.Property(e => e.Miercoles)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("miercoles")
                    .IsFixedLength();

                entity.Property(e => e.Sabado)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("sabado")
                    .IsFixedLength();

                entity.Property(e => e.Viernes)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("viernes")
                    .IsFixedLength();
            });

            modelBuilder.Entity<TipoDeHorario>(entity =>
            {
                entity.ToTable("TipoDeHorario");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdFecha).HasColumnName("idFecha");

                entity.Property(e => e.IdHorario).HasColumnName("idHorario");

                entity.Property(e => e.Tipo)
                    .HasColumnName("tipo")
                    .HasDefaultValueSql("((1))")
                    .HasComment("0 temporal\r\n1 estatico");

                entity.HasOne(d => d.IdFechaNavigation)
                    .WithMany(p => p.TipoDeHorarios)
                    .HasForeignKey(d => d.IdFecha)
                    .HasConstraintName("FK_TipoDeHorario_Fecha");

                entity.HasOne(d => d.IdHorarioNavigation)
                    .WithMany(p => p.TipoDeHorarios)
                    .HasForeignKey(d => d.IdHorario)
                    .HasConstraintName("FK_TipoDeHorario_Horario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
