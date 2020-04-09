using Domain.Entities;
using Infra.Interfaces;
using Service.Interfaces;
using System.Collections.Generic;
using System.Linq;
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

        public void IniciarCompeticao(List<Filme> filmes)
        {
            if (filmes.Count == 8)
            {
                List<Filme> primeiraRodada = new List<Filme>();
                filmes = filmes.OrderBy(x => x.Titulo).ToList();

                for (int i = 0; i < filmes.Count; i++)
                {
                    Filme left = filmes[i];
                    Filme rigth = filmes[filmes.Count - i - 1];

                    primeiraRodada.Add(left.Nota > rigth.Nota ? left : rigth);
                }
            }
        }
    }
}
