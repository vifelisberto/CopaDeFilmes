using Domain.Entities;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ApiService : IApiService
    {
        //todo: colocar no appsettings
        private const string URL_API = "http://copafilmes.azurewebsites.net/api";
        private const string ENDPOINT_FILMES = "filmes";
        private readonly IHttpClientFactory _clientFactory;

        public ApiService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        /// <summary>
        /// Realiza a busca dos filmes na API.
        /// </summary>
        /// <returns>Retorna um <see cref="IEnumerable{Filme}"/> com os filmes encontrados.</returns>
        public async Task<IEnumerable<Filme>> Get()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{URL_API}/{ENDPOINT_FILMES}");
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
