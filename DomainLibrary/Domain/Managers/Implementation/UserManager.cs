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
    public class UserManager : IUserManager
    {
        private readonly IUserRepository userRepository;
        public UserManager(IUserRepository userRepository) 
        {
            this.userRepository = userRepository;
        }
        public async Task CreateAsync(UserDto item, CancellationToken token)
        {
            await userRepository.CreateAsync(item, token);
        }

        public async Task DeleteByIdAsync(int id, CancellationToken token)
        {
            await userRepository.DeleteByIdAsync(id, token);
        }

        public async Task<UserDto> GetByIdAsync(int id, CancellationToken token)
        {
            return await userRepository.GetByIdAsync(id, token);
        }

        public async Task UpdateAsync(UserDto item, CancellationToken token)
        {
            await userRepository.UpdateAsync(item, token);
        }
    }
}
