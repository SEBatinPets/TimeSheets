using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainLibrary.Domain.Managers.Interfaces
{
    public interface IManager<T> where T : class
    {
        Task CreateAsync(T item, CancellationToken token);
        Task<T> GetByIdAsync(int id, CancellationToken token);
        Task UpdateAsync(T item, CancellationToken token);
        Task DeleteByIdAsync(int id, CancellationToken token);
    }
}
