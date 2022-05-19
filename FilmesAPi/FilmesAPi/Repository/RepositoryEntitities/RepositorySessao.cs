using FilmesAPi.Data;
using FilmesAPi.Models;
using FilmesAPi.Repository.Interfaces;

namespace FilmesAPi.Repository.RepositoryEntitities
{
    public class RepositorySessao : RepositoryBase<Sessao>, IRepositorySessao
    {
        public RepositorySessao(AppDbContext filmeContext) : base(filmeContext) { }
    }
}