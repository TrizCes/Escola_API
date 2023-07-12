using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Escola.API.Model
{
    public class Materia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<NotasMateria> NotasMaterias { get; set; }
    }
}
