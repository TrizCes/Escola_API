using Escola.API.Interfaces.Services;
using Escola.API.Model;
using Escola.API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using Escola.API.Exceptions;
using Escola.API.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Escola.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        private readonly IMateriaService _materiaService;
        private readonly IMemoryCache _memoryCache;


        public MateriasController(IMateriaService materiaService, IMemoryCache memoryCache)
        {
            _materiaService = materiaService;
            _memoryCache = memoryCache;
        }

        // GET: api/Materias
        [HttpGet]
        public ActionResult<MateriaDTO> GetMaterias([FromQuery] string? nome)
        {
            if(nome != null)
            {
                try
                {
                    MateriaDTO materia;
                    if (!_memoryCache.TryGetValue<MateriaDTO>($"materia:{nome}", out materia))
                    {
                        materia = new MateriaDTO(_materiaService.ObterPorNome(nome));
                        _memoryCache.Set<MateriaDTO>($"materia:{nome}", materia, new TimeSpan(0, 0, 20));
                    }
                    return Ok(materia);
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

            try
            {
                var materias = _materiaService.ObterMaterias();
                IEnumerable<MateriaDTO> materiasDto = materias.Select(x => new MateriaDTO(x));
                return Ok(materiasDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET: api/Materias/5
        [HttpGet("{id}")]
        public ActionResult<MateriaDTO> GetMateria(int id)
        {

            try
            {
                MateriaDTO materia;
                if (!_memoryCache.TryGetValue<MateriaDTO>($"materia:{id}", out materia))
                {
                    materia = new MateriaDTO(_materiaService.ObterPorId(id));
                    _memoryCache.Set<MateriaDTO>($"materia:{id}", materia, new TimeSpan(0, 0, 20));
                }
                return Ok(materia);
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

        // POST: api/Materias
        [HttpPost]
        public IActionResult PostMateria([FromBody] MateriaDTO materiaDTO)
        {
            try
            {
                var materia = new Materia(materiaDTO);
                
                materia = _materiaService.Criar(materia);

                return Ok(new MateriaDTO(materia));
            }
            catch (RegistroDuplicadoException ex)
            {
                return StatusCode(StatusCodes.Status409Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /*
        // PUT: api/Materias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateria(int id, Materia materia)
        {
            if (id != materia.Id)
            {
                return BadRequest();
            }

            _context.Entry(materia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MateriaExists(id))
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

        

        // DELETE: api/Materias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMateria(int id)
        {
            var materia = await _context.Materias.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }

            _context.Materias.Remove(materia);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MateriaExists(int id)
        {
            return _context.Materias.Any(e => e.Id == id);
        }
        */
    }
}
