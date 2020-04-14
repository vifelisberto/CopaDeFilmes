using Domain.Entities;
using Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IApiService _api;

        public FilmeService(IApiService api)
        {
            _api = api;
        }

        public async Task<IEnumerable<Filme>> GetFilmes() => await _api.Get().ConfigureAwait(false);
    }
}
