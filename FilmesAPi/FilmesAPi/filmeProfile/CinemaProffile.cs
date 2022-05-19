using AutoMapper;
using FilmesAPi.Data.DTOS;
using FilmesAPi.Models;

namespace FilmesAPi.filmeProfile
{
    public class CinemaProffile : Profile
    {
        public CinemaProffile()
        {
            CreateMap<CinemaDto, Cinema>();
            CreateMap<EnderecoDTO, Endereco>();
        }
    }
}