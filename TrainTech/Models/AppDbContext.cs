
using Microsoft.EntityFrameworkCore;

namespace TrainTech.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ExercicioUsuarios>()
                .HasKey(c => new { c.ExerciciosId, c.UsuarioId });

            builder.Entity<ExercicioUsuarios>()
                .HasOne(c => c.Exercicio).WithMany(c => c.Usuarios)
                .HasForeignKey(c => c.ExerciciosId);

            builder.Entity<ExercicioUsuarios>()
                .HasOne(c => c.Usuario).WithMany(c => c.Exercicios)
                .HasForeignKey(c => c.UsuarioId);
        }


        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<DiaTreino> DiaTreino { get; set; }

        public DbSet<Usuario> Usuarios{ get; set; }

        public DbSet<ExercicioUsuarios> ExerciciosUsuarios { get; set; }
    }
}
