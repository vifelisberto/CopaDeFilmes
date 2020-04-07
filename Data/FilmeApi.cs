using Domain.Entities;
using Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infra
{
    public class FilmeApi : IFilmeApi
    {
        private const string URL_API = "http://copafilmes.azurewebsites.net/api/filmes";
        private readonly IHttpClientFactory _clientFactory;

        public FilmeApi(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// Realiza a busca dos filmes na API.
        /// </summary>
        /// <returns>Retorna um <see cref="IEnumerable{Filme}"/> com os filmes encontrados.</returns>
        public async Task<IEnumerable<Filme>> Get()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, URL_API);
            request.Headers.Add("Accept", "application/json");

            HttpClient client = _clientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                IEnumerable<Filme> result = await JsonSerializer.DeserializeAsync<IEnumerable<Filme>>(responseStream);

                return result.OrderBy(x => x.Titulo);
            }
            else
                return Array.Empty<Filme>();
        }
    }
}
