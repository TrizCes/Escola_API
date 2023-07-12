using Escola.API.Interfaces.Services;
using Escola.API.Interfaces.Repositories;
using Escola.API.Model;
using Escola.API.Exceptions;
using System.Collections.Generic;

namespace Escola.API.Services
{
    public class MateriaService : IMateriaService
    {
        private readonly IMateriaRepository _materiaRepository;
        public MateriaService(IMateriaRepository materiaRepository)
        {
            _materiaRepository = materiaRepository;
        }

        public List<Materia> ObterMaterias() => _materiaRepository.ObterTodos();
        public Materia ObterPorId(int id)
        {
            Materia materia = _materiaRepository.ObterPorId(id);

            if (materia == null)
            {
                throw new NotFoundException("Materia não encontrada");
            }
            return materia;
        }
        public Materia ObterPorNome(string nome)
        {
            Materia materia = _materiaRepository.ObterPorNome(nome);

            if (materia == null)
            {
                throw new NotFoundException("Materia não encontrada");
            }
            return materia;
        }

        public Materia Criar(Materia materia) { return materia; }
        public Materia Atualizar(Materia materia) { return materia; }
        public void DeletarMateria(int id) { }
    }
}
