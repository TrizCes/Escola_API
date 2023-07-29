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
using Microsoft.AspNetCore.Authorization;

namespace Escola.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Professor")]
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
                MateriaDTO materia;
                if (!_memoryCache.TryGetValue<MateriaDTO>($"materia:{nome}", out materia))
                {
                    materia = new MateriaDTO(_materiaService.ObterPorNome(nome));
                    _memoryCache.Set<MateriaDTO>($"materia:{nome}", materia, new TimeSpan(0, 0, 20));
                }
                return Ok(materia);
            }

             var materias = _materiaService.ObterMaterias();
             IEnumerable<MateriaDTO> materiasDto = materias.Select(x => new MateriaDTO(x));
             return Ok(materiasDto);
        }

        // GET: api/Materias/5
        [HttpGet("{id}")]
        public ActionResult<MateriaDTO> GetMateria(int id)
        {
            MateriaDTO materia;
            if (!_memoryCache.TryGetValue<MateriaDTO>($"materia:{id}", out materia))
            {
                materia = new MateriaDTO(_materiaService.ObterPorId(id));
                _memoryCache.Set<MateriaDTO>($"materia:{id}", materia, new TimeSpan(0, 0, 20));
            }
            return Ok(materia);

        }

        // POST: api/Materias
        [HttpPost]
        public IActionResult PostMateria([FromBody] MateriaDTO materiaDTO)
        {
            var materia = new Materia(materiaDTO);
                
            materia = _materiaService.Criar(materia);

            return Ok(new MateriaDTO(materia));
            
        }

        // PUT: api/Materias/5
        [HttpPut("{id}")]
        public IActionResult PutMateria(int id, [FromBody] MateriaDTO materiaDTO)
        {

            var materia = new Materia(materiaDTO);
            materia.Id = id;
            if (!ModelState.IsValid) return BadRequest("Dados inválidos, favor verificar o formato obrigatório dos dados!");

            materia = _materiaService.Atualizar(materia);

            _memoryCache.Remove($"Matéria:{id}");

            return Ok(new MateriaDTO(materia));
            
        }

        // DELETE: api/Materias/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMateria(int id)
        {
            _materiaService.DeletarMateria(id);
            _memoryCache.Remove($"materia:{id}");         
            return StatusCode(204);
        }

    }
}
