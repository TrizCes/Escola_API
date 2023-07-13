using Escola.API.Interfaces.Repositories;
using Escola.API.Model;
using System.Collections.Generic;
using System.Linq;

namespace Escola.API.DataBase.Repositories
{
    public class BoletimRepository : BaseRepository<Boletim, int>, IBoletimRepository
    {
        public BoletimRepository(EscolaDbContexto contexto) : base(contexto)
        {

        }

        public override Boletim ObterPorId(int id)
        {
            return _context.Boletins.FirstOrDefault(x => id == x.Id);
        }

        public List<Boletim> ObterBoletinsAluno(int alunoId)
        {
            var boletinsAluno = _context.Set<Boletim>().Where(x => alunoId == x.AlunoId).ToList();

            return boletinsAluno;
        }
    }
}
