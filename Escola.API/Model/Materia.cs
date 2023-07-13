using Escola.API.DTO;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Escola.API.Model
{
    public class Materia
    {
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<NotasMateria> NotasMaterias { get; set; }

        public Materia() { }
        public Materia(MateriaDTO materiaDTO)
        {
            Id = materiaDTO.Id;
            Nome = materiaDTO.Nome;

        }

        public void Update(Materia materia)
        {
            Id = materia.Id;
            Nome = materia.Nome;
        }
    }
}
