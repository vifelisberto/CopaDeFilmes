using CopaFilmes.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Service.Interfaces
{
    public interface IFilmeService
    {
        Task<IEnumerable<Filme>> GetFilmes();
    }
}
