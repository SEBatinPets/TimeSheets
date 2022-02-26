using ModelsLibrary.Models.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoriesLibrary.Repositories.Interfaces
{
    public interface IAuthResponseRepository: IRepository<AuthResponse>
    {
        public Task<AuthResponse> GetByLogin(string login, CancellationToken token);
        public Task<AuthResponse> GetByToken(string token, CancellationToken cancellationToken);
        public Task UpdateLatestRefreshToken(int authId , RefreshToken token, CancellationToken cancellationToken);
    }
}
