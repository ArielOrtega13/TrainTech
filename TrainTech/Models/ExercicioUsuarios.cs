using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTech.Models
{
    [Table("ExercicioUsuarios")]
    public class ExercicioUsuarios
    {
        public int ExerciciosId { get; set; }

        public Exercicio Exercicio { get; set; }    

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

    }
}
