using CopaFilmes.Domain.Entities;
using System.Collections.Generic;

namespace CopaFilmes.Domain.Interfaces
{
    public interface ICampeonato
    {
        IEnumerable<Filme> Iniciar(IEnumerable<Filme> filmes);
    }
}