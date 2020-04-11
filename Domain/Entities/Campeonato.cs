using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public class Campeonato
    {
        private const int QTD_COMPETIDORES_VALIDA = 8;

        public static IEnumerable<Filme> Iniciar(IEnumerable<Filme> filmes)
        {
            int qtdFilmes = filmes.Count();

            if (qtdFilmes == QTD_COMPETIDORES_VALIDA)
            {
                filmes = filmes.OrderBy(x => x.Titulo).ToArray();

                filmes = PrimeiraRodada(filmes);
                filmes = SegundaRodada(filmes);

                // Final
                Filme vencedor = Filme.Disputar(filmes.ElementAt(0), filmes.ElementAt(1));

                if (vencedor == filmes.ElementAt(1))
                {
                    filmes = filmes.Reverse();
                }

                return filmes;
            }

            throw new Exception("Quantidade de filmes inválida, 8 filmes devem ser enviados.");
        }

        private static Filme[] PrimeiraRodada(IEnumerable<Filme> filmes)
        {
            int qtdFilmes = filmes.Count();
            int qtdPartidas = qtdFilmes / 2;
            Filme[] rodada = new Filme[qtdPartidas];

            for (int i = 0; i < qtdPartidas; i++)
            {
                Filme competidorX = filmes.ElementAt(i);
                Filme competidorY = filmes.ElementAt(qtdFilmes - i - 1);

                Filme vencedor = Filme.Disputar(competidorX, competidorY);
                rodada[i] = vencedor;
            }

            return rodada;
        }

        private static Filme[] SegundaRodada(IEnumerable<Filme> filmes)
        {
            int qtdPartidas = filmes.Count() / 2;
            Filme[] rodada = new Filme[qtdPartidas];

            for (int i = 0; i <= qtdPartidas; i += 2)
            {
                Filme competidorX = filmes.ElementAt(i);
                Filme competidorY = filmes.ElementAt(i + 1);

                Filme vencedor = Filme.Disputar(competidorX, competidorY);
                rodada[i / qtdPartidas] = vencedor;
            }

            return rodada;
        }

    }
}
