using Escola.API.DTO;
using Escola.API.DTO.Request;
using Escola.API.Model.Enums;
using NuGet.Protocol.Plugins;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Escola.API.Model
{
    public class Usuario
    {
        [Key]
        public string Login { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo TipoUsuario apenas aceita as opções: Aluno ou Professor")]
        public EnumTipoUsuario TipoUsuario { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [PasswordPropertyText]
        public string Senha { get; set; }
        public bool Interno { get; set; }

        public Usuario()
        {

        }
        public Usuario(UsuarioRequestDTO usuario)
        {
            Nome = usuario.Nome;
            Login = usuario.Login;
            Email = usuario.Email;
            TipoUsuario = usuario.TipoUsuario;
            Interno = usuario.Interno;
        }
        public Usuario(UsuarioDTO usuario) : this((UsuarioRequestDTO)usuario)
        {
            Senha = usuario.Senha;
        }

        public void Update(Usuario usuario)
        {
            Nome = usuario.Nome;
            TipoUsuario = usuario.TipoUsuario;
            Senha = usuario.Senha;
        }
    }
}
