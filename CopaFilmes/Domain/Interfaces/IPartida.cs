using CopaFilmes.Domain.Entities;

namespace CopaFilmes.Domain.Interfaces
{
    public interface IPartida
    {
        Filme Disputar(Filme competidorX, Filme competidorY);
    }
}
