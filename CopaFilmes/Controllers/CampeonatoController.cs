using System.Collections.Generic;
using CopaFilmes.Domain.Entities;
using CopaFilmes.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampeonatoController : ControllerBase
    {
        private readonly ICampeonato _campeonato;

        public CampeonatoController(ICampeonato campeonato)
        {
            _campeonato = campeonato;
        }

        [HttpPost]
        public IActionResult Post([FromBody]IEnumerable<Filme> filmes)
        {
            return this.Ok(_campeonato.Iniciar(filmes));
        }
    }
}