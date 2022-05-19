using AutoMapper;
using FilmesAPi.Data.DTOS;
using FilmesAPi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPi.filmeProfile
{
    public class FilmeProfileMapper : Profile
    {
        public FilmeProfileMapper()
        {
            CreateMap<FilmeDto, Filme>();
            CreateMap<Filme, FilmeDtoLeitura>();
        }
    }
}
