using Escola.API.Model;

namespace Escola.API.DTO.Responses
{
    public class UsuarioResponseDTO
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public string TipoUsuario { get; set; }
        public string Email { get; set; }
        public bool Interno { get; set; }


        public UsuarioResponseDTO()
        { }

        public UsuarioResponseDTO(Usuario usuario)
        {
            Nome = usuario.Nome;
            Login = usuario.Login;
            TipoUsuario = usuario.TipoUsuario.ToString();
            Interno = usuario.Interno;
        }
    }
}
