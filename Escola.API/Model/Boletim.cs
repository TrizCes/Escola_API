using System;
using System.Collections.Generic;

namespace Escola.API.Model
{
    public class Boletim
    {
        public int Id { get; set; }

        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }

        public DateTime DateTime { get; set; }
        public ICollection<NotasMateria> NotasMaterias { get; set; }

    }
}
