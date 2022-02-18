using ModelsLibrary.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainLibrary.Domain.Managers.Interfaces
{
    public interface IPersonManager: IManager<PersonDto>
    {
        Task<PersonDto> GetByNameAsync(string name, CancellationToken token);
        Task<IEnumerable<PersonDto>> GetByPaginationAsync(int skip, int take, CancellationToken token);        
    }
}
