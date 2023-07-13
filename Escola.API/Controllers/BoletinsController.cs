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
using Microsoft.Extensions.Caching.Memory;
using Escola.API.DTO;
using Escola.API.Exceptions;
using Escola.API.Services;

namespace Escola.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
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
            try
            {
                boletim.AlunoId = alunoId;

                boletim.Id = _boletimService.Criar(new Boletim (boletim)).Id;

                return Ok(boletim);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //Put: /alunos/{idAluno}/boletins/{id}
        [HttpPut("/alunos/{idAluno}/boletins/{id}")]
        public ActionResult Put(BoletimDTO boletim, int idAluno, int id)
        {
            try
            {
                boletim.AlunoId = idAluno;
                boletim.Id = id;
                return Ok(new BoletimDTO(_boletimService.Atualizar(new Boletim(boletim))));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET:boletins
        [HttpGet("/alunos/{alunoId}/boletins")]
        public ActionResult<Boletim> GetBoletins(int alunoId)
        {
            try
            {
                var boletins = _boletimService.ObterBoletinsAluno(alunoId);
                                    
                return Ok(boletins);
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

        // GET: boletins/5
        [HttpGet("{id}")]
        public ActionResult<Boletim> GetBoletim(int id)
        {
            try
            {
                var boletim = _boletimService.ObterPorId(id);

                return Ok(new BoletimDTO(boletim));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //GET: /alunos/{idAluno}/boletins/{id}
        [HttpGet("/alunos/{alunoId}/boletins/{id}")]
        public ActionResult GetPorIdValidaAluno(int alunoId, int id)
        {
            try
            {

                var boletim = _boletimService.ObterPorId(id);

                if (boletim.AlunoId != alunoId)
                    return NotFound("Boletim Id invalido para aluno");

                return Ok(new BoletimDTO(boletim));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        
    }
}
