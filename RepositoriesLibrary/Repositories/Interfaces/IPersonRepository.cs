using ModelsLibrary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoriesLibrary.Repositories.Interfaces
{
    public interface IPersonRepository: IRepository<Person>
    {
        Task<IEnumerable<Person>> GetByNameAsync(string name, CancellationToken token);
        Task<IEnumerable<Person>> GetPaginationAsync(int skip, int take, CancellationToken token);
    }
}
