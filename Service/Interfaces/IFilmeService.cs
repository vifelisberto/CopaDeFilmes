using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IFilmeService
    {
        Task<IEnumerable<Filme>> Get();
    }
}
