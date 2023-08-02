using Escola.API.Model;

namespace Escola.API.DTO
{
    public class MateriaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public MateriaDTO() { }

        public MateriaDTO(Materia materia) 
        {
            Id = materia.Id;
            Nome = materia.Nome;
        }
    }
}
