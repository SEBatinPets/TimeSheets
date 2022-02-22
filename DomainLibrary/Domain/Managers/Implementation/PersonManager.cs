using DomainLibrary.Domain.Managers.Interfaces;
using ModelsLibrary.Models.DTO;
using RepositoriesLibrary.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainLibrary.Domain.Managers.Implementation
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepository personRepository;
        public PersonManager(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }
        public async Task CreateAsync(PersonDto item, CancellationToken token)
        {
            await personRepository.CreateAsync(item, token);
        }

        public async Task DeleteByIdAsync(int id, CancellationToken token)
        {
            await personRepository.DeleteByIdAsync(id, token);
        }

        public async Task<PersonDto> GetByIdAsync(int id, CancellationToken token)
        {
            return await personRepository.GetByIdAsync(id,token);
        }

        public async Task<PersonDto> GetByNameAsync(string name, CancellationToken token)
        {
            return await personRepository.GetByNameAsync(name, token);
        }

        public async Task<IEnumerable<PersonDto>> GetByPaginationAsync(int skip, int take, CancellationToken token)
        {
            IList<PersonDto> result = new List<PersonDto>();
            var persons = await personRepository.GetPaginationAsync(skip, take, token);
            foreach (PersonDto person in persons)
            {
                result.Add(person);
            }
            return result;
        }

        public async Task<int> UpdateAsync(PersonDto item, CancellationToken token)
        {
            return await personRepository.UpdateAsync(item, token);
        }
    }
}
