using DataBase.Entitys;
using Microsoft.EntityFrameworkCore;

namespace DataBase;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<UsuarioCurso> UsuarioCursos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("usuarios");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome).HasColumnName("nome");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Senha).HasColumnName("senha");
            entity.Property(e => e.Email).HasColumnName("email");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.ToTable("cursos");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome).HasColumnName("nome");
            entity.Property(e => e.Descricao).HasColumnName("descricao");
        });

        modelBuilder.Entity<UsuarioCurso>(entity =>
        {
            entity.ToTable("usuario_cursos");

            entity.HasKey(uc => new { uc.UsuarioId, uc.CursoId });

            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            entity.Property(e => e.CursoId).HasColumnName("curso_id");

            entity.HasOne(uc => uc.Usuario)
                .WithMany(u => u.UsuarioCursos)
                .HasForeignKey(uc => uc.UsuarioId);

            entity.HasOne(uc => uc.Curso)
                .WithMany(c => c.UsuarioCursos)
                .HasForeignKey(uc => uc.CursoId);
        });
    }
}