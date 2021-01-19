using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sonda.Api.Contratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sonda.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SondaController : ControllerBase
    {
        private readonly ISondaService _service;

        public SondaController(ISondaService service)
        {
            _service = service;

        }

        [HttpPost]
        public IActionResult Post([FromBody] IList<Models.Sonda> sondas) 
        {
            var result = _service.Monvimentar(sondas);
            return Ok(result);
        }
    }
}
