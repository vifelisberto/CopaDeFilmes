using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IFilmeApi
    {
        Task<IEnumerable<Filme>> Get();
    }
}
