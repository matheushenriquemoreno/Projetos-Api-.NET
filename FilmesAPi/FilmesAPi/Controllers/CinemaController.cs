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
    public class CinemaController : ControllerBase
    {
        public readonly IRepositoryCinema _repositoryCinema;
        private readonly IMapper _mapper;

        public CinemaController(IRepositoryCinema repository, IMapper mapper)
        {
            _repositoryCinema = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CadastroEndereco([FromBody] CinemaDto cinema)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            try
            {
                var adicionar = _mapper.Map<Cinema>(cinema);

                _repositoryCinema.Adicionar(adicionar);

                return Ok(adicionar);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult BustaTodos()
        {
            var dados = _repositoryCinema.BuscaTodos();
            return Ok(dados);
        }
    }
}
