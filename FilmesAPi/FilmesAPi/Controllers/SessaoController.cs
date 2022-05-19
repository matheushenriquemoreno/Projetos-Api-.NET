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
    public class SessaoController : ControllerBase
    {
        private readonly IRepositorySessao _repositorySessao;
        private readonly IMapper _mapper;

        public SessaoController(IMapper mapper,IRepositorySessao implementacao)
        {
            _repositorySessao = implementacao;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaGerente([FromBody] SessaoDTO dto)
        {
              var adicionar = _mapper.Map<Sessao>(dto);

            _repositorySessao.Adicionar(adicionar);

            return Ok(adicionar);
        }

        [HttpGet]
        public IActionResult buscaTodos()
        {
            return Ok(_repositorySessao.BuscaTodos());
        }

    }
}
