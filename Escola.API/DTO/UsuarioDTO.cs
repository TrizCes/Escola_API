using Escola.API.DTO.Request;
using Escola.API.Model;

namespace Escola.API.DTO
{
    public class UsuarioDTO : UsuarioRequestDTO
    {
        public string Senha { get; set; }

        public UsuarioDTO()
        {

        }
        public UsuarioDTO(Usuario usuario) : base (usuario)
        {
            Senha = usuario.Senha;
        }
    }
}
