using Escola.API.Model;
using System.Collections.Generic;

namespace Escola.API.Interfaces.Services
{
    public interface INotasMateriaService
    {
        public NotasMateria Criar(NotasMateria notasMateria);
        public NotasMateria ObterPorId(int id);
        public NotasMateria Atualizar(NotasMateria notasMateria);
        public List<NotasMateria> ObterBoletins();
        public void DeletarBoletim(int id);
        public List<NotasMateria> ObterNotasBoletim(int alunoId, int boiletimId);
    }
}
