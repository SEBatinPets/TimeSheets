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
    public class UsersManager : IUsersManager
    {
        private readonly IUsersRepository userRepository;
        public UsersManager(IUsersRepository userRepository) 
        {
            this.userRepository = userRepository;
        }
        public async Task<int> CreateAsync(UserDto item, CancellationToken token)
        {
            return await userRepository.CreateAsync(item, token);
        }

        public async Task<int> DeleteByIdAsync(int id, CancellationToken token)
        {
            return await userRepository.DeleteByIdAsync(id, token);
        }

        public async Task<UserDto> GetByIdAsync(int id, CancellationToken token)
        {
            return await userRepository.GetByIdAsync(id, token);
        }

        public async Task<int> UpdateAsync(UserDto item, CancellationToken token)
        {
            return await userRepository.UpdateAsync(item, token);
        }
    }
}
