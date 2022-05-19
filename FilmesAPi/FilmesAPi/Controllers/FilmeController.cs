using AutoMapper;
using FilmesAPi.Data.DTOS;
using FilmesAPi.Models;
using FilmesAPi.Repository;
using FilmesAPi.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly IRepositoryFilme _repositoryBase;
        private readonly IMapper _mapper;

        public FilmeController(IRepositoryFilme implementacao, IMapper mapper)
        {
            _repositoryBase = implementacao;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] FilmeDto filmeDto)
        {
            var filmeAdicionar = _mapper.Map<Filme>(filmeDto);

            filmeAdicionar = _repositoryBase.Adicionar(filmeAdicionar);

            return Ok(filmeAdicionar);
            //return CreatedAtAction(nameof(RecuperarFilmesPorId), new { Id = filmeAdicionar.Id }, filmeDto); // informa o caminho pra localizar onde o recurso foi criado, e mostra ele. 
        }

        [HttpGet]
        public IActionResult RecuperarFilmes()
        {
            return Ok(_repositoryBase.BuscaTodos());
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFilmesPorId(int id)
        {
            var filme = _repositoryBase.BuscarOnde(x => x.Id == id);
           
            if (filme is null)
            {
                return NotFound();
            }

            var filmeDto = _mapper.Map<FilmeDtoLeitura>(filme);

            return Ok(filmeDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] FilmeDto filmeNovo)
        {
            var filmeAtualizar = _repositoryBase.BuscarOnde(x => x.Id == id);

            if (filmeAtualizar is null)
            {
                return NotFound();
            }

            _mapper.Map(filmeNovo, filmeAtualizar); // leva os dados do primeiro objeto pro segundo, dados atualizados ->  dados a atualizar
            _repositoryBase.Atualizar(filmeAtualizar);

            return NoContent();
        }
    }
}