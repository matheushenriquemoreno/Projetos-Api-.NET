using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCatalogoJogs.ViewModel;
using ApiCatalogoJogs.InputModel;
using ApiCatalogoJogs.Services;
using System.ComponentModel.DataAnnotations;
using ApiCatalogoJogs.Exceptions;

namespace ApiCatalogoJogs.Controllers.VersionamentoRotaV1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        /*
          a injeção de dependencia traz o conceito de depender de contratos e não de implementações.

           Recebo uma interface -> ai atraves dela manipulo o servico que foi implementando

           Garantindo um desacoplamento 

        */

        // readonly faz com que reponsabilidade de instaciar o objeto não seja nossa 

        private readonly IjogoService _jogoService;


        public JogosController(IjogoService service)
        {
            _jogoService = service;

        }

        /*
             Get -> consulta
             Post -> Criar um recurso
             Put e pat -> atualizar
             Delete -> excluir
         */

        [HttpGet]                                                 
        public async Task<ActionResult<List<JogoViewModel>>> Obter([FromQuery, Range(1,int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {

            var resultado = await _jogoService.Obter(1, 5);

            if (resultado.Count == 0)
                return NoContent();

            return Ok(resultado);

        }

        /*    
             Diferença entre Rota e URl
        
             FromRoute dados vem da rota 

             FromQuery dados vem da URl

             Rota api/123 
             URl api?id=123 
         */


        [HttpGet("{idJogo:guid}")]                      
        public async Task<ActionResult<List<JogoViewModel>>> Obter([FromRoute]Guid idJogo)
        {
            var resultado = _jogoService.Obter(idJogo);

            if (resultado is null)
                return NotFound();

            return Ok(resultado);
        }


        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> inserirJogo([FromBody] JogoInputModel jogo)
        {
            try
            {
                var resultado = await _jogoService.Inserir(jogo);


                return Ok(resultado);

            }
            // catch (jogoCadastradoExeption ex)
            catch (JogosExceptions e)
            {
                return UnprocessableEntity(e.Message);
            }
        }


        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromBody] JogoInputModel jogo)
        {

            try
            {

                 await _jogoService.Atualizar(idJogo, jogo);

                return Ok();

            }
            // catch (jogoCadastradoExeption ex)
            catch (JogosExceptions e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch("{idJogo:guid}/Preco/{preco:double}")] // a diferença da requisição Put para a Patch e que a Put atualiza todo o objeto e o Patch somente parte dele
        public async Task<ActionResult<JogoViewModel>> AtualizaJogoPreco([FromRoute] Guid idJogo, [FromRoute] double preco)
        {
            try
            {

                await _jogoService.Atualizar(idJogo, preco);

                return Ok();

            }
            // catch (jogoCadastradoExeption ex)
            catch (JogosExceptions e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> ApagarJogo(Guid idJogo)
        {
            try
            {

                await _jogoService.Remover(idJogo);

                return Ok();

            }
            // catch (jogoCadastradoExeption ex)
            catch (JogosExceptions e)
            {
                return UnprocessableEntity(e.Message);
            }
        }



    }
}
