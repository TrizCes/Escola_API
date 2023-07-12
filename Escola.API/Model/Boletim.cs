using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola.API.Model
{
    public class Boletim
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Aluno")]
        [Required]
        public int AlunoId { get; set; }
        private Aluno Aluno { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

    }
}
