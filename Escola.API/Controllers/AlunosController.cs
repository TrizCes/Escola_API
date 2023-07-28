using Escola.API.DTO;
using Escola.API.Exceptions;
using Escola.API.Interfaces.Services;
using Escola.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Escola.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunoService _alunoService;
        private readonly IMemoryCache _memoryCache;

        public AlunosController( IAlunoService alunoService, IMemoryCache memoryCache)
        {
            _alunoService = alunoService;
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AlunoDTO alunoDTO)
        {
            try
            {
                var aluno = new Aluno(alunoDTO);
                //Chamada da service
                aluno = _alunoService.Criar(aluno);

                return Ok(new AlunoDTO(aluno));
            }
            catch (RegistroDuplicadoException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
                //return Conflict("email já existe")
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<AlunoDTO> Get()
        {
            try
            {   
                var alunos = _alunoService.ObterAlunos();
                IEnumerable<AlunoDTO> alunosDtos = alunos.Select(x => new AlunoDTO(x));       
                return Ok(alunosDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }            
        }


        [HttpGet]
        [Route("/{id}")]
        public IActionResult GetComId([FromRoute] int id)
        {
            try
            {
                AlunoDTO aluno;
                if(!_memoryCache.TryGetValue<AlunoDTO>($"aluno:{id}", out  aluno)){
                     aluno = new AlunoDTO(_alunoService.ObterPorId(id));
                    _memoryCache.Set<AlunoDTO>($"aluno:{id}", aluno, new TimeSpan(0,0,20));
                }
                return Ok(aluno);
            }

            catch (RegistroDuplicadoException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
                //return Conflict("email já existe")
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
                
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpPut]
        [Route("/{id}")]
        public IActionResult AtualizaAluno([FromBody] AlunoDTO alunoDTO, [FromRoute] int id)
        {
            try
            {
                var aluno = new Aluno(alunoDTO);
                aluno.Id = id;
                if (!ModelState.IsValid) return BadRequest("Dados inválidos, favor verificar o formato obrigatório dos dados!");

                aluno = _alunoService.Atualizar(aluno);

                //var alunodto = new AlunoDTO(aluno);
                //_memoryCache.Set<AlunoDTO>($"aluno:{id}", alunodto, new TimeSpan(0, 0, 20));

                _memoryCache.Remove($"aluno:{id}");

                return Ok(new AlunoDTO(aluno));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        [Route("/{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
               _alunoService.DeletarAluno(id);
                _memoryCache.Remove($"aluno:{id}");
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }

            return StatusCode(204);
        }
    }
}
