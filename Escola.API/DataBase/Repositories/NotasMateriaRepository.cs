using Escola.API.Interfaces.Repositories;
using Escola.API.Model;
using System.Collections.Generic;
using System.Linq;

namespace Escola.API.DataBase.Repositories
{
    public class NotasMateriaRepository : BaseRepository<NotasMateria, int>, INotasMateriaRepository
    {
        public NotasMateriaRepository(EscolaDbContexto contexto) : base(contexto)
        {
        }

        public List<NotasMateria> ObterNotasBoletim(int boletimId)
        {
            var boletinsNotas = _context.Set<NotasMateria>().Where(x => boletimId == x.BoletimId).ToList();

            return boletinsNotas;
        }
    }
}
