using Escola.API.Interfaces.Repositories;
using Escola.API.Model;
using System.Linq;

namespace Escola.API.DataBase.Repositories
{
    public class MateriaRepository : BaseRepository<Materia, int>, IMateriaRepository
    {
        public MateriaRepository(EscolaDbContexto contexto) : base(contexto)
        {

        }

        public override Materia ObterPorId(int id)
        {
            return _context.Materias.FirstOrDefault(x => id == x.Id);
        }

        public Materia ObterPorNome(string nome)
        {
            return _context.Materias.FirstOrDefault(x => nome == x.Nome);
        }
    }
}
