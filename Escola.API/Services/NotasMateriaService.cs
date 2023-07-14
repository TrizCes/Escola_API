using Escola.API.Exceptions;
using Escola.API.Interfaces.Repositories;
using Escola.API.Interfaces.Services;
using Escola.API.Model;
using System.Collections.Generic;

namespace Escola.API.Services
{
    public class NotasMateriaService : INotasMateriaService
    {
        private readonly INotasMateriaRepository _repository;
        private readonly IBoletimService _boletimService;

        public NotasMateriaService(INotasMateriaRepository repository, IBoletimService boletimService)
        {
            _repository = repository;
            _boletimService = boletimService;
        }
        public NotasMateria ObterPorId(int id)
        {
            NotasMateria notas = _repository.ObterPorId(id);
            if(notas == null) throw new NotFoundException("Arquivo indisponível");
            return notas;
        }

        public List<NotasMateria> ObterNotasBoletim(int alunoId, int boletimId)
        {
            var notasBoletins = _repository.ObterNotasBoletim(boletimId);
            if (notasBoletins.Count == 0) throw new NotFoundException("Boletim inexistente");
            var boletinsAluno = _boletimService.ObterBoletinsAluno(alunoId);

            List<NotasMateria> confirmaAluno = new List<NotasMateria>();

            foreach (var notas in notasBoletins)
            {
                foreach (var boletimAluno in boletinsAluno)
                {
                    if (boletimAluno.Id == notas.BoletimId) 
                    {
                        confirmaAluno.Add(notas);
                    }
                }
            }
            if (confirmaAluno.Count == 0)
            {
                throw new NotFoundException("O Id Aluno e o Id Boletim não conferem;");
            }

            return confirmaAluno;
        }

        public NotasMateria Atualizar(NotasMateria notasMateria)
        {
            throw new System.NotImplementedException();
        }

        public NotasMateria Criar(NotasMateria notasMateria)
        {
            throw new System.NotImplementedException();
        }

        public void DeletarBoletim(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<NotasMateria> ObterBoletins()
        {
            throw new System.NotImplementedException();
        }

        

        
    }
}
