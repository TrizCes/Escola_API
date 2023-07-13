using Escola.API.Model;
using System.Collections.Generic;

namespace Escola.API.Interfaces.Services
{
    public interface IBoletimService
    {
        public Boletim Criar(Boletim boletim);
        public Boletim ObterPorId(int id);

        public List<Boletim> ObterBoletinsAluno(int alunoId);
        public Boletim Atualizar(Boletim boletim);
        public List<Boletim> ObterBoletins();
        public void DeletarBoletim(int id);
    }
}
