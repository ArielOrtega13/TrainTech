using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTech.Models
{
    [Table("Exercicios")]
    public class Exercicio
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Series { get; set; }
        [Required]
        public int Repetitions { get; set; }
        [Required]
        public int Load { get; set; }
        [Required]
        public bool IsCompleted { get; set; } = false;

        public ICollection<ExercicioUsuarios> Usuarios { get; set; }

    }
}
