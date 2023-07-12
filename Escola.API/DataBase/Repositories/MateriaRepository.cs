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

        public override Materia Inserir(Materia materia)
        {
            _context.Set<Materia>().Add(materia);
            _context.SaveChanges();
            return materia;
        }

        public bool MateriaJaCadastrado(string nome)
            => _context.Materias.Any(x => x.Nome == nome);
    }
}
