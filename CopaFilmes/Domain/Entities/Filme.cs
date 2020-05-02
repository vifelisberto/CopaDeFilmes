using System.Text.Json.Serialization;

namespace CopaFilmes.Domain.Entities
{
    public class Filme
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("titulo")]
        public string Titulo { get; set; }

        [JsonPropertyName("ano")]
        public ushort Ano { get; set; }

        [JsonPropertyName("nota")]
        public float Nota { get; set; }
    }
}
