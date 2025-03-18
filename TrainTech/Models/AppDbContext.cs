
using Microsoft.EntityFrameworkCore;

namespace TrainTech.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) 
               {
        }
        
                
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Treino> Treinos { get; set; }  
    }
}
