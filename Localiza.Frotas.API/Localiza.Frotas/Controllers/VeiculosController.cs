using Localica.Frotas.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Localiza.Frotas.Controllers
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {
        private readonly IveiculosRepository _repository;
        private readonly IveiculosDetran veiculosDetran;

        public VeiculosController(IveiculosRepository repository, IveiculosDetran veiculosDetran)
        {
            _repository = repository;
            this.veiculosDetran = veiculosDetran;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_repository.GetAll());

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var veiculo = _repository.GetById(id);
            if (veiculo == null)
            {
                return NotFound();
            }
            return Ok(veiculo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] InputVeiculoViewModel veiculo)
        {
            _repository.Add(veiculo);
            return CreatedAtAction(nameof(Get), veiculo);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] InputVeiculoViewModel veiculo)
        {

            _repository.Update(id, veiculo);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var veiculo = _repository.GetById(id);
            if (veiculo == null)
            {
                return NotFound();
            }
            _repository.Delete(veiculo);

            return NoContent();
        }


        [HttpPut("{id}/vistoria")]
        public IActionResult Put(Guid id)
        {
            veiculosDetran.AgendarVistoriaDetran(id);
            return NoContent();
        }



    }
}
