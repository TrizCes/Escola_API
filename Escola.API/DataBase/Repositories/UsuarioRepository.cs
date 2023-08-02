using Escola.API.Interfaces.Repositories;
using Escola.API.Model;
using System.Collections.Generic;
using System.Linq;

namespace Escola.API.DataBase.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario,  string>, IUsuarioRepository
    {
        public UsuarioRepository(EscolaDbContexto contexto) : base(contexto)
        {
        }
        public override Usuario ObterPorId(string login)
        {
            return _context.Usuarios.FirstOrDefault(x => login == x.Login);
        }
    }
}
