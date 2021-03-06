﻿using System.Collections.Generic;
using CopaFilmes.Domain.Interfaces;
using System.Linq;

namespace CopaFilmes.Domain.Entities
{
    public class Rodada : IRodada
    {
        private readonly IPartida _partida;

        public Rodada(IPartida partida)
        {
            _partida = partida;
        }

        private const int QUANTIDADE_DE_COMPETIDORES = 2;

        /// <summary>
        /// Processa a primeira rodada, executando as partidas entre Filmes.
        /// </summary>
        /// <param name="filmes">Filmes que vão disputar entre si.</param>
        /// <returns>Filmes campeões da rodada.</returns>
        public Filme[] IniciarPrimeiraRodada(IEnumerable<Filme> filmes)
        {
            int qtdFilmes = filmes.Count();
            int qtdPartidas = qtdFilmes / QUANTIDADE_DE_COMPETIDORES;
            Filme[] rodada = new Filme[qtdPartidas];

            for (int i = 0; i < qtdPartidas; i++)
            {
                Filme competidorX = filmes.ElementAt(i);
                Filme competidorY = filmes.ElementAt(qtdFilmes - i - 1);

                Filme vencedor = _partida.Disputar(competidorX, competidorY);
                rodada[i] = vencedor;
            }

            return rodada;
        }

        /// <summary>
        /// Processa a segunda rodada/semiFinal, executadado as partidas entre os filmes que foram campeões.
        /// </summary>
        /// <param name="filmes">Filmes que vão disputar entre si.</param>
        /// <returns>Filmes campeões da rodada.</returns>
        public Filme[] IniciarSemiFinal(IEnumerable<Filme> filmes)
        {
            int qtdPartidas = filmes.Count() / QUANTIDADE_DE_COMPETIDORES;
            Filme[] rodada = new Filme[qtdPartidas];

            for (int i = 0; i <= qtdPartidas; i += QUANTIDADE_DE_COMPETIDORES)
            {
                Filme competidorX = filmes.ElementAt(i);
                Filme competidorY = filmes.ElementAt(i + 1);

                Filme vencedor = _partida.Disputar(competidorX, competidorY);
                rodada[i / qtdPartidas] = vencedor;
            }

            return rodada;
        }

        /// <summary>
        /// Processa a Rodada Final.
        /// </summary>
        /// <param name="competidorX">Filme que irá disputar a final.</param>
        /// <param name="competidorY">Filme que irá disputar a final.</param>
        /// <returns>Retorna a posição dos vencedores.</returns>
        public Filme[] IniciarFinal(Filme competidorX, Filme competidorY)
        {
            const int INDEX_VENCEDOR = 0;
            const int INDEX_VICE = 1;

            Filme[] vencedores = new Filme[QUANTIDADE_DE_COMPETIDORES];

            Filme vencedor = _partida.Disputar(competidorX, competidorY);

            vencedores[INDEX_VENCEDOR] = vencedor;
            vencedores[INDEX_VICE] = vencedor == competidorY ? competidorX : competidorY;

            return vencedores;
        }
    }
}
