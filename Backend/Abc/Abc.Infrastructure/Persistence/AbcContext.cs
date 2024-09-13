using Abc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Abc.Infrastructure.Persistence;

public partial class AbcContext : DbContext
{
    public AbcContext()
    {
    }

    public AbcContext(DbContextOptions<AbcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Afp> Afps { get; set; }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Afp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Afp__3214EC0710781935");

            entity.ToTable("Afp");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(100);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(100);
        });

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cargo__3214EC0723BE6271");

            entity.ToTable("Cargo");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(100);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(100);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empleado__3214EC076E62BB61");

            entity.ToTable("Empleado");

            entity.HasIndex(e => e.AfpId, "idx_AfpId");

            entity.HasIndex(e => e.CargoId, "idx_CargoId");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Apellidos).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Sueldo).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(100);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(100);

            entity.HasOne(d => d.Afp).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.AfpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleado__AfpId__45F365D3");

            entity.HasOne(d => d.Cargo).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.CargoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Empleado__CargoI__44FF419A");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC07B1FA1B21");

            entity.ToTable("Role");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.UsuarioCreacion).HasMaxLength(100);
            entity.Property(e => e.UsuarioModificacion).HasMaxLength(100);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07128D6BCB");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.NombreUsuario, "UQ__Usuario__6B0F5AE0E28031E9").IsUnique();

            entity.HasIndex(e => e.RoleId, "idx_RoleId");

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.Contrasenia).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreUsuario).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuario__RoleId__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
