using Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestClass]
    public class CampeonatoTest
    {
        #region Variaveis para teste
        private readonly IEnumerable<Filme> filmes = new List<Filme>()
            {
                new Filme
                {
                    Id = "tt3606756",
                    Titulo = "Os Incríveis 2",
                    Ano = 2018,
                    Nota = 8.5f
                },
                new Filme
                {
                    Id = "tt4881806",
                    Titulo = "Jurassic World: Reino Ameaçado",
                    Ano = 2018,
                    Nota = 6.7f
                },
                new Filme
                {
                    Id = "tt5164214",
                    Titulo = "Oito Mulheres e um Segredo",
                    Ano = 2018,
                    Nota = 6.3f
                },
                new Filme
                {
                    Id = "tt7784604",
                    Titulo = "Hereditário",
                    Ano = 2018,
                    Nota = 7.8f
                },
                new Filme
                {
                    Id = "tt4154756",
                    Titulo = "Vingadores: Guerra Infinita",
                    Ano = 2018,
                    Nota = 8.8f
                },
                new Filme
                {
                    Id = "tt5463162",
                    Titulo = "Deadpool 2",
                    Ano = 2018,
                    Nota = 8.1f
                },
                new Filme
                {
                    Id = "tt3778644",
                    Titulo = "Han Solo: Uma História Star Wars",
                    Ano = 2018,
                    Nota = 7.2f
                },
                new Filme
                {
                    Id = "tt3501632",
                    Titulo = "Thor: Ragnarok",
                    Ano = 2017,
                    Nota = 7.9f
                }
            };
        #endregion

        [TestMethod]
        public void TestResultadoCampeonato()
        {
            IEnumerable<Filme> resultadoCorreto = new List<Filme> { filmes.ElementAtOrDefault(4), filmes.ElementAtOrDefault(0) };

            IEnumerable<Filme> resultado = Campeonato.Iniciar(filmes);

            Assert.IsTrue(resultado.SequenceEqual(resultadoCorreto));
        }
    }
}
