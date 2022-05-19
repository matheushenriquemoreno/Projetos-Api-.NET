using FilmesAPi.Data;
using FilmesAPi.Models;
using FilmesAPi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPi.Repository.RepositoryEntitities
{
    public class RepositoryCinema : RepositoryBase<Cinema>, IRepositoryCinema 
    {
        public RepositoryCinema(AppDbContext filmeContext) : base(filmeContext) { }

    }
}
