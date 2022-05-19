using FilmesAPi.Data;
using FilmesAPi.Models;
using FilmesAPi.Repository.Interfaces;


namespace FilmesAPi.Repository.RepositoryEntitities
{
    public class RepositoryGerente : RepositoryBase<Gerente>, IRepositoryGerente
    {
        public RepositoryGerente(AppDbContext filmeContext) : base(filmeContext) { }
    }
}
