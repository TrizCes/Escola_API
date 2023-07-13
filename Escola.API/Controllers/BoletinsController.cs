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
        private readonly IMemoryCache _memoryCache;

        public BoletinsController(IBoletimService boletimService, IMemoryCache memoryCache)
        {
            _boletimService = boletimService;
            _memoryCache = memoryCache;
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


        /*
        // PUT: api/Boletins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoletim(int id, Boletim boletim)
        {
            if (id != boletim.Id)
            {
                return BadRequest();
            }

            _context.Entry(boletim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoletimExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Boletins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Boletim>> PostBoletim(Boletim boletim)
        {
            _context.Boletins.Add(boletim);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoletim", new { id = boletim.Id }, boletim);
        }

        // DELETE: api/Boletins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoletim(int id)
        {
            var boletim = await _context.Boletins.FindAsync(id);
            if (boletim == null)
            {
                return NotFound();
            }

            _context.Boletins.Remove(boletim);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BoletimExists(int id)
        {
            return _context.Boletins.Any(e => e.Id == id);
        }
        */
    }
}
