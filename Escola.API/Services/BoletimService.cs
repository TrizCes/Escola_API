using Escola.API.DataBase.Repositories;
using Escola.API.Exceptions;
using Escola.API.Interfaces.Repositories;
using Escola.API.Interfaces.Services;
using Escola.API.Model;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace Escola.API.Services
{
    public class BoletimService : IBoletimService
    {
        private readonly IBoletimRepository _boletimRepository;
        public BoletimService(IBoletimRepository boletimRepository)
        {
            _boletimRepository = boletimRepository;
        }

        public Boletim ObterPorId(int id) 
        {
            Boletim boletim = _boletimRepository.ObterPorId(id);

            if (boletim == null)
            {
                throw new NotFoundException("Materia não encontrada");
            }
            return boletim;
        }
        public List<Boletim> ObterBoletinsAluno(int alunoId) 
        { 
            var boletins =  _boletimRepository.ObterBoletinsAluno(alunoId);
            if (boletins == null)
            {
                throw new NotFoundException("Aluno não encontrado");
            }
            return boletins;
        }
        public List<Boletim> ObterBoletins() => _boletimRepository.ObterTodos();

        public Boletim Criar(Boletim boletim) { return boletim; }
        public Boletim Atualizar(Boletim boletim) { return boletim; }
        public void DeletarBoletim(int id) { }
    }
}
