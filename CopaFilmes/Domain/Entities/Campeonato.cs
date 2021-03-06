﻿using CopaFilmes.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Domain.Entities
{
    public class Campeonato : ICampeonato
    {
        private readonly IRodada _rodada;

        public Campeonato(IRodada rodada)
        {
            _rodada = rodada;
        }

        private const int QTD_COMPETIDORES_VALIDA = 8;

        /// <summary>
        /// Da ao inicio ao campeonato entre os filmes.
        /// </summary>
        /// <param name="filmes">Filmes que irão disputar.</param>
        /// <returns>Retorna os vencedores.</returns>
        public IEnumerable<Filme> Iniciar(IEnumerable<Filme> filmes)
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
        private Filme[] ExecutarRodadas(IEnumerable<Filme> filmes)
        {
            filmes = _rodada.IniciarPrimeiraRodada(filmes);
            filmes = _rodada.IniciarSemiFinal(filmes);

            return _rodada.IniciarFinal(filmes.ElementAtOrDefault(0), filmes.ElementAtOrDefault(1));
        }
    }
}
