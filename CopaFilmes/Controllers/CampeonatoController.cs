using System.Collections.Generic;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampeonatoController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody]IEnumerable<Filme> filmes)
        {
            return this.Ok(Campeonato.Iniciar(filmes));
        }
    }
}