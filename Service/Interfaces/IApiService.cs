using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IApiService
    {
        Task<IEnumerable<Filme>> Get();
    }
}
