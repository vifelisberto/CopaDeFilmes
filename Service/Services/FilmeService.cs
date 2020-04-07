using Domain.Entities;
using Infra.Interfaces;
using Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeApi _api;

        public FilmeService(IFilmeApi api)
        {
            _api = api;
        }

        public async Task<IEnumerable<Filme>> Get() => await _api.Get().ConfigureAwait(false);
    }
}
