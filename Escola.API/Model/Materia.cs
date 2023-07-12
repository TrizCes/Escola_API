using System.ComponentModel.DataAnnotations;

namespace Escola.API.Model
{
    public class Materia
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }
    }
}
