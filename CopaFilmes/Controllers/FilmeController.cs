using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _service;
        private readonly ILogger<FilmeController> _logger;

        public FilmeController(IFilmeService service, ILogger<FilmeController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => this.Ok(await _service.Get());

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] List<Filme> filmes)
        {
            await Task.Run(() => _service.IniciarCompeticao(filmes));
            return this.Ok();
        }
    }
}
