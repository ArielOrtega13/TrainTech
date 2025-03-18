using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTech.Models
{
    [Table("Exercicios")]
    public class Exercicio
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Series { get; set; }
        [Required]
        public int Repetitions { get; set; }
        [Required]
        public double Load { get; set; } // Carga recomendada 
        [Required]
        public bool IsCompleted { get; set; } = false;
    }
}
