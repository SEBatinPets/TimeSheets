using DomainLibrary.Domain.Managers.Interfaces;
using ModelsLibrary.Models.DTO.Auth;
using RepositoriesLibrary.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainLibrary.Domain.Managers.Implementation
{
    public class AuthManager: IAuthManager
    {
        private readonly IAuthResponseRepository authRepository;
        public AuthManager(IAuthResponseRepository authRepository)
        {
            this.authRepository = authRepository;
        }

        public async Task<int> CreateAsync(AuthResponseDto item, CancellationToken token)
        {
            return await authRepository.CreateAsync(item, token);
        }

        public Task<int> DeleteByIdAsync(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResponseDto> GetByIdAsync(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(AuthResponseDto item, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
