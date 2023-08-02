using Escola.API.Model;
using System.Collections.Generic;

namespace Escola.API.Interfaces.Repositories
{
    public interface INotasMateriaRepository : IBaseRepository<NotasMateria, int>
    {
        public List<NotasMateria> ObterNotasBoletim(int boletimId);

    }
}
