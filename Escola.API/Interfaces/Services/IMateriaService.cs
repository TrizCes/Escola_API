using Escola.API.Model;
using System.Collections.Generic;

namespace Escola.API.Interfaces.Services
{
    public interface IMateriaService
    {
        public Materia Criar(Materia materia);
        public Materia ObterPorId(int id);
        public Materia ObterPorNome(string nome);
        public Materia Atualizar(Materia materia);
        public List<Materia> ObterMaterias();
        public void DeletarMateria(int id);
    }
}
