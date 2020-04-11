using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Threading.Tasks;

namespace CopaFilmes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _service;

        public FilmeController(IFilmeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get() => this.Ok(await _service.GetFilmes().ConfigureAwait(false));
    }
}
