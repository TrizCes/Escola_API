using Microsoft.AspNetCore.Mvc;
using Escola.API.Model;
using Escola.API.Interfaces.Services;
using Escola.API.DTO;
using Microsoft.AspNetCore.Authorization;


namespace Escola.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Professor")]
    public class BoletinsController : ControllerBase
    {
        private readonly IBoletimService _boletimService;
        public BoletinsController(IBoletimService boletimService)
        {
            _boletimService = boletimService;
        }

        //Post:/alunos/{idAluno}/boletins
        [HttpPost("/alunos/{alunoId}/boletins")]
        public ActionResult Post(BoletimDTO boletim, int alunoId)
        {
                boletim.AlunoId = alunoId;
                boletim.Id = _boletimService.Criar(new Boletim (boletim)).Id;
                return Ok(boletim);
    
        }

        //Put: /alunos/{idAluno}/boletins/{id}
        [HttpPut("/alunos/{idAluno}/boletins/{id}")]
        public ActionResult Put(BoletimDTO boletim, int idAluno, int id)
        {
            
                boletim.AlunoId = idAluno;
                boletim.Id = id;
                return Ok(new BoletimDTO(_boletimService.Atualizar(new Boletim(boletim))));
            
        }

        // GET:boletins
        [HttpGet("/alunos/{alunoId}/boletins")]
        public ActionResult<Boletim> GetBoletins(int alunoId)
        {
            var boletins = _boletimService.ObterBoletinsAluno(alunoId);                                   
            return Ok(boletins);
            
        }

        // GET: boletins/5
        [HttpGet("{id}")]
        public ActionResult<Boletim> GetBoletim(int id)
        {
            
                var boletim = _boletimService.ObterPorId(id);
                return Ok(new BoletimDTO(boletim));
           
        }

        //GET: /alunos/{idAluno}/boletins/{id}
        [HttpGet("/alunos/{alunoId}/boletins/{id}")]
        public ActionResult GetPorIdValidaAluno(int alunoId, int id)
        {
                var boletim = _boletimService.ObterPorId(id);

                if (boletim.AlunoId != alunoId)
                    return NotFound("Boletim Id invalido para aluno");

                return Ok(new BoletimDTO(boletim));
            
        }

        //DELETE: boletins/{id}
        [HttpDelete("boletins/{id}")]
        public ActionResult Delete(int id)
        {           
                _boletimService.DeletarBoletim(id);
                return StatusCode(204);
            
        }
    }
}
