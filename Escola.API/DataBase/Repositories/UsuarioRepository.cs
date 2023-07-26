using Escola.API.Interfaces.Repositories;
using Escola.API.Model;

namespace Escola.API.DataBase.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario,  string>, IUsuarioRepository
    {
        public UsuarioRepository(EscolaDbContexto contexto) : base(contexto)
        {

        }
    }
}
