using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoriesLibrary.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<int> CreateAsync(T item, CancellationToken token);
        Task<T> GetByIdAsync(int id, CancellationToken token);
        Task<int> UpdateAsync(T item, CancellationToken token);
        Task<int> DeleteByIdAsync(int id, CancellationToken token);
    }
}
