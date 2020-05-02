using CopaFilmes.Domain.Entities;
using System.Collections.Generic;

namespace CopaFilmes.Domain.Interfaces
{
    public interface IRodada
    {
        Filme[] IniciarPrimeiraRodada(IEnumerable<Filme> filmes);

        Filme[] IniciarSemiFinal(IEnumerable<Filme> filmes);

        Filme[] IniciarFinal(Filme competidorX, Filme competidorY);
    }
}
