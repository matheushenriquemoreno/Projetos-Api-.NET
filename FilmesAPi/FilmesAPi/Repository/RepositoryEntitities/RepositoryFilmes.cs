using FilmesAPi.Data;
using FilmesAPi.Models;
using FilmesAPi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FilmesAPi.Repository
{
    public class RepositoryFilmes : RepositoryBase<Filme> , IRepositoryFilme
    {
        public RepositoryFilmes(AppDbContext filmeContext) : base(filmeContext) { }
    }
}
