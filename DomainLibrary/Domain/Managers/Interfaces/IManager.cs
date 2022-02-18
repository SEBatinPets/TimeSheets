using ModelsLibrary.Models.DTO;
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
        Task CreateAsync(PersonDto item, CancellationToken token);
        Task<PersonDto> GetByIdAsync(int id, CancellationToken token);
        Task UpdateAsync(PersonDto item, CancellationToken token);
        Task DeleteByIdAsync(int id, CancellationToken token);
    }
}
