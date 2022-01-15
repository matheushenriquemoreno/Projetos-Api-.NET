using Localica.Frotas.Infra.Singleton;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Localiza.Frotas.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SingletonController : ControllerBase
    {
        private readonly SingletonContainer singleton;

        public SingletonController(SingletonContainer singleton)
        {
            this.singleton = singleton;
        }


        [HttpGet()]
        public IActionResult Get()
        {
           // var singleton = Singleton.Instance;
            return Ok(singleton);
        }

    }
}
