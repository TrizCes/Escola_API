using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola.API.Model
{
    public class NotasMateria
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Boletim")]
        [Required]
        public int BoletimId { get; set; }
        private Boletim Boletim { get; set; }

        [ForeignKey("Materia")]
        [Required]
        public int MateriaId { get; set; }
        private Materia Materia { get; set; }
    }
}
