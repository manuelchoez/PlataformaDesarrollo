using System;
using MicroServicioUsuario.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MicroServicioUsuario.Infraestructure.Data
{
    public partial class SeguridadContext : DbContext
    {
        public SeguridadContext()
        {
        }

        public SeguridadContext(DbContextOptions<SeguridadContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pantalla> Pantallas { get; set; }
        public virtual DbSet<Perfil> Perfils { get; set; }
        public virtual DbSet<PerfilPantalla> PerfilPantallas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioPerfil> UsuarioPerfils { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-JIJ5VUP\\SQLEXPRESS;Database=Seguridad;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Pantalla>(entity =>
            {
                entity.HasKey(e => e.IdPantalla)
                    .HasName("PK__Pantalla__CAF8EE4FC610537A");

                entity.ToTable("Pantalla");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.HasKey(e => e.IdPerfil)
                    .HasName("PK__Perfil__C7BD5CC1924E0879");

                entity.ToTable("Perfil");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PerfilPantalla>(entity =>
            {
                entity.HasKey(e => e.IdPerfilPantalla)
                    .HasName("PK__PerfilPa__000CD683AA1C2538");

                entity.ToTable("PerfilPantalla");

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.HasOne(d => d.IdPantallaNavigation)
                    .WithMany(p => p.PerfilPantallas)
                    .HasForeignKey(d => d.IdPantalla)
                    .HasConstraintName("FK__PerfilPan__IdPan__59063A47");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.PerfilPantallas)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("FK__PerfilPan__IdPer__5812160E");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF97F7AA56A2");

                entity.ToTable("Usuario");

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UsuarioPerfil>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioPerfil)
                    .HasName("PK__UsuarioP__96C517D5137699AE");

                entity.ToTable("UsuarioPerfil");

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");

                entity.HasOne(d => d.IdPerfilNavigation)
                    .WithMany(p => p.UsuarioPerfils)
                    .HasForeignKey(d => d.IdPerfil)
                    .HasConstraintName("FK__UsuarioPe__IdPer__5535A963");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuarioPerfils)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__UsuarioPe__IdUsu__5441852A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
