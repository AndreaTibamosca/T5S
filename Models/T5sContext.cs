using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using T5S.MoldelsView;

namespace T5S.Models;

public partial class T5sContext : DbContext
{
    public T5sContext()
    {
    }

    public T5sContext(DbContextOptions<T5sContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Calendario> Calendarios { get; set; }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<FormaPago> FormaPagos { get; set; }

    public virtual DbSet<Geografium> Geografia { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

    public virtual DbSet<Repositorio> Repositorios { get; set; }

    public virtual DbSet<ResevarTutorium> ResevarTutoria { get; set; }

    public virtual DbSet<Tutor> Tutors { get; set; }

    public virtual DbSet<TutorMaterium> TutorMateria { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=HEIDY; Database=T5S; Trusted_Connection=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Calendario>(entity =>
        {
            entity.HasKey(e => e.IdCalendario);

            entity.ToTable("Calendario");

            entity.Property(e => e.IdCalendario).ValueGeneratedNever();
            entity.Property(e => e.DescripcionCalendario)
                .HasMaxLength(20)
                .IsFixedLength();
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCalendario).HasColumnType("date");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante);

            entity.ToTable("Estudiante");

            entity.Property(e => e.IdEstudiante).ValueGeneratedNever();
            entity.Property(e => e.ApellidoEst)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.CorreoEst)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.DireccionEst)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaNacimientoEst).HasColumnType("date");
            entity.Property(e => e.IdLogin).HasColumnName("Id_login");
            entity.Property(e => e.NombreEst)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.NombreUsuarioEst)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.PasswordEst)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.TipoDocumentoEst)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        modelBuilder.Entity<FormaPago>(entity =>
        {
            entity.HasKey(e => e.IdPago);

            entity.ToTable("FormaPago");

            entity.Property(e => e.IdPago).ValueGeneratedNever();
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<Geografium>(entity =>
        {
            entity.HasKey(e => e.IdGeografia);

            entity.Property(e => e.IdGeografia).ValueGeneratedNever();
            entity.Property(e => e.Ciudad)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.IdLogin);

            entity.ToTable("Login");

            entity.Property(e => e.IdLogin)
                .ValueGeneratedNever()
                .HasColumnName("Id_login");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.User)
                .HasMaxLength(50)
                .IsFixedLength();


        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.IdMateria);

            entity.Property(e => e.IdMateria).ValueGeneratedNever();
            entity.Property(e => e.CostoMateria)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.NombreMateria)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.PruebaMateria)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<Repositorio>(entity =>
        {
            entity.HasKey(e => e.IdRepositorio);

            entity.ToTable("Repositorio");

            entity.Property(e => e.IdRepositorio).ValueGeneratedNever();
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.IdNombreRepositorio)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.MediosRepositorio)
                .HasMaxLength(100)
                .IsFixedLength();

            entity.HasOne(d => d.IdRepositorioNavigation).WithOne(p => p.Repositorio)
                .HasForeignKey<Repositorio>(d => d.IdRepositorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Repositorio_Tutor");
        });

        modelBuilder.Entity<ResevarTutorium>(entity =>
        {
            entity.HasKey(e => e.IdReserva);

            entity.Property(e => e.IdReserva).ValueGeneratedNever();
            entity.Property(e => e.Barrio)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.DescripcionTutoria)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.DireccionTutoria)
                .HasMaxLength(60)
                .IsFixedLength();
            entity.Property(e => e.FechaTutoria).HasColumnType("date");
            entity.Property(e => e.Localidad)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.TipoTutoria)
                .HasMaxLength(50)
                .IsFixedLength();

            entity.HasOne(d => d.IdReservaNavigation).WithOne(p => p.ResevarTutorium)
                .HasForeignKey<ResevarTutorium>(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResevarTutoria_Calendario");

            entity.HasOne(d => d.IdReserva1).WithOne(p => p.ResevarTutorium)
                .HasForeignKey<ResevarTutorium>(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResevarTutoria_Estudiante");

            entity.HasOne(d => d.IdReserva2).WithOne(p => p.ResevarTutorium)
                .HasForeignKey<ResevarTutorium>(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResevarTutoria_Geografia");

            entity.HasOne(d => d.IdReserva3).WithOne(p => p.ResevarTutorium)
                .HasForeignKey<ResevarTutorium>(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResevarTutoria_Materia");

            entity.HasOne(d => d.IdReserva4).WithOne(p => p.ResevarTutorium)
                .HasForeignKey<ResevarTutorium>(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResevarTutoria_FormaPago");

            entity.HasOne(d => d.IdReserva5).WithOne(p => p.ResevarTutorium)
                .HasForeignKey<ResevarTutorium>(d => d.IdReserva)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResevarTutoria_Tutor");
        });

        modelBuilder.Entity<Tutor>(entity =>
        {
            entity.HasKey(e => e.IdTutor);

            entity.ToTable("Tutor");

            entity.Property(e => e.IdTutor).ValueGeneratedNever();
            entity.Property(e => e.ApellidoTutor)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.CorreoTutor)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.DireccionTutor)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.DocumentosTutor)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.ExperienciaTutor)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.FechaNacimientoTutor).HasColumnType("date");
            entity.Property(e => e.IdLogin).HasColumnName("Id_Login");
            entity.Property(e => e.NombreTutor)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.NombreUsuarioTutor)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.PasswordTutor)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.TipoDocumentoTutor)
                .HasMaxLength(100)
                .IsFixedLength();

            entity.HasOne(d => d.IdTutorNavigation).WithOne(p => p.Tutor)
                .HasForeignKey<Tutor>(d => d.IdTutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tutor_ResevarTutoria");


            entity.HasOne(d => d.IdTutor2).WithOne(p => p.Tutor)
                .HasForeignKey<Tutor>(d => d.IdTutor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tutor_TutorMateria");
        });

        modelBuilder.Entity<TutorMaterium>(entity =>
        {
            entity.HasKey(e => e.IdTutorMateria);

            entity.Property(e => e.IdTutorMateria).ValueGeneratedNever();
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");

            entity.HasOne(d => d.IdTutorMateriaNavigation).WithOne(p => p.TutorMaterium)
                .HasForeignKey<TutorMaterium>(d => d.IdTutorMateria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TutorMateria_Materia");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<T5S.MoldelsView.CalendarioMV>? CalendarioMV { get; set; }
}
