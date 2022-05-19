using AutoMapper;
using FilmesAPi.Data.DTOS;
using FilmesAPi.Models;
using FilmesAPi.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GerenteController : ControllerBase
    {
        private IMapper _mapper;
        private IRepositoryGerente _repositoryGerente;

        public GerenteController(IMapper mapper, IRepositoryGerente repository)
        {
            _mapper = mapper;
            _repositoryGerente = repository;
        }

        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] GerenteDto dto)
        {
            var adicionar = _mapper.Map<Gerente>(dto);

            _repositoryGerente.Adicionar(adicionar);

            return Ok(adicionar);
        }

        [HttpGet]
        public IActionResult buscaTodos()
        {
            return Ok(_repositoryGerente.BuscaTodos());
        }
    }
}
