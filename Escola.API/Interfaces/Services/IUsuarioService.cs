using Escola.API.Model;
using System.Collections.Generic;

namespace Escola.API.Interfaces.Services
{
    public interface IUsuarioService
    {
        public Usuario Criar(Usuario usuario);
        public Usuario ObterPorId(string login);
        public Usuario Atualizar(Usuario usuario);
        public List<Usuario> Obter();
        public void Deletar(string login);
    }
}
