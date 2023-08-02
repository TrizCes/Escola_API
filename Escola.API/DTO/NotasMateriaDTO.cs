using Escola.API.Model;

namespace Escola.API.DTO
{
    public class NotasMateriaDTO
    {
        public int Id { get; set; }
        public int BoletimId { get; set; }
        public int MateriaId { get; set; }
        public int Nota { get; set; }

        public NotasMateriaDTO() { }
        public NotasMateriaDTO(NotasMateria notasMateria)
        {
            Id = notasMateria.Id;
            BoletimId = notasMateria.BoletimId;
            MateriaId = notasMateria.MateriaId;
            Nota = notasMateria.Nota;
        }
    }
}
