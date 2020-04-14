using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities
{
    public static class Campeonato
    {
        private const int QTD_COMPETIDORES_VALIDA = 8;

        /// <summary>
        /// Da ao inicio ao campeonato entre os filmes.
        /// </summary>
        /// <param name="filmes">Filmes que irão disputar.</param>
        /// <returns>Retorna os vencedores.</returns>
        public static IEnumerable<Filme> Iniciar(IEnumerable<Filme> filmes)
        {
            int qtdFilmes = filmes.Count();

            if (qtdFilmes == QTD_COMPETIDORES_VALIDA)
            {
                filmes = filmes.OrderBy(x => x.Titulo);

                return ExecutarRodadas(filmes);
            }

            throw new Exception("Quantidade de filmes inválida, 8 filmes devem ser enviados.");
        }

        /// <summary>
        /// Processa as rodadas do campeonato.
        /// </summary>
        /// <param name="filmes">Filmes que irão participar do campeonato.</param>
        /// <returns>Retorna os vencedores.</returns>
        private static Filme[] ExecutarRodadas(IEnumerable<Filme> filmes)
        {
            filmes = Rodada.IniciarPrimeiraRodada(filmes);
            filmes = Rodada.IniciarSemiFinal(filmes);

            return Rodada.IniciarFinal(filmes.ElementAtOrDefault(0), filmes.ElementAtOrDefault(1));
        }
    }
}
