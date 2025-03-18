
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTech.Models
{
    [Table("Treinos")]
    public class Treino
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string UserId { get; set; } // Identificador do usuário
        public List<Exercicio> Exercises { get; set; } = new List<Exercicio>();
    }
}

