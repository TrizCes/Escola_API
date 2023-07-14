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

namespace Escola.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotasMateriasController : ControllerBase
    {
        private readonly INotasMateriaService _notasMateriasService;

        public NotasMateriasController(INotasMateriaService notasMateriasService)
        {
            _notasMateriasService = notasMateriasService;   
        }

        // GET: api/NotasMaterias/5
        [HttpGet("{id}")]
        public ActionResult<NotasMateria> GetNotasMateria(int id)
        {
            try
            {
                var notasMateria = _notasMateriasService.ObterPorId(id);
                return Ok(new NotasMateriaDTO (notasMateria));
            }catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        // GET: NotasMaterias
        [HttpGet("/alunos/{alunoId}/boletins/{boletimId}/NotasMateria/")]
        public ActionResult<NotasMateria> GetNotasMaterias(int alunoId, int boletimId)
        {
            try
            {
                var notasMateria = _notasMateriasService.ObterNotasBoletim(alunoId, boletimId);
                return Ok(notasMateria);
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

        
        /*
        // PUT: api/NotasMaterias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotasMateria(int id, NotasMateria notasMateria)
        {
            if (id != notasMateria.Id)
            {
                return BadRequest();
            }

            _context.Entry(notasMateria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotasMateriaExists(id))
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

        // POST: api/NotasMaterias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NotasMateria>> PostNotasMateria(NotasMateria notasMateria)
        {
            _context.NotasMaterias.Add(notasMateria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotasMateria", new { id = notasMateria.Id }, notasMateria);
        }

        // DELETE: api/NotasMaterias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotasMateria(int id)
        {
            var notasMateria = await _context.NotasMaterias.FindAsync(id);
            if (notasMateria == null)
            {
                return NotFound();
            }

            _context.NotasMaterias.Remove(notasMateria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NotasMateriaExists(int id)
        {
            return _context.NotasMaterias.Any(e => e.Id == id);
        }
        */
    }
}
