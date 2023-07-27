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
using Microsoft.Extensions.Configuration;
using Escola.API.DTO;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Escola.API.DTO.Request;
using Escola.API.DTO.Responses;

namespace Escola.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public ActionResult<UsuarioResponseDTO> Post(UsuarioDTO usuario)
        {
            var usuarioDB = _usuarioService.Criar(new Usuario(usuario));


            return Created(Request.PathBase, new UsuarioResponseDTO(usuarioDB));
        }

        // PUT: api/Usuarios/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{login}")]
        public ActionResult<UsuarioResponseDTO> Put(UsuarioDTO usuario, string login)
        {
            usuario.Login = login;
            var usuarioDB = _usuarioService.Atualizar(new Usuario(usuario));

            return Ok(new UsuarioResponseDTO(usuarioDB));
        }

        // GET: api/Usuarios
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<List<UsuarioResponseDTO>> Get()
        {
            var usuarios = _usuarioService.Obter();

            return Ok(usuarios.Select(x => new UsuarioResponseDTO(x)));
        }

        // GET: api/Usuarios/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{login}")]
        public ActionResult<List<UsuarioResponseDTO>> Get(string login)
        {
            var usuarios = _usuarioService.ObterPorId(login);

            return Ok(new UsuarioResponseDTO(usuarios));
        }

        // DELETE: api/Usuarios/5
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{login}")]
        public ActionResult<List<UsuarioResponseDTO>> Deletar(string login)
        {
            _usuarioService.Deletar(login);
            return NoContent();
        }
      
    }
}
