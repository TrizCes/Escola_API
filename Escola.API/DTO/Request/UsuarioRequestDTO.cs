using Escola.API.Model;
using Escola.API.Model.Enums;

namespace Escola.API.DTO.Request
{
    public class UsuarioRequestDTO
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public EnumTipoUsuario TipoUsuario { get; set; }
        public string Email { get; set; }
        public bool Interno { get; set; }


        public UsuarioRequestDTO()
        { }

        public UsuarioRequestDTO(Usuario usuario)
        {
            Nome = usuario.Nome;
            Login = usuario.Login;
            Email = usuario.Email;
            TipoUsuario = usuario.TipoUsuario;
            Interno = usuario.Interno;
        }
    }
}
