using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
            entity.HasKey(e => e.IdCalendario).HasName("PK__Calendar__667B0B2F36629D13");

            entity.ToTable("Calendario");

            entity.Property(e => e.DescripcionCalendario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaCalendario).HasColumnType("date");
        });

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.IdEstudiante).HasName("PK__Estudian__B5007C245EDE23A1");

            entity.ToTable("Estudiante");

            entity.Property(e => e.ApellidoEst)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CorreoEst)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DireccionEst)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaNacimientoEst).HasColumnType("date");
            entity.Property(e => e.IdLogin).HasColumnName("Id_login");
            entity.Property(e => e.NombreEst)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuarioEst)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PasswordEst)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoDocumentoEst)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FormaPago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PK__FormaPag__FC851A3A14D72057");

            entity.ToTable("FormaPago");

            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.TipoPago)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Geografium>(entity =>
        {
            entity.HasKey(e => e.IdGeografia).HasName("PK__Geografi__3445F5C96BFD484B");

            entity.Property(e => e.Ciudad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity.HasKey(e => e.IdLogin).HasName("PK__Login__DBFE6D377ED1A571");

            entity.ToTable("Login");

            entity.Property(e => e.IdLogin).HasColumnName("Id_login");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.User)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.IdMateria).HasName("PK__Materia__EC1746701BCF431A");

            entity.Property(e => e.CostoMateria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.NombreMateria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PruebaMateria)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Repositorio>(entity =>
        {
            entity.HasKey(e => e.IdRepositorio).HasName("PK__Reposito__57369AD836F755D3");

            entity.ToTable("Repositorio");

            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.IdNombreRepositorio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MediosRepositorio)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ResevarTutorium>(entity =>
        {
            entity.HasKey(e => e.IdReserva).HasName("PK__ResevarT__0E49C69D014FC77E");

            entity.Property(e => e.Barrio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DescripcionTutoria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DireccionTutoria)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaTutoria).HasColumnType("date");
            entity.Property(e => e.Localidad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoTutoria)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tutor>(entity =>
        {
            entity.HasKey(e => e.IdTutor).HasName("PK__Tutor__C168D3885B2FBFBD");

            entity.ToTable("Tutor");

            entity.Property(e => e.ApellidoTutor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CorreoTutor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DireccionTutor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DocumentosTutor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.ExperienciaTutor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimientoTutor).HasColumnType("date");
            entity.Property(e => e.IdLogin).HasColumnName("Id_Login");
            entity.Property(e => e.NombreTutor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuarioTutor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PasswordTutor)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.TipoDocumentoTutor)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TutorMaterium>(entity =>
        {
            entity.HasKey(e => e.IdTutorMateria).HasName("PK__TutorMat__18627F792EC32492");

            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("estado");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
