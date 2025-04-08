using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainTech.Models
{
    [Table("DiaTreino")]
    public class DiaTreino
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Data { get; set; }

    
    }
}
