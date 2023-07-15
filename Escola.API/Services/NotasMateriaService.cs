using Escola.API.DataBase.Repositories;
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
        private readonly IMateriaService _materiaService;

        public NotasMateriaService(INotasMateriaRepository repository, IBoletimService boletimService, IMateriaService materiaService)
        {
            _repository = repository;
            _boletimService = boletimService;
            _materiaService = materiaService;
        }
        public NotasMateria ObterPorId(int id)
        {
            NotasMateria notas = _repository.ObterPorId(id);
            if(notas == null) throw new NotFoundException("Arquivo indisponível");
            return notas;
        }

        public List<NotasMateria> ObterNotasBoletim(int boletimId)
        {
            var notasBoletins = _repository.ObterNotasBoletim(boletimId);
            if (notasBoletins.Count == 0) throw new NotFoundException("Boletim não possui notas relacionadas a ele no sistema");
           
            return notasBoletins;
        }

        public NotasMateria Atualizar(NotasMateria notasMateria)
        {
            throw new System.NotImplementedException();
        }

        public NotasMateria Criar(NotasMateria notasMateria)
        {
            if (_boletimService.ObterPorId(notasMateria.BoletimId) == null)
            {
                throw new NotFoundException("Boletim não consta no nosso banco de dados");
            }
            if (_materiaService.ObterPorId(notasMateria.MateriaId) == null)
            {
                throw new NotFoundException("A matéria não consta no nosso banco de dados");
            }
            _repository.Inserir(notasMateria);
            return notasMateria;
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
