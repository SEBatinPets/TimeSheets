using ModelsLibrary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoriesLibrary.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetByNameAsync(string name, CancellationToken token);
        Task<IEnumerable<Person>> GetPaginationAsync(int skip, int take, CancellationToken token);
        Task CreateAsync(Person item, CancellationToken token);
        Task<Person> GetByIdAsync(int id, CancellationToken token);
        Task<int> UpdateAsync(Person item, CancellationToken token);
        Task DeleteByIdAsync(int id, CancellationToken token);
    }
}
