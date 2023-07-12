using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escola.API.Model
{
    public class NotasMateria
    {
        public int Id { get; set; }

        public int BoletimId { get; set; }
        public virtual Boletim Boletim { get; set; }

        public int MateriaId { get; set; }
        public virtual Materia Materia { get; set; }

        public int Nota { get; set; }
        
    }
}
