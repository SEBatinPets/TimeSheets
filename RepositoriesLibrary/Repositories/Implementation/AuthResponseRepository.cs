using ModelsLibrary.Models.Entities.Auth;
using RepositoriesLibrary.Data.Ef.DbContexts;
using RepositoriesLibrary.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RepositoriesLibrary.Repositories.Implementation
{
    public class AuthResponseRepository: IAuthResponseRepository
    {
        private readonly TimeSheetsDbContext context;
        public AuthResponseRepository(TimeSheetsDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateAsync(AuthResponse item, CancellationToken token)
        {
            try
            {
                var auth = await GetByLogin(item.Login, token);
                if(auth != null)
                {
                    return 403;
                }
                await context.AuthResponses.AddAsync(item, token);
                await context.SaveChangesAsync();
                return 200;
            }
            catch
            {
                return 400;
            }
        }

        public Task<int> DeleteByIdAsync(int id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResponse> GetByIdAsync(int id, CancellationToken token)
        {
            var result = context.AuthResponses.Where(x => x.Id == id).FirstOrDefault();
            return Task.FromResult(result);
        }

        public Task<AuthResponse> GetByLogin(string login, CancellationToken token)
        {
            var result = context.AuthResponses.Where(x => x.Login == login).FirstOrDefault();
            return Task.FromResult(result);
        }

        public Task<AuthResponse> GetByToken(string token, CancellationToken cancellationToken)
        {
            var result = context.AuthResponses.Where(x => x.LatestRefreshToken.Token == token).FirstOrDefault();
            return Task.FromResult(result);
        }

        public async Task UpdateLatestRefreshToken(int authId, RefreshToken token, CancellationToken cancellationToken)
        {
            var auth = await GetByIdAsync(authId, cancellationToken);
            if (auth != null)
            {
                var refresh = context.RefreshTokens.
                    Where(x => x.AuthResponseId == authId).FirstOrDefault();
                if (refresh != null)
                {
                    auth.LatestRefreshToken = refresh;
                    auth.LatestRefreshToken.Token = token.Token;
                    auth.LatestRefreshToken.Expires = token.Expires;
                    context.AuthResponses.Update(auth);
                    await context.SaveChangesAsync();
                }
                else
                {
                    auth.LatestRefreshToken = token;
                    context.AuthResponses.Update(auth);
                    await context.SaveChangesAsync();
                }
            }
        }

        public Task<int> UpdateAsync(AuthResponse item, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
