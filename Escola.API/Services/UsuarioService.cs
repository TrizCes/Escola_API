using Escola.API.Exceptions;
using Escola.API.Interfaces.Repositories;
using Escola.API.Interfaces.Services;
using Escola.API.Model;
using Escola.API.Utils;
using System.Collections.Generic;

namespace Escola.API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Criar(Usuario usuario)
        {
            var usuarioDb = ObterPorId(usuario.Login);
            if (usuarioDb != null)
                throw new RegistroDuplicadoException("Login já cadastrado, tente novamente");

            usuario.Senha = Criptografia.CriptografarSenha(usuario.Senha);
            return _usuarioRepository.Inserir(usuario);
        }
        public Usuario Atualizar(Usuario usuario)
        {
            var usuarioDb = ObterPorId(usuario.Login);
            if (usuarioDb == null)
                throw new KeyNotFoundException("Usuario Não existe");
            usuario.TipoUsuario = usuarioDb.TipoUsuario;
            usuarioDb.Update(usuario);
            if (!string.IsNullOrEmpty(usuario.Senha))
                usuarioDb.Senha = Criptografia.CriptografarSenha(usuario.Senha);
            _usuarioRepository.Atualizar(usuarioDb);
            return usuario;
        }

        public void Deletar(string login)
        {
            var usuarioDb = ObterPorId(login);
            if (usuarioDb == null)
                throw new KeyNotFoundException("Usuario Não existe");

            _usuarioRepository.Excluir(usuarioDb);
        }

        public List<Usuario> Obter()
        {
            return _usuarioRepository.ObterTodos();
        }

        public Usuario ObterPorId(string login)
        {
            return _usuarioRepository.ObterPorId(login);
        }
    }
}
