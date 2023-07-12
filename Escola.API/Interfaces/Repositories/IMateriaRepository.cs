using Escola.API.Model;

namespace Escola.API.Interfaces.Repositories
{
    public interface IMateriaRepository : IBaseRepository<Materia, int>
    {
        public Materia ObterPorNome(string nome);
    }
}
