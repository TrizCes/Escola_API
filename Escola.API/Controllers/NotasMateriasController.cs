using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Escola.API.DataBase;
using Escola.API.Model;
using Escola.API.Interfaces.Services;
using Escola.API.Exceptions;
using Escola.API.DTO;
using Escola.API.Services;
using Microsoft.AspNetCore.Authorization;

namespace Escola.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Professor")]
    public class NotasMateriasController : ControllerBase
    {
        private readonly INotasMateriaService _notasMateriaService;

        public NotasMateriasController(INotasMateriaService notasMateriasService)
        {
            _notasMateriaService = notasMateriasService;   
        }

        // POST: /NotasMaterias
        [HttpPost("/NotasMateria")]
        public ActionResult<NotasMateria> PostNotasMateria([FromBody] NotasMateriaDTO notasMateriaDTO)
        {
            notasMateriaDTO.Id = _notasMateriaService.Criar(new NotasMateria(notasMateriaDTO)).Id;

            return Ok(notasMateriaDTO);
        }

        // PUT: api/NotasMaterias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/NotasMateria/{id}")]
        public IActionResult PutNotasMateria(int id, NotasMateriaDTO notasMateriaDTO)
        {
            notasMateriaDTO.Id = id;
            return Ok(new NotasMateriaDTO(_notasMateriaService.Atualizar(new NotasMateria(notasMateriaDTO))));
        }

        // GET: NotasMaterias/5
        [HttpGet("{id}")]
        public ActionResult<NotasMateria> GetNotasMateria(int id)
        {
            var notasMateria = _notasMateriaService.ObterPorId(id);
            return Ok(new NotasMateriaDTO (notasMateria));
        }

        // GET: NotasMaterias
        [HttpGet("/alunos/boletins/{boletimId}/NotasMateria/")]
        public ActionResult<NotasMateria> GetNotasMaterias(int boletimId)
        {
            var notasMateria = _notasMateriaService.ObterNotasBoletim(boletimId);
            return Ok(notasMateria);
        }

        // DELETE: /NotasMaterias/5
        [HttpDelete("/NotasMaterias/{id}")]
        public IActionResult DeleteNotasMateria(int id)
        {

            _notasMateriaService.DeletarNota(id);
            return StatusCode(204);
        }
        
    }
}
