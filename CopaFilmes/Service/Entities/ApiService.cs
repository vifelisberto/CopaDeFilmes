using CopaFilmes.Domain.Entities;
using CopaFilmes.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CopaFilmes.Service.Entities
{
    public class ApiService : IApiService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string URL_API;
        private const string KEY_URL_API = "ApiUrlFilmes";

        public ApiService(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            URL_API = configuration[KEY_URL_API];
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
                using Stream responseStream = await response.Content.ReadAsStreamAsync();
                IEnumerable<Filme> result = await JsonSerializer.DeserializeAsync<IEnumerable<Filme>>(responseStream);

                return result.OrderBy(x => x.Titulo);
            }
            else
                return Array.Empty<Filme>();
        }
    }
}
