using ModelsLibrary.Models.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceLibrary.AuthorizationServices.Interfaces
{
    public interface IAuthService
    {
        Task<TokenResponse> Authenticate(string user, string password, CancellationToken token);
        Task<string> RefreshToken(string token, CancellationToken cancellationToken);
    }
}
